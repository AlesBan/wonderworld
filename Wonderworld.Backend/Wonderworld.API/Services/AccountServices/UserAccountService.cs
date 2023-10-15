using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Helpers;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Dtos.InstitutionDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;
using Wonderworld.Application.Dtos.UserDtos.CreateAccountDtos;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;
using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetCountryByTitle;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplinesByIds;
using Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries.GetGrades;
using Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Queries.GetEstablishment;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByIds;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByTitles;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.DeleteUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Services.AccountServices;

public class UserAccountService : IUserAccountService
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public UserAccountService(IConfiguration configuration, IMapper mapper)
    {
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<IActionResult> RegisterUser(UserRegisterRequestDto requestUserDto, IMediator mediator)
    {
        var user = await mediator.Send(new RegisterUserCommand(requestUserDto));
        var token = JwtHelper.CreateToken(user, _configuration);
        return ResponseHelper.GetAuthResultOk(token);
    }

    public async Task<IActionResult> LoginUser(UserLoginRequestDto requestUserDto, IMediator mediator)
    {
        var user = await UserHelper.GetUser(requestUserDto.Email, mediator);
        CheckLoginUserCredentials(user, requestUserDto.Password);

        var token = JwtHelper.CreateToken(user, _configuration);

        return ResponseHelper.GetAuthResultOk(token);
    }

    public async Task<IActionResult> CreateUserAccount(Guid userId, CreateUserAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var user = await UserHelper.GetUser(userId, mediator);

        CheckUserCreateAccountAbility(user);

        var userWithAccount = await GetUserWithAccount(userId, requestUserDto, mediator);
        var userProfileDto = _mapper.Map<UserProfileDto>(userWithAccount);

        var languageIds = userWithAccount.UserLanguages
            .Select(ul => ul.LanguageId).AsEnumerable();
        var disciplineIds = userWithAccount.UserDisciplines
            .Select(ud => ud.DisciplineId).ToList();
        var institution = userWithAccount.Institution;
        
        var languages = await mediator.Send(new GetLanguagesByIdsCommand(languageIds));
        var disciplines = await mediator.Send(new GetDisciplinesByIdsCommand(disciplineIds));

        userProfileDto.Languages = languages.Select(l => l.Title).ToList();
        userProfileDto.Disciplines = disciplines.Select(d => d.Title).ToList();
        userProfileDto.Institution = _mapper.Map<InstitutionDto>(institution);

        return ResponseHelper.GetOkResult(userProfileDto);
    }

    public async Task<IActionResult> GetUserProfile(Guid userId, IMediator mediator)
    {
        var user = await mediator.Send(new GetUserByIdQuery(userId));
        
        var userProfileDto = _mapper.Map<UserProfileDto>(user);
        var languageIds = user.UserLanguages
            .Select(ul => ul.LanguageId).AsEnumerable();
        var disciplineIds = user.UserDisciplines
            .Select(ud => ud.DisciplineId).ToList();
        var institution = user.Institution;
        
        var languages = await mediator.Send(new GetLanguagesByIdsCommand(languageIds));
        var disciplines = await mediator.Send(new GetDisciplinesByIdsCommand(disciplineIds));

        userProfileDto.Languages = languages.Select(l => l.Title).ToList();
        userProfileDto.Disciplines = disciplines.Select(d => d.Title).ToList();
        userProfileDto.Institution = _mapper.Map<InstitutionDto>(institution);
        
        return new OkObjectResult(userProfileDto);
    }

    public async Task<IActionResult> DeleteUser(Guid userId, IMediator mediator)
    {
        await mediator.Send(new DeleteUserCommand(userId));

        return new OkResult();
    }


    private static void CheckUserCreateAccountAbility(User user)
    {
        if (user.IsCreatedAccount)
        {
            throw new UserAlreadyHasAccountException(user.UserId);
        }
    }

    private static void CheckLoginUserCredentials(User user, string password)
    {
        var isCorrectPassword = user.Password == password;

        if (!isCorrectPassword)
        {
            throw new InvalidInputCredentialsException();
        }
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