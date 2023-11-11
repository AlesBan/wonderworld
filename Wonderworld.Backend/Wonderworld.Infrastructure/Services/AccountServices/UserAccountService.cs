using MediatR;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Dtos.UserDtos.Authentication;
using Wonderworld.Application.Dtos.UserDtos.CreateAccount;
using Wonderworld.Application.Dtos.UserDtos.Login;
using Wonderworld.Application.Dtos.UserDtos.ResetPassword;
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
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPasswordHash;
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

    public async Task<LoginResponseDto> RegisterUser(UserRegisterRequestDto requestUserDto, IMediator mediator)
    {
        var registeredUser = await mediator.Send(new RegisterUserCommand()
        {
            Email = requestUserDto.Email,
            Password = requestUserDto.Password,
        });

        await _emailHandlerService.SendVerificationEmail(registeredUser.Email, registeredUser.VerificationCode);

        var loginResponseDto = new LoginResponseDto
        {
            AccessToken = registeredUser.AccessToken,
            IsCreatedAccount = false
        };
        return loginResponseDto;
    }

    public async Task<LoginResponseDto> LoginUser(UserLoginRequestDto requestUserDto, IMediator mediator)
    {
        var user = await _userHelper.GetUserByEmail(requestUserDto.Email, mediator);

        _userHelper.CheckUserVerification(user);
        PasswordHelper.VerifyPasswordHash(user, requestUserDto.Password);

        var userProfileDto = await _userHelper.MapUserToUserProfileDto(user);

        var newToken = _tokenHelper.CreateToken(user);

        userProfileDto.AccessToken = newToken;

        await mediator.Send(new UpdateUserAccessTokenCommand(user.UserId, newToken));

        var loginResponseDto = new LoginResponseDto
        {
            AccessToken = userProfileDto.AccessToken,
            IsCreatedAccount = userProfileDto.IsCreateAccount
        };
        return loginResponseDto;
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

        var updatedUser = await mediator.Send(new UpdateUserResetPasswordInfoCommand(user.UserId));

        await _emailHandlerService.SendResetPasswordEmail(user.Email, updatedUser.PasswordResetCode);
        return updatedUser.PasswordResetToken;
    }

    public async Task CheckResetPasswordCode(Guid userId, string code, IMediator mediator)
    {
        var user = await _userHelper.GetUserById(userId, mediator);
        _userHelper.CheckResetTokenExpiration(user);
        _userHelper.CheckResetPasswordCode(user, code);
    }

    public async Task<LoginResponseDto> ResetPassword(Guid userId, ResetPasswordRequestDto requestDto, IMediator mediator)
    {
        var user = await _userHelper.GetUserById(userId, mediator);
        _userHelper.CheckResetTokenExpiration(user);
        await mediator
            .Send(new UpdateUserPasswordCommand
            {
                UserId = user.UserId,
                Password = requestDto.Password
            });
        var newToken = _tokenHelper.CreateToken(user);

        user.AccessToken = newToken;
        await mediator.Send(new UpdateUserAccessTokenCommand(user.UserId, newToken));

        var loginResponseDtoDto = new LoginResponseDto
        {
            AccessToken = newToken,
            IsCreatedAccount = user.IsCreatedAccount
        };
        return loginResponseDtoDto;
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