// using API.UnitTests.Common;
// using Application.UnitTests.Common;
// using AutoMapper;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using Moq;
// using Wonderworld.API.Models;
// using Wonderworld.API.Services.AccountServices;
// using Wonderworld.Application.Common.Exceptions.User;
// using Wonderworld.Application.Dtos.CreateAccountDtos;
// using Wonderworld.Application.Dtos.InstitutionDtos;
// using Wonderworld.Application.Dtos.UserDtos;
// using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;
// using Wonderworld.Application.Dtos.UserDtos.CreateAccountDtos;
// using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.CreateUserDisciplines;
// using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.CreateUserLanguages;
// using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;
// using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetCountryByTitle;
// using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplinesByTitles;
// using Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Commands.CreateInstitution;
// using Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Queries.GetEstablishment;
// using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByTitles;
// using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;
// using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;
// using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;
// using Wonderworld.Domain.Entities.Main;
// using Xunit;
//
// namespace API.UnitTests.Services;
//
// public class UserAccountServiceTests : TestCommonBase, IClassFixture<TestSetup>
// {
//     private readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
//         .SetBasePath(Directory.GetCurrentDirectory())
//         .AddJsonFile(
//             path: "appsettings.test.json",
//             optional: false,
//             reloadOnChange: true)
//         .Build();
//
//     [Fact]
//     public async Task RegisterUser_ValidRequest_ReturnsOkResultWithToken()
//     {
//         // Arrange
//         var requestUserDto = new UserRegisterRequestDto
//         {
//             Email = "exampleEmail@gmail.com",
//             Password = "exampleEmail",
//         };
//
//         var mediatorMock = new Mock<IMediator>();
//         var user = new User();
//         mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(user);
//
//         var mapper = new Mock<IMapper>();
//         // var service = new UserAccountService(_configuration, mapper.Object);
//
//         // Act
//         var result = await service.RegisterUser(requestUserDto, mediatorMock.Object);
//
//         // Assert
//         Assert.IsType<OkObjectResult>(result);
//     }
//
//     [Fact]
//     public async Task RegisterUser_InvalidRequest_ReturnsBadRequestResult()
//     {
//         // Arrange
//         var requestUserDto = new UserRegisterRequestDto
//         {
//             Email = "exampleEmail@gmail.com",
//             Password = "exampleEmail",
//         };
//
//         var mediatorMock = new Mock<IMediator>();
//         var user = new User()
//         {
//             Email = "exampleEmail",
//         };
//         mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(),
//             It.IsAny<CancellationToken>())).ThrowsAsync(new UserAlreadyExistsException(user.Email));
//
//         var mapper = new Mock<IMapper>();
//         var service = new UserAccountService(_configuration, mapper.Object);
//
//         // Act
//         // Assert
//         await Assert.ThrowsAsync<UserAlreadyExistsException>(async () =>
//             await service.RegisterUser(requestUserDto, mediatorMock.Object));
//     }
//
//     [Fact]
//     public async Task CreateUserAccount_ValidRequest_ReturnsOkResult()
//     {
//         // Arrange
//         var mediatorMock = new Mock<IMediator>();
//
//         var userId = Context.Users.FirstOrDefault(u =>
//             u.UserId == SharedLessonDbContextFactory.UserRegisteredId)!.UserId;
//         var user = Context.Users.FirstOrDefault(u =>
//             u.UserId == userId);
//         mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(user!);
//
//         var firstName = "CreateAccountFirstName";
//         var lastName = "CreateAccountLastName";
//         var isATeacher = true;
//         var isAnExpert = false;
//         var cityLocation = "CreateAccountCity";
//         var countryLocation = "CreateAccountCountry";
//         var institutionDto = new InstitutionDto
//         {
//             Types = new List<string>() { "School" },
//             Address = "CreateAccountInstitutionAddress",
//             Title = "CreateAccountInstitution"
//         };
//         var disciplineTitles = new List<string>() { "Chemistry" };
//         var languageTitles = new List<string>() { "English" };
//         ;
//         var photoUrl = "null";
//
//         var createCountryByTitleQuery = new GetCountryByTitleQuery(countryLocation);
//         var createCountryByTitleQueryHandler = new GetCountryByTitleQueryHandler(Context);
//         var countryCreate =
//             await createCountryByTitleQueryHandler.Handle(createCountryByTitleQuery, CancellationToken.None);
//         mediatorMock.Setup(m => m.Send(It.IsAny<GetCountryByTitleQuery>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(countryCreate);
//
//         var getCountryByTitleQuery = new GetCountryByTitleQuery(countryLocation);
//         var getCountryByTitleQueryHandler = new GetCountryByTitleQueryHandler(Context);
//         var countryGet = await getCountryByTitleQueryHandler.Handle(getCountryByTitleQuery, CancellationToken.None);
//         mediatorMock.Setup(m => m.Send(It.IsAny<GetCountryByTitleQuery>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(countryGet);
//
//         var createCityQuery = new GetCityQuery
//         {
//             Title = cityLocation,
//             CountryId = countryGet.CountryId
//         };
//         var createCityQueryHandler = new GetCityQueryHandler(Context);
//         var cityCreate = await createCityQueryHandler.Handle(createCityQuery, CancellationToken.None);
//         mediatorMock.Setup(m => m.Send(It.IsAny<GetCityQuery>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(cityCreate);
//
//         var getCityQuery = new GetCityQuery
//         {
//             Title = cityLocation,
//             CountryId = countryGet.CountryId
//         };
//         var getCityQueryHandler = new GetCityQueryHandler(Context);
//         var city = await getCityQueryHandler.Handle(getCityQuery, CancellationToken.None);
//         mediatorMock.Setup(m => m.Send(It.IsAny<GetCityQuery>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(city);
//
//         var createInstitutionQuery = new CreateInstitutionCommand()
//         {
//             Address = institutionDto.Address,
//             InstitutionTitle = institutionDto.Title,
//             Types = institutionDto.Types
//         };
//         var createInstitutionQueryHandler = new CreateInstitutionCommandHandler(Context);
//         var institutionCreate =
//             await createInstitutionQueryHandler.Handle(createInstitutionQuery, CancellationToken.None);
//         mediatorMock.Setup(m => m.Send(It.IsAny<CreateInstitutionCommand>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(institutionCreate);
//
//         var getInstitutionQuery = new GetInstitutionQuery
//         {
//             Address = institutionDto.Address,
//             InstitutionTitle = institutionDto.Title,
//             Types = institutionDto.Types
//         };
//         var getInstitutionQueryHandler = new GetInstitutionQueryHandler(Context, mediatorMock.Object);
//         var institution = await getInstitutionQueryHandler.Handle(getInstitutionQuery, CancellationToken.None);
//         mediatorMock.Setup(m => m.Send(It.IsAny<GetInstitutionQuery>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(institution);
//
//         var getDisciplinesQuery = new GetDisciplinesByTitlesQuery(disciplineTitles);
//         var getDisciplinesQueryHandler = new GetDisciplinesByTitlesQueryHandler(Context);
//         var disciplines = await getDisciplinesQueryHandler.Handle(getDisciplinesQuery, CancellationToken.None);
//         mediatorMock.Setup(m => m.Send(It.IsAny<GetDisciplinesByTitlesQuery>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(disciplines);
//         
//         var getLanguagesQuery = new GetLanguagesByTitlesQuery(languageTitles);
//         var getLanguagesQueryHandler = new GetLanguagesByTitlesQueryHandler(Context);
//         var languages = await getLanguagesQueryHandler.Handle(getLanguagesQuery, CancellationToken.None);
//         mediatorMock.Setup(m => m.Send(It.IsAny<GetLanguagesByTitlesQuery>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(languages);
//         
//         var createUserAccountCommand = new CreateUserAccountCommand
//         {
//             UserId = userId,
//             FirstName = firstName,
//             LastName = lastName,
//             IsATeacher = isATeacher,
//             IsAnExpert = isAnExpert,
//             CountryId = countryGet.CountryId,
//             CityId = city.CityId,
//             InstitutionId = institution.InstitutionId,
//             DisciplineIds = disciplines.Select(d => d.DisciplineId).ToList(),
//             LanguageIds = languages.Select(l => l.LanguageId).ToList(),
//             PhotoUrl = photoUrl
//         };
//         var createUserAccountCommandHandler = new CreateUserAccountCommandHandler(Context);
//         var userWithAccount = await
//             createUserAccountCommandHandler.Handle(createUserAccountCommand, CancellationToken.None);
//         mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserAccountCommand>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(userWithAccount);
//         
//         var createUserDisciplinesCommand = new CreateUserDisciplinesCommand
//         {
//             UserId = userId,
//             DisciplineIds = disciplines.Select(d => d.DisciplineId).ToList()
//         };
//         var createUserDisciplinesCommandHandler = new CreateUserDisciplinesCommandHandler(Context);
//         var handlerResultCreateUserDisciplines = await
//             createUserDisciplinesCommandHandler.Handle(createUserDisciplinesCommand, CancellationToken.None);
//         mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserDisciplinesCommand>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(handlerResultCreateUserDisciplines);
//
//         var createUserLanguagesCommand = new CreateUserLanguagesCommand
//         {
//             UserId = userId,
//             LanguageIds = languages.Select(l => l.LanguageId).ToList()
//         };
//         var createUserLanguagesCommandHandler = new CreateUserLanguagesCommandHandler(Context);
//         var handlerResultCreateUserLanguages = await
//             createUserLanguagesCommandHandler.Handle(createUserLanguagesCommand, CancellationToken.None);
//         mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserLanguagesCommand>(),
//             It.IsAny<CancellationToken>())).ReturnsAsync(handlerResultCreateUserLanguages);
//
//         var requestUserDto = new CreateUserAccountRequestDto
//         {
//             FirstName = firstName,
//             LastName = lastName,
//             IsATeacher = isATeacher,
//             IsAnExpert = isAnExpert,
//             CityLocation = cityLocation,
//             CountryLocation = countryLocation,
//             InstitutionDto = institutionDto,
//             Disciplines = disciplineTitles,
//             Languages = languageTitles,
//             PhotoUrl = photoUrl
//         };
//
//         var mapper = new Mock<IMapper>();
//         var service = new UserAccountService(_configuration, mapper.Object);
//
//         // Act
//         var result = await service.CreateUserAccount(userId, requestUserDto, mediatorMock.Object);
//
//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result);
//         var response = Assert.IsType<ResponseResult>(okResult.Value);
//         var userProfileDto = Assert.IsType<UserProfileDto>(response.Value);
//         Assert.Equal(firstName, userProfileDto.FirstName);
//         Assert.Equal(lastName, userProfileDto.LastName);
//         Assert.Equal(isATeacher, userProfileDto.IsATeacher);
//         Assert.Equal(isAnExpert, userProfileDto.IsAnExpert);
//         Assert.Equal(cityLocation, userProfileDto.CityTitle);
//         Assert.Equal(countryLocation, userProfileDto.CountryTitle);
//         Assert.Equal(institutionDto.Title, userProfileDto.Institution.Title);
//         Assert.Equal(institutionDto.Address, userProfileDto.Institution.Address);
//         Assert.Equal(disciplineTitles, userProfileDto.DisciplineTitles);
//         Assert.Equal(languageTitles, userProfileDto.LanguageTitles);
//         Assert.Equal(photoUrl, userProfileDto.PhotoUrl);
//     }
// }