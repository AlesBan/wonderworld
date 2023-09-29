using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Models.Authentication;
using Wonderworld.Application.Dtos.AuthenticationDtos;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Commands.CreateCity;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;
using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetCountryByTitle;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Commands.CreateEstablishment;
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
using GetEstablishmentCommand =
    Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Queries.GetEstablishmentByAddress.
    GetEstablishmentCommand;

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
        var userValidationResult = await CheckUserCreateAccount(userId, mediator);

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
                var city = await GetCity(country, requestUserDto.CityLocation, mediator);
                var establishment = await GetEstablishment(requestUserDto, mediator);
                var disciplines = await GetDisciplines(requestUserDto.Disciplines, mediator);
                var languages = await GetLanguages(requestUserDto.Languages, mediator);
                var query = new CreateUserAccountCommand
                {
                    UserId = userId,
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

                var userWithAccount = await mediator.Send(query);

                return new OkObjectResult(userWithAccount);
            default:
                return GetBadRequest(SomethingWentWrongErrorMessage);
        }
    }


    public async Task<IActionResult> DeleteUser(User user, IMediator mediator)
    {
        return new OkObjectResult(user);
    }


    private static async Task<IActionResult> CheckUserCreateAccount(Guid userId,
        IMediator mediator)
    {
        var existingUser = await GetUserById(userId, mediator);

        if (existingUser == null)
        {
            return GetBadRequest(UserNotFoundErrorMessage);
        }

        if (existingUser.IsCreatedAccount)
        {
            return GetBadRequest(UserAlreadyCreatedAccountErrorMessage);
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

    private static async Task<Country> GetCountry(string countryTitle, IMediator mediator)
    {
        var query = new GetCountryByTitleCommand()
        {
            Title = countryTitle
        };
        return await mediator.Send(query);
    }

    private static async Task<City> GetCity(Country country, string cityTitle, IMediator mediator)
    {
        var query = new GetCityQuery()
        {
            CountryId = country.CountryId,
            Title = cityTitle
        };

        try
        {
            var city = await mediator.Send(query);
            return city;
        }
        catch
        {
            var createQuery = new CreateCityCommand()
            {
                CountryId = country.CountryId,
                Title = cityTitle
            };
            return await mediator.Send(createQuery);
        }
    }

    private async Task<Establishment> GetEstablishment(UserCreateAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var address = requestUserDto.EstablishmentDto.Address;
        var establishmentTitle = requestUserDto.EstablishmentDto.Title;
        var establishmentTypesTitles = requestUserDto.EstablishmentDto.Types;
        var establishmentTypes = _context.EstablishmentTypes.ToList()
            .Where(et =>
                establishmentTypesTitles.Contains(et.Title));

        var varGetQuery = new GetEstablishmentCommand()
        {
            Address = address,
            Title = establishmentTitle,
            Types = establishmentTypes.Select(e => e.EstablishmentTypeId).ToList()
        };

        Establishment establishment;
        try
        {
            establishment = await mediator.Send(varGetQuery);
        }
        catch
        {
            var createQuery = new CreateEstablishmentCommand()
            {
                Address = address,
                Title = establishmentTitle
            };
            establishment = await mediator.Send(createQuery);
        }

        return establishment;
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