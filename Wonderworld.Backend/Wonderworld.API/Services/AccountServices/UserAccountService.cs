using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Helpers;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Commands.CreateCity;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;
using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetCountryByTitle;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Commands.CreateInstitution;
using Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Queries.GetEstablishment;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguages;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.DeleteUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

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
        return ResponseHelper.GetOkResult(userProfileDto);
    }

    public async Task<IActionResult> GetUserProfile(Guid userId, IMediator mediator)
    {
        var user = await mediator.Send(new GetUserByIdQuery(userId));
        var userProfileDto = _mapper.Map<UserProfileDto>(user);
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

    private async Task<User> GetUserWithAccount(Guid userId, CreateUserAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var command = await GetCreateUserAccountCommand(userId, requestUserDto, mediator);
        return await mediator.Send(command);
    }

    private async Task<CreateUserAccountCommand> GetCreateUserAccountCommand(Guid userId,
        CreateUserAccountRequestDto requestUserDto, IMediator mediator)
    {
        var country = await GetCountry(requestUserDto.CountryLocation, mediator);
        var city = await GetCity(country, requestUserDto.CityLocation, mediator);
        var establishment = await GetInstitution(requestUserDto, mediator);
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
            Institution = establishment,
            Disciplines = disciplines,
            Languages = languages,
            PhotoUrl = requestUserDto.PhotoUrl,
        };

        return query;
    }

    private static async Task<Country> GetCountry(string countryTitle, IMediator mediator)
    {
        var query = new GetCountryByTitleQuery()
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

    private async Task<Institution> GetInstitution(CreateUserAccountRequestDto requestUserDto,
        IMediator mediator)
    {
        var address = requestUserDto.InstitutionDto.Address;
        var establishmentTitle = requestUserDto.InstitutionDto.Title;
        var establishmentTypesTitles = requestUserDto.InstitutionDto.Types;
        var establishmentTypes = _context.InstitutionTypes.ToList()
            .Where(et =>
                establishmentTypesTitles.Contains(et.Title));

        var varGetQuery = new GetInstitutionQuery()
        {
            Address = address,
            InstitutionTitle = establishmentTitle,
            Types = establishmentTypes.Select(e => e.Title).ToList()
        };

        Institution establishment;
        try
        {
            establishment = await mediator.Send(varGetQuery);
        }
        catch
        {
            var createQuery = new CreateInstitutionCommand()
            {
                Address = address,
                InstitutionTitle = establishmentTitle
            };
            establishment = await mediator.Send(createQuery);
        }

        return establishment;
    }

    private static async Task<IEnumerable<Language>> GetLanguages(IEnumerable<string> languages, IMediator mediator)
    {
        var query = new GetLanguagesQuery(languages);
        return await mediator.Send(query);
    }

    private static async Task<IEnumerable<Discipline>> GetDisciplines(IEnumerable<string> disciplines,
        IMediator mediator)
    {
        var query = new GetDisciplinesQuery(disciplines);
        return await mediator.Send(query);
    }
}