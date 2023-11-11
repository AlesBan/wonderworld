using MediatR;
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
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetAllUsers;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserById;
using Wonderworld.Application.Helpers;
using Wonderworld.Application.Helpers.TokenHelper;
using Wonderworld.Application.Helpers.UserHelper;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Infrastructure.Services.EmailHandlerService;

namespace Wonderworld.Infrastructure.Services.AccountServices;

public class UserAccountService : IUserAccountService
{
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserHelper _userHelper;
    private readonly IEmailHandlerService _emailHandlerService;

    public UserAccountService(ITokenHelper tokenHelper, IUserHelper userHelper,
        IEmailHandlerService emailHandlerService)
    {
        _tokenHelper = tokenHelper;
        _userHelper = userHelper;
        _emailHandlerService = emailHandlerService;
    }

    public async Task<IEnumerable<UserProfileDto>> GetAllUsers(IMediator mediator)
    {
        var users = await mediator.Send(new GetAllUsersQuery());
        var userProfileDtosTasks = users.Select(async u =>
            await _userHelper.MapUserToUserProfileDto(u));

        var userProfileDtos = await Task.WhenAll(userProfileDtosTasks);
        return userProfileDtos;
    }

    public async Task<string> RegisterUser(UserRegisterRequestDto requestUserDto, IMediator mediator)
    {
        var registeredUser = await mediator.Send(new RegisterUserCommand()
        {
            Email = requestUserDto.Email,
            Password = requestUserDto.Password,
        });

        await _emailHandlerService.SendVerificationEmail(registeredUser, registeredUser.VerificationCode);

        return registeredUser.AccessToken ?? string.Empty;
    }

    public async Task<string> LoginUser(UserLoginRequestDto requestUserDto, IMediator mediator)
    {
        var user = await _userHelper.GetUserByEmail(requestUserDto.Email, mediator);

        _userHelper.CheckUserVerification(user);
        PasswordHelper.VerifyPasswordHash(user, requestUserDto.Password);

        var userProfileDto = await _userHelper.MapUserToUserProfileDto(user);

        var newToken = _tokenHelper.CreateToken(user);

        userProfileDto.AccessToken = newToken;

        await mediator.Send(new UpdateUserVerificationTokenCommand(user.UserId, newToken));

        return userProfileDto.AccessToken;
    }

    public async Task<string> ConfirmEmail(Guid userId, string code, IMediator mediator)
    {
        var user = await _userHelper.GetUserById(userId, mediator);

        var verifiedUser = await mediator.Send(new UpdateUserVerificationCommand
        {
            UserId = user.UserId,
            VerificationCode = code
        });

        return verifiedUser.AccessToken;
    }

    public async Task<string> ForgotPassword(string userEmail, IMediator mediator)
    {
        var user = await _userHelper.GetUserByEmail(userEmail, mediator);

        var resetToken = _tokenHelper.CreateToken(user);

        await mediator.Send(new UpdateUserResetTokenCommand());

        return resetToken;
    }

    public async Task<UserProfileDto> CreateUserAccount(Guid userId,
        CreateUserAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var user = await _userHelper.GetUserById(userId, mediator);

        _userHelper.CheckUserVerification(user);
        var userWithAccount = await GetUserWithAccount(userId, requestUserDto, mediator);

        var userProfileDto = await _userHelper.MapUserToUserProfileDto(userWithAccount);

        return userProfileDto;
    }

    public async Task<UserProfileDto> GetUserProfile(Guid userId, IMediator mediator)
    {
        var user = await mediator.Send(new GetUserByIdQuery(userId));
        var userProfileDto = await _userHelper.MapUserToUserProfileDto(user);
        return userProfileDto;
    }

    public async Task DeleteUser(Guid userId, IMediator mediator)
    {
        await mediator.Send(new DeleteUserCommand(userId));
    }

    public async Task DeleteAllUsers(IMediator mediator)
    {
        await mediator.Send(new DeleteAllUsersCommand());
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