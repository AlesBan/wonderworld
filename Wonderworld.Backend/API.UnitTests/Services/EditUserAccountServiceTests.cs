using Application.UnitTests.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Wonderworld.API.Services.EditUserData;
using Wonderworld.API.Services.EditUserServices;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Dtos.InstitutionDtos;
using Wonderworld.Application.Dtos.UpdateDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Dtos.UserDtos.UpdateDtos;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.CreateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.CreateUserGrade;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.UpdateUserGrades;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.CreateUserLanguages;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.UpdateUserLanguages;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplinesByTitles;
using Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries.GetGrades;
using Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Commands.CreateInstitution;
using Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Queries.GetEstablishment;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByTitles;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdatePersonalInfo;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateProfessionalInfo;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserEmail;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserInstitution;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPassword;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.Enums.EntityTypes;
using Xunit;

namespace API.UnitTests.Services;

public class EditUserAccountServiceTests : TestCommonBase
{
    [Fact]
    public async Task EditUserPersonalInfoAsync_ReturnsOkObjectResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();

        var userId = SharedLessonDbContextFactory.UserAId;
        var user = Context.Users.FirstOrDefault(u =>
            u.UserId == userId);

        mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(user!);
        user!.IsATeacher = true;
        user.IsAnExpert = true;
        user.FirstName = "NewName";
        user.LastName = "NewLastName";
        user.Description = "NewDescription";
        user.City = new City
        {
            Title = "NewCity",
            CountryId = SharedLessonDbContextFactory.CityAId,
        };
        user.Country = new Country()
        {
            Title = "NewCountry",
            CountryId = SharedLessonDbContextFactory.CountryAId,
        };
        user.Description = "NewDescription";

        mediatorMock.Setup(m => m.Send(It.IsAny<UpdatePersonalInfoCommand>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(user);

        var requestUserDto = new UpdatePersonalInfoRequestDto
        {
            IsATeacher = true,
            IsAnExpert = true,
            FirstName = "NewName",
            LastName = "NewLastName",
            CityTitle = "NewCity",
            CountryTitle = "NewCountry",
            Description = "NewDescription"
        };

        var confMapper = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<User, UserProfileDto>();
                cfg.CreateMap<Institution, InstitutionDto>();
            });

        var mapper = confMapper.CreateMapper();

        var service = new EditUserAccountService(mapper);

        // Act
        var result = await service.EditUserPersonalInfoAsync(userId, requestUserDto, mediatorMock.Object);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var userProfileDto = Assert.IsType<UserProfileDto>(okResult.Value);

        Assert.Equal("NewName", userProfileDto.FirstName);
        Assert.Equal("NewLastName", userProfileDto.LastName);
        Assert.Equal("NewCity", userProfileDto.CityTitle);
        Assert.Equal("NewCountry", userProfileDto.CountryTitle);
        Assert.Equal("NewDescription", userProfileDto.Description);
    }

    [Fact]
    public async Task EditUserPersonalInfoAsync_ReturnsBadRequestObjectResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();

        var userId = Guid.NewGuid();
        var user = new User()
        {
            UserId = userId,
            Email = "Email",
            Password = "Password"
        };

        mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(),
            It.IsAny<CancellationToken>())).ThrowsAsync(new UserNotFoundException(userId));
        user.IsATeacher = true;
        user.IsAnExpert = true;
        user.FirstName = "NewName";
        user.LastName = "NewLastName";
        user.Description = "NewDescription";
        user.City = new City
        {
            Title = "NewCity",
            CountryId = SharedLessonDbContextFactory.CityAId,
        };
        user.Country = new Country()
        {
            Title = "NewCountry",
            CountryId = SharedLessonDbContextFactory.CountryAId,
        };
        user.Description = "NewDescription";

        mediatorMock.Setup(m => m.Send(It.IsAny<UpdatePersonalInfoCommand>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(user);

        var requestUserDto = new UpdatePersonalInfoRequestDto
        {
            IsATeacher = true,
            IsAnExpert = true,
            FirstName = "NewName",
            LastName = "NewLastName",
            CityTitle = "NewCity",
            CountryTitle = "NewCountry",
            Description = "NewDescription"
        };

        var confMapper = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<User, UserProfileDto>();
                cfg.CreateMap<Institution, InstitutionDto>();
            });

        var mapper = confMapper.CreateMapper();

        var service = new EditUserAccountService(mapper);

        // Act
        // Assert
        await Assert.ThrowsAsync<UserNotFoundException>(async () => await service.EditUserPersonalInfoAsync(userId, requestUserDto, mediatorMock.Object));
    }

    [Fact]
    public async Task EditUserInstitutionAsync_ReturnsOkObjectResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();

        const string newInstitutionTitle = "NewInstitutionTitle";
        const string newAddress = "NewAddress";
        var types = new[] { "School" };

        var userId = SharedLessonDbContextFactory.UserAId;
        var user = Context.Users.FirstOrDefault(u =>
            u.UserId == userId);

        var updateUserCommand = new UpdateUserInstitutionCommand
        {
            UserId = user!.UserId,
            InstitutionTitle = newInstitutionTitle,
            Address = newAddress,
            Types = types,
        };
        var updateUserHandler = new UpdateUserInstitutionCommandHandler(Context, mediatorMock.Object);

        var getInstitutionQuery = new GetInstitutionQuery()
        {
            InstitutionTitle = newInstitutionTitle,
            Address = newAddress,
            Types = types,
        };
        var getInstitutionHandler = new GetInstitutionQueryHandler(Context, mediatorMock.Object);

        var createInstitutionCommand = new CreateInstitutionCommand()
        {
            InstitutionTitle = newInstitutionTitle,
            Address = newAddress,
            Types = types,
        };
        var createInstitutionQueryHandler = new CreateInstitutionCommandHandler(Context);
        mediatorMock.Setup(m => m.Send(It.IsAny<CreateInstitutionCommand>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(await createInstitutionQueryHandler.Handle(createInstitutionCommand, CancellationToken.None));
        mediatorMock.Setup(m => m.Send(It.IsAny<GetInstitutionQuery>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(await getInstitutionHandler.Handle(getInstitutionQuery, CancellationToken.None));
        mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(user);
        mediatorMock.Setup(m => m.Send(It.IsAny<UpdateUserInstitutionCommand>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(await updateUserHandler.Handle(updateUserCommand, CancellationToken.None));

        var requestUserDto = new UpdateInstitutionRequestDto
        {
            InstitutionTitle = "NewInstitutionTitle",
            Address = "NewAddress",
            Types = new[] { "School" }
        };

        var confMapper = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<User, UserProfileDto>();
                cfg.CreateMap<Institution, InstitutionDto>();
            });

        var mapper = confMapper.CreateMapper();

        var service = new EditUserAccountService(mapper);

        // Act
        var result = await service.EditUserInstitutionAsync(userId, requestUserDto, mediatorMock.Object);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var userProfileDto = Assert.IsType<UserProfileDto>(okResult.Value);

        Assert.Equal("NewInstitutionTitle", userProfileDto.Institution.Title);
        Assert.Equal("NewAddress", userProfileDto.Institution.Address);
    }

    [Fact]
    public async Task EditUserEmailAsync_ReturnsOkObjectResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();

        const string newEmail = "NewEmail@gmail.com";

        var userId = SharedLessonDbContextFactory.UserAId;
        var user = Context.Users.FirstOrDefault(u =>
            u.UserId == userId);
        var updateUserEmailCommand = new UpdateUserEmailCommand()
        {
            UserId = user!.UserId,
            Email = newEmail
        };
        var updateUserEmailHandler = new UpdateUserEmailCommandHandler(Context);
        mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(user);
        mediatorMock.Setup(m => m.Send(It.IsAny<UpdateUserEmailCommand>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(await updateUserEmailHandler
                .Handle(updateUserEmailCommand, CancellationToken.None));

        var requestUserDto = new UpdateUserEmailRequestDto
        {
            Email = newEmail
        };

        var confMapper = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<User, UserProfileDto>();
                cfg.CreateMap<Institution, InstitutionDto>();
            });

        var mapper = confMapper.CreateMapper();

        var service = new EditUserAccountService(mapper);

        // Act
        var result = await service.EditUserEmailAsync(userId, requestUserDto, mediatorMock.Object);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var userProfileDto = Assert.IsType<UserProfileDto>(okResult.Value);

        Assert.NotNull(userProfileDto);
        Assert.Equal(newEmail, userProfileDto.Email);
    }

    [Fact]
    public async Task EditUserPasswordAsync_ReturnsOkObjectResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();

        const string newPassword = "NewPassword";

        var userId = SharedLessonDbContextFactory.UserAId;
        var user = Context.Users.FirstOrDefault(u =>
            u.UserId == userId);
        var updateUserPasswordCommand = new UpdateUserPasswordCommand()
        {
            UserId = user!.UserId,
            Password = newPassword
        };
        var updateUserPasswordHandler = new UpdateUserPasswordCommandHandler(Context);
        mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(user);
        mediatorMock.Setup(m => m.Send(It.IsAny<UpdateUserPasswordCommand>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(await updateUserPasswordHandler
                .Handle(updateUserPasswordCommand, CancellationToken.None));

        var requestUserDto = new UpdateUserPasswordRequestDto()
        {
            Password = newPassword
        };

        var confMapper = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<User, UserProfileDto>();
                cfg.CreateMap<Institution, InstitutionDto>();
            });

        var mapper = confMapper.CreateMapper();

        var service = new EditUserAccountService(mapper);

        // Act
        var result = await service.EditUserPasswordAsync(userId, requestUserDto, mediatorMock.Object);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var userProfileDto = Assert.IsType<UserProfileDto>(okResult.Value);

        Assert.NotNull(userProfileDto);
    }

    [Fact]
    public async Task EditUserProfessionalInfoAsync_ReturnsOkObjectResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();

        var languageTitles = new List<string>()
        {
            LanguageType.English.ToString(),
            LanguageType.Russian.ToString()
        };
        var disciplineTitles = new List<string>()
        {
            DisciplineType.Chemistry.ToString(),
            DisciplineType.Biology.ToString(),
            DisciplineType.Physics.ToString()
        };
        var gradeNList = new List<int>()
        {
            7, 8, 9
        };

        var userId = SharedLessonDbContextFactory.UserAId;
        var user = Context.Users.FirstOrDefault(u =>
            u.UserId == userId);

        var updateProfessionalInfoCommand = new UpdateProfessionalInfoCommand()
        {
            UserId = user!.UserId,
            LanguageTitles = languageTitles,
            DisciplineTitles = disciplineTitles,
            GradeNumbers = gradeNList
        };
        var updateProfessionalInfoHandler = new UpdateProfessionalInfoCommandHandler(Context, mediatorMock.Object);


        var getLanguagesQuery = new GetLanguagesByTitlesQuery(languageTitles);
        var getLanguagesHandler = new GetLanguagesByTitlesQueryHandler(Context);

        var getDisciplinesQuery = new GetDisciplinesByTitlesQuery(disciplineTitles);
        var getDisciplinesHandler = new GetDisciplinesByTitlesQueryHandler(Context);

        var getGradesQuery = new GetGradesQuery(gradeNList);
        var getGradesHandler = new GetGradesQueryHandler(Context);
        

        var languages = await getLanguagesHandler
            .Handle(getLanguagesQuery, CancellationToken.None);
        
        var disciplines = await getDisciplinesHandler
            .Handle(getDisciplinesQuery, CancellationToken.None);
        
        var grades = await getGradesHandler
            .Handle(getGradesQuery, CancellationToken.None);
        
        var createUserLanguagesCommand = new CreateUserLanguagesCommand()
        {
            UserId = user.UserId,
            LanguageIds = languages.Select(l => l.LanguageId).ToList()
        };
        var createUserLanguagesHandler = new CreateUserLanguagesCommandHandler(Context);
        
        var createUserDisciplinesCommand = new CreateUserDisciplinesCommand()
        {
            UserId = user.UserId,
            DisciplineIds = disciplines.Select(d => d.DisciplineId).ToList()
        };
        var createUserDisciplinesHandler = new CreateUserDisciplinesCommandHandler(Context);
        
        var createUserGradesCommand = new CreateUserGradesCommand()
        {
            UserId = user.UserId,
            GradeIds = grades.Select(g => g.GradeId).ToList()
        };
        var createUserGradesHandler = new CreateUserGradesCommandHandler(Context);

        mediatorMock.Setup(m=>m.Send(It.IsAny<CreateUserLanguagesCommand>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(await createUserLanguagesHandler.Handle(createUserLanguagesCommand, CancellationToken.None));
        mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserDisciplinesCommand>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(await createUserDisciplinesHandler.Handle(createUserDisciplinesCommand, CancellationToken.None));
        mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserGradesCommand>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(await createUserGradesHandler.Handle(createUserGradesCommand, CancellationToken.None));
        
        var updateUserLanguagesCommand = new UpdateUserLanguagesCommand
        {
            UserId = user.UserId,
            NewLanguageIds = languages.Select(l => l.LanguageId).ToList()
        };
        var updateUserLanguagesHandler = new UpdateUserLanguagesCommandHandler(Context, mediatorMock.Object);

        var updateUserDisciplinesCommand = new UpdateUserDisciplinesCommand
        {
            UserId = user.UserId,
            NewDisciplineIds = disciplines.Select(d => d.DisciplineId).ToList()
        };
        var updateUserDisciplinesHandler = new UpdateUserDisciplinesCommandHandler(Context, mediatorMock.Object);
        
        var updateUserGradesCommand = new UpdateUserGradesCommand
        {
            UserId = user.UserId,
            NewGradeIds = grades.Select(g => g.GradeId).ToList()
        };
        var updateUserGradesHandler = new UpdateUserGradesCommandHandler(Context, mediatorMock.Object);
            
        mediatorMock.Setup(m=>m.Send(It.IsAny<GetLanguagesByTitlesQuery>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(languages);
        mediatorMock.Setup(m => m.Send(It.IsAny<GetDisciplinesByTitlesQuery>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(disciplines);
        mediatorMock.Setup(m => m.Send(It.IsAny<GetGradesQuery>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(grades);
        
        mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(user);
        mediatorMock.Setup(m => m.Send(It.IsAny<UpdateProfessionalInfoCommand>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(await updateProfessionalInfoHandler
                .Handle(updateProfessionalInfoCommand, CancellationToken.None));

        mediatorMock.Setup(m => m.Send(It.IsAny<UpdateUserLanguagesCommand>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(await updateUserLanguagesHandler
                .Handle(updateUserLanguagesCommand, CancellationToken.None));
        
        mediatorMock.Setup(m => m.Send(It.IsAny<UpdateUserDisciplinesCommand>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(await updateUserDisciplinesHandler
                .Handle(updateUserDisciplinesCommand, CancellationToken.None));
        
        mediatorMock.Setup(m => m.Send(It.IsAny<UpdateUserGradesCommand>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(await updateUserGradesHandler
                .Handle(updateUserGradesCommand, CancellationToken.None));

        var requestUserDto = new UpdateProfessionalInfoRequestDto
        {
            Languages = languageTitles,
            Disciplines = disciplineTitles,
            Grades = gradeNList
        };

        var confMapper = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<User, UserProfileDto>();
                cfg.CreateMap<Institution, InstitutionDto>();
            });

        var mapper = confMapper.CreateMapper();

        var service = new EditUserAccountService(mapper);

        // Act
        var result = await service.EditUserProfessionalInfoAsync(userId, requestUserDto, mediatorMock.Object);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var userProfileDto = Assert.IsType<UserProfileDto>(okResult.Value);

        Assert.NotNull(userProfileDto);
        
        Assert.Equal(languageTitles.Count, userProfileDto.Languages.Count);
        Assert.Equal(disciplineTitles.Count, userProfileDto.Disciplines.Count);
        
        Assert.True(languageTitles.OrderBy(x => x)
            .SequenceEqual(userProfileDto.Languages.OrderBy(x => x)));
        Assert.True(disciplineTitles.OrderBy(x => x)
            .SequenceEqual(userProfileDto.Disciplines.OrderBy(x => x)));
    }
}

