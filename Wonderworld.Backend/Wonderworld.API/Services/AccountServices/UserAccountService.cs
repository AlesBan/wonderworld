using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Helpers;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Dtos.InstitutionDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;
using Wonderworld.Application.Dtos.UserDtos.CreateAccountDtos;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;
using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetCountryByTitle;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplinesByTitles;
using Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries.GetGrades;
using Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Queries.GetEstablishment;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByTitles;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.DeleteAllUsers;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.DeleteUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserResetToken;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserToken;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserVerification;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserById;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Infrastructure.Services.EmailHandlerService;

namespace Wonderworld.API.Services.AccountServices;

public class UserAccountService : IUserAccountService
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly IEmailHandlerService _emailHandlerService;

    public UserAccountService(IConfiguration configuration, IMapper mapper, IEmailHandlerService emailHandlerService)
    {
        _configuration = configuration;
        _mapper = mapper;
        _emailHandlerService = emailHandlerService;
    }

    public async Task<IActionResult> RegisterUser(UserRegisterRequestDto requestUserDto, IMediator mediator)
    {
        var user = new User()
        {
            Email = requestUserDto.Email
        };

        UserHelper.SetUserPasswordHash(user, requestUserDto.Password);

        user.VerificationToken = JwtHelper.CreateToken(user, _configuration);

        var registeredUser = await mediator.Send(new RegisterUserCommand(user));

        if (registeredUser == null)
        {
            throw new Exception();
        }

        var message = @"Click this link to verify your email: http://localhost:7280/api/user/verify-email?token=" +
                      registeredUser.VerificationToken;
        await _emailHandlerService.SendAsync(_configuration, user.Email, "Wonderworld", message);

        return ResponseHelper.GetAuthResultOk(registeredUser.VerificationToken);
    }

    public async Task<IActionResult> LoginUser(UserLoginRequestDto requestUserDto, IMediator mediator)
    {
        var user = await UserHelper.GetUserByEmail(requestUserDto.Email, mediator);

        UserHelper.CheckUserVerification(user);
        UserHelper.VerifyPasswordHash(user, requestUserDto.Password);

        var userProfileDto = await MapUserToUserProfileDto(user);

        userProfileDto.ClasseDtos = await GetClassProfileDtos(user.Classes.ToList());

        var newToken = JwtHelper.CreateToken(user, _configuration);

        userProfileDto.VerificationToken = newToken;

        await mediator.Send(new UpdateUserVerificationTokenCommand(user.UserId, newToken));

        return ResponseHelper.GetOkResult(userProfileDto);
    }

    public async Task<IActionResult> VerifyEmail(string token, IMediator mediator)
    {
        var user = await UserHelper.GetUserByToken(token, mediator);

        var verifiedUser = await mediator.Send(new UpdateUserVerificationCommand(user.UserId));

        var newToken = JwtHelper.CreateToken(verifiedUser, _configuration);

        await mediator.Send(new UpdateUserVerificationTokenCommand(user.UserId, newToken));

        return ResponseHelper.GetOkResult(newToken);
    }

    public async Task<IActionResult> ForgotPassword(string userEmail, IMediator mediator)
    {
        var user = await UserHelper.GetUserByEmail(userEmail, mediator);

        var resetToken = JwtHelper.CreateToken(user, _configuration);

        await mediator.Send(new UpdateUserResetTokenCommand());

        return ResponseHelper.GetOkResult(resetToken);
    }

    public async Task<IActionResult> CreateUserAccount(Guid userId,
        CreateUserAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var user = await UserHelper.GetUserById(userId, mediator);

        UserHelper.CheckUserCreateAccountAbility(user);

        var userWithAccount = await GetUserWithAccount(userId, requestUserDto, mediator);

        var newToken = JwtHelper.CreateToken(userWithAccount, _configuration);

        var userWithNewToken = await mediator.Send(new UpdateUserVerificationTokenCommand(user.UserId, newToken));

        var userProfileDto = await MapUserToUserProfileDto(userWithNewToken);

        userProfileDto.ClasseDtos = await GetClassProfileDtos(userWithAccount.Classes.ToList());

        return ResponseHelper.GetOkResult(userProfileDto);
    }

    public async Task<IActionResult> GetUserProfile(Guid userId, IMediator mediator)
    {
        var user = await mediator.Send(new GetUserByIdQuery(userId));
        var userProfileDto = await MapUserToUserProfileDto(user);

        userProfileDto.ClasseDtos = await GetClassProfileDtos(user.Classes.ToList());

        return ResponseHelper.GetOkResult(userProfileDto);
    }

    private Task<UserProfileDto> MapUserToUserProfileDto(User user)
    {
        var userProfileDto = _mapper.Map<UserProfileDto>(user);
        userProfileDto.LanguageTitles = user.UserLanguages.Select(ul => ul.Language.Title).ToList();
        userProfileDto.DisciplineTitles = user.UserDisciplines.Select(ud => ud.Discipline.Title).ToList();
        userProfileDto.Institution = _mapper.Map<InstitutionDto>(user.Institution);
        userProfileDto.GradeNumbers = user.UserGrades.Select(ug => ug.Grade.GradeNumber).ToList();
        return Task.FromResult(userProfileDto);
    }

    private static async Task<List<ClassProfileDto>> GetClassProfileDtos(List<Class> classes)
    {
        return classes.Select(c => new ClassProfileDto()
            {
                ClassId = c.ClassId,
                Title = c.Title,
                UserFullName = c.User.FullName,
                UserRating = c.User.Rating,
                Grade = c.Grade.GradeNumber,
                Languages = c.ClassLanguages.Select(cl => cl.Language.Title).ToList(),
                Disciplines = c.ClassDisciplines.Select(cd => cd.Discipline.Title).ToList(),
                PhotoUrl = c.PhotoUrl!
            })
            .ToList();
    }

    public async Task<IActionResult> DeleteUser(Guid userId, IMediator mediator)
    {
        await mediator.Send(new DeleteUserCommand(userId));

        return new OkResult();
    }

    public async Task<IActionResult> DeleteAllUsers(IMediator mediator)
    {
        await mediator.Send(new DeleteAllUsersCommand());

        return new OkResult();
    }

    private static async Task<User> GetUserWithAccount(Guid userId, CreateUserAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var command = await GetCreateUserAccountCommand(userId, requestUserDto, mediator);
        return await mediator.Send(command);
    }

    private static async Task<CreateUserAccountCommand> GetCreateUserAccountCommand(Guid userId,
        CreateUserAccountRequestDto requestUserDto, IMediator mediator)
    {
        var country = await GetCountry(requestUserDto.CountryLocation, mediator);
        var city = await GetCity(country, requestUserDto.CityLocation, mediator);
        var institution = await GetInstitution(requestUserDto, mediator);
        var disciplines = await GetDisciplines(requestUserDto.Disciplines, mediator);
        var languages = await GetLanguages(requestUserDto.Languages, mediator);
        var grades = await GetGrades(requestUserDto.Grades, mediator);

        var query = new CreateUserAccountCommand
        {
            UserId = userId,
            FirstName = requestUserDto.FirstName,
            LastName = requestUserDto.LastName,
            IsATeacher = requestUserDto.IsATeacher,
            IsAnExpert = requestUserDto.IsAnExpert,
            CountryId = country.CountryId,
            CityId = city.CityId,
            InstitutionId = institution.InstitutionId,
            DisciplineIds = disciplines.Select(d => d.DisciplineId).ToList(),
            LanguageIds = languages.Select(l => l.LanguageId).ToList(),
            PhotoUrl = requestUserDto.PhotoUrl,
            GradeIds = grades.Select(g => g.GradeId).ToList()
        };

        return query;
    }

    private static async Task<Country> GetCountry(string countryTitle, IMediator mediator)
    {
        var query = new GetCountryByTitleQuery(countryTitle);
        return await mediator.Send(query);
    }

    private static async Task<City> GetCity(Country country, string cityTitle, IMediator mediator)
    {
        var query = new GetCityQuery()
        {
            CountryId = country.CountryId,
            Title = cityTitle
        };

        var city = await mediator.Send(query);
        return city;
    }

    private static async Task<Institution> GetInstitution(CreateUserAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var address = requestUserDto.InstitutionDto.Address;
        var institutionTitle = requestUserDto.InstitutionDto.Title;
        var institutionTypesTitles = requestUserDto.InstitutionDto.Types;

        var varGetQuery = new GetInstitutionQuery()
        {
            Address = address,
            InstitutionTitle = institutionTitle,
            Types = institutionTypesTitles
        };

        var institution = await mediator.Send(varGetQuery);

        return institution;
    }

    private static async Task<IEnumerable<Language>> GetLanguages(IEnumerable<string> languages, IMediator mediator)
    {
        var query = new GetLanguagesByTitlesQuery(languages);
        return await mediator.Send(query);
    }

    private static async Task<IEnumerable<Discipline>> GetDisciplines(IEnumerable<string> disciplines,
        IMediator mediator)
    {
        var query = new GetDisciplinesByTitlesQuery(disciplines);
        return await mediator.Send(query);
    }

    private static async Task<IEnumerable<Grade>> GetGrades(IEnumerable<int> grades, IMediator mediator)
    {
        var query = new GetGradesQuery(grades);
        return await mediator.Send(query);
    }
}