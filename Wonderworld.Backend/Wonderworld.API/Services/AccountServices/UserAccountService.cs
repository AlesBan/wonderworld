using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Models.Authentication;
using Wonderworld.Application.Dtos.AuthenticationDtos;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;
using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetCountryByTitle;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Queries.GetEsteblishment;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguages;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using static Wonderworld.API.Constants.AuthConstants;

namespace Wonderworld.API.Services.AccountServices;

public class UserAccountService : IUserAccountService
{
    private readonly ISharedLessonDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public UserAccountService(ISharedLessonDbContext context, IConfiguration configuration, IMapper mapper)
    {
        _context = context;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<IActionResult> RegisterUser(UserRegisterRequestDto requestUserDto, IMediator mediator)
    {
        var userValidationResult = await CheckRegisterUser(requestUserDto);

        switch (userValidationResult)
        {
            case BadRequestObjectResult badRequestResult:
                return badRequestResult;
            case OkObjectResult okResult:
                if (okResult.Value is not User value)
                {
                    return GetBadRequest(OkObjectResultIsNotUserAsExpectedErrorMessage);
                }

                var user = await mediator.Send(new RegisterUserCommand(value));

                var token = JwtHelper.CreateToken(user, _configuration);
                return GetAuthResultOk(token);
            default:
                return GetBadRequest(SomethingWentWrongErrorMessage);
        }
    }


    public async Task<IActionResult> LoginUser(UserLoginRequestDto requestUserDto, IMediator mediator)
    {
        var userValidationResult = await CheckLoginUser(requestUserDto);

        switch (userValidationResult)
        {
            case BadRequestObjectResult badRequestResult:
                return badRequestResult;
            case OkObjectResult okResult:

                if (okResult.Value is not User user)
                {
                    return GetBadRequest(OkObjectResultIsNotUserAsExpectedErrorMessage);
                }

                var token = JwtHelper.CreateToken(user, _configuration);

                return GetAuthResultOk(token);
            default:
                return GetBadRequest(SomethingWentWrongErrorMessage);
        }
    }

    public async Task<IActionResult> CreateUserAccount(Guid userId, UserCreateAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var userValidationResult = await CheckUserCreateAccount(userId, requestUserDto, mediator);

        switch (userValidationResult)
        {
            case BadRequestObjectResult badRequestResult:
                return badRequestResult;
            case OkObjectResult okResult:

                if (okResult.Value is not User user)
                {
                    return GetBadRequest(OkObjectResultIsNotUserAsExpectedErrorMessage);
                }

                var country = await GetCountry(requestUserDto.CountryLocation, mediator);
                var city = await GetCity(requestUserDto.CountryLocation, requestUserDto.CityLocation, mediator);
                var establishment = await GetEstablishment(requestUserDto, mediator);
                var disciplines = await GetDisciplines(requestUserDto.Disciplines, mediator);
                var languages = await GetLanguages(requestUserDto.Languages, mediator);
                var query = new CreateUserAccountCommand
                {
                    User = user,
                    FirstName = requestUserDto.FirstName,
                    LastName = requestUserDto.LastName,
                    IsATeacher = requestUserDto.IsATeacher,
                    IsAnExpert = requestUserDto.IsAnExpert,
                    Country = country,
                    City = city,
                    Establishment = establishment,
                    Disciplines = disciplines,
                    Languages = languages,
                    PhotoUrl = requestUserDto.PhotoUrl,
                };

                await mediator.Send(query);

                return new OkObjectResult(user);
            default:
                return GetBadRequest(SomethingWentWrongErrorMessage);
        }
    }


    public Task<IActionResult> DeleteUser(User user, IMediator mediator)
    {
        throw new NotImplementedException();
    }


    private async Task<IActionResult> CheckUserCreateAccount(Guid userId, UserCreateAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var existingUser = await GetUserById(userId, mediator);

        if (existingUser == null)
        {
            return GetBadRequest(UserNotFoundErrorMessage);
        }

        return new OkObjectResult(existingUser);
    }

    private async Task<IActionResult> CheckLoginUser(UserLoginRequestDto requestUserDto)
    {
        var existingUser = await GetUserByEmail(requestUserDto.Email);

        if (existingUser == null)
        {
            return GetBadRequest(UserNotFoundErrorMessage);
        }

        var isCorrectPassword = existingUser.Password == requestUserDto.Password;

        if (!isCorrectPassword)
        {
            return GetBadRequest(InvalidCredentialsErrorMessage);
        }

        return new OkObjectResult(existingUser);
    }

    private async Task<IActionResult> CheckRegisterUser(UserRegisterRequestDto requestUserDto)
    {
        var existingUser = await GetUserByEmail(requestUserDto.Email);

        if (existingUser != null)
        {
            return GetBadRequest(UserExistsErrorMessage);
        }

        var user = _mapper.Map<User>(requestUserDto);

        return new OkObjectResult(user);
    }

    private async Task<User?> GetUserByEmail(string userEmail)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == userEmail);

        return user;
    }

    private static async Task<User?> GetUserById(Guid userId, IMediator mediator)
    {
        var query = new GetUserCommand(userId);

        return await mediator.Send(query);
    }

    private static Task<Country> GetCountry(string countryTitle, IMediator mediator)
    {
        var query = new GetCountryByTitleCommand()
        {
            Title = countryTitle
        };
        return mediator.Send(query);
    }

    private static Task<City> GetCity(string countryTitle, string cityTitle, IMediator mediator)
    {
        var query = new GetCityCommand()
        {
            CountryTitle = countryTitle,
            Title = cityTitle
        };
        return mediator.Send(query);
    }

    private static async Task<Establishment> GetEstablishment(UserCreateAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var countryTitle = requestUserDto.EstablishmentDto.CountryTitle;
        var cityTitle = requestUserDto.EstablishmentDto.CityTitle;
        var establishmentTitle = requestUserDto.EstablishmentDto.Title;

        var establishmentCountry = await GetCountry(countryTitle, mediator);
        var establishmentCity = await GetCity(countryTitle, cityTitle, mediator);

        var query = new GetEstablishmentCommand()
        {
            Title = establishmentTitle,
            Country = establishmentCountry,
            City = establishmentCity
        };

        return await mediator.Send(query);
    }

    private async Task<IEnumerable<Language>> GetLanguages(IEnumerable<string> languages, IMediator mediator)
    {
        var query = new GetLanguagesCommand()
        {
            LanguageTitles = languages
        };

        return await mediator.Send(query);
    }

    private static async Task<IEnumerable<Discipline>> GetDisciplines(IEnumerable<string> disciplines,
        IMediator mediator)
    {
        var query = new GetDisciplinesCommand()
        {
            DisciplineTitles = disciplines
        };

        return await mediator.Send(query);
    }

    private static BadRequestObjectResult GetBadRequest(string message)
    {
        return new BadRequestObjectResult(new AuthResult
        {
            Result = false,
            Errors = new List<string> { message }
        });
    }

    private static OkObjectResult GetAuthResultOk(string token)
    {
        return new OkObjectResult(new AuthResult
        {
            Result = true,
            Token = token
        });
    }
}