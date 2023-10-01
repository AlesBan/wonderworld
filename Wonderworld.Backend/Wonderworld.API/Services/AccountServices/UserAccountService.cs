using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Models.Authentication;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Dtos.AuthenticationDtos;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Commands.CreateCity;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;
using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetCountryByTitle;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Commands.CreateEstablishment;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguages;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.DeleteUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserByEmail;
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
    public UserAccountService(ISharedLessonDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<IActionResult> RegisterUser(UserRegisterRequestDto requestUserDto, IMediator mediator)
    {
        try
        {
            var user = await mediator.Send(new RegisterUserCommand(requestUserDto));
            var token = JwtHelper.CreateToken(user, _configuration);
            return GetAuthResultOk(token);
        }
        catch (UserAlreadyExistsException e)
        {
            return GetBadRequest(e.Message);
        }
    }

    public async Task<IActionResult> LoginUser(UserLoginRequestDto requestUserDto, IMediator mediator)
    {
        try
        {
            var user = await GetUser(requestUserDto.Email, mediator);
            CheckLoginUserCredentials(user, requestUserDto.Password);

            var token = JwtHelper.CreateToken(user, _configuration);

            return GetAuthResultOk(token);
        }
        catch (UserNotFoundException e)
        {
            return GetBadRequest(e.Message);
        }
        catch (InvalidInputCredentialsException e)
        {
            return GetBadRequest(e.Message);
        }
    }

    public async Task<IActionResult> CreateUserAccount(Guid userId, UserCreateAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        try
        {
            var user = await GetUser(userId, mediator);

            CheckUserCreateAccountAbility(user);

            var userWithAccount = GetUserWithAccount(userId, requestUserDto, mediator);

            return new OkObjectResult(userWithAccount);
        }
        catch (UserNotFoundException e)
        {
            return GetBadRequest(e.Message);
        }
        catch (UserAlreadyHasAccountException e)
        {
            return GetBadRequest(e.Message);
        }
    }

    public async Task<IActionResult> DeleteUser(Guid userId, IMediator mediator)
    {
        try
        {
            await mediator.Send(new DeleteUserCommand(userId));
        }
        catch (NotFoundException)
        {
            return GetBadRequest(UserNotFoundErrorMessage);
        }

        return new OkResult();
    }

    private static async Task<User> GetUser(Guid userId, IMediator mediator)
    {
        var user = await mediator.Send(new GetUserByIdQuery(userId));

        return user;
    }

    private static async Task<User> GetUser(string email, IMediator mediator)
    {
        var user = await mediator.Send(new GetUserByEmailQuery(email));

        return user;
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

    private async Task<User> GetUserWithAccount(Guid userId, UserCreateAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var command = await GetCreateUserAccountCommand(userId, requestUserDto, mediator);
        return await mediator.Send(command);
    }

    private async Task<CreateUserAccountCommand> GetCreateUserAccountCommand(Guid userId,
        UserCreateAccountRequestDto requestUserDto, IMediator mediator)
    {
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

        return query;
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

    private static async Task<IEnumerable<Language>> GetLanguages(IEnumerable<string> languages, IMediator mediator)
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