using AutoMapper;
using MediatR;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Dtos.InstitutionDtos;
using Wonderworld.Application.Dtos.UpdateDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Dtos.UserDtos.UpdateDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdatePersonalInfo;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateProfessionalInfo;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserEmail;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserInstitution;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPasswordHash;
using Wonderworld.Application.Helpers.UserHelper;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Infrastructure.Services.EditUserServices;

public class EditUserAccountService : IEditUserAccountService
{
    private readonly IMapper _mapper;
    private readonly IUserHelper _userHelper;

    public EditUserAccountService(IMapper mapper, IUserHelper userHelper)
    {
        _mapper = mapper;
        _userHelper = userHelper;
    }

    public async Task<UserProfileDto> EditUserPersonalInfoAsync(Guid userId,
        UpdatePersonalInfoRequestDto requestUserDto,
        IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    public async Task<UserProfileDto> EditUserInstitutionAsync(Guid userId, UpdateInstitutionRequestDto requestUserDto,
        IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    public async Task<UserProfileDto> EditUserEmailAsync(Guid userId, UpdateUserEmailRequestDto requestUserDto,
        IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    public async Task<UserProfileDto> EditUserProfessionalInfoAsync(Guid userId,
        UpdateProfessionalInfoRequestDto requestUserDto, IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    public async Task<UserProfileDto> EditUserPasswordAsync(Guid userId,
        UpdateUserPasswordHashRequestDto requestUserDto,
        IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    private async Task<UserProfileDto> GetResultOfUpdatingUserAsync<TRequestDto>(Guid userId,
        TRequestDto requestUserDto,
        IMediator mediator)
    {
        var user = await _userHelper.GetUserById(userId, mediator);
        var updatedUser = await GetUpdatedUserAsync(user, requestUserDto, mediator);

        var userProfileDto = _mapper.Map<UserProfileDto>(updatedUser);

        var languageTitles = updatedUser.UserLanguages
            .Select(ul => ul.Language.Title).ToList();
        var disciplineTitles = updatedUser.UserDisciplines
            .Select(ud => ud.Discipline.Title).ToList();
        var classes = updatedUser.Classes;
        var institution = updatedUser.Institution;

        userProfileDto.LanguageTitles = languageTitles;
        userProfileDto.DisciplineTitles = disciplineTitles;

        userProfileDto.Institution = _mapper.Map<InstitutionDto>(institution);

        userProfileDto.GradeNumbers = updatedUser.UserGrades
            .Select(ug => ug.Grade.GradeNumber).ToList();

        await Task.Delay(20);
        var classProfileDtos = classes.ToList().Select(c =>
            new ClassProfileDto
            {
                ClassId = c.ClassId,
                Title = c.Title,
                UserFullName = c.User.FullName,
                UserRating = c.User.Rating,
                Grade = c.Grade.GradeNumber,
                Languages = c.ClassLanguages.Select(cl => cl.Language.Title).ToList(),
                Disciplines = c.ClassDisciplines.Select(cd => cd.Discipline.Title).ToList(),
                PhotoUrl = c.PhotoUrl!
            }).ToList();

        userProfileDto.ClasseDtos = classProfileDtos;

        return userProfileDto;
    }

    private static async Task<User> GetUpdatedUserAsync<TRequestDto>(User user, TRequestDto requestUserDto,
        IMediator mediator)
    {
        return requestUserDto switch
        {
            UpdatePersonalInfoRequestDto personalInfoRequestDto =>
                await mediator.Send(new UpdatePersonalInfoCommand
                {
                    UserId = user.UserId,
                    IsATeacher = personalInfoRequestDto.IsATeacher,
                    IsAnExpert = personalInfoRequestDto.IsAnExpert,
                    FirstName = personalInfoRequestDto.FirstName,
                    LastName = personalInfoRequestDto.LastName,
                    CityTitle = personalInfoRequestDto.CityTitle,
                    CountryTitle = personalInfoRequestDto.CountryTitle,
                    Description = personalInfoRequestDto.Description
                }),
            UpdateProfessionalInfoRequestDto professionalInfoRequestDto =>
                await mediator.Send(
                    new UpdateProfessionalInfoCommand
                    {
                        UserId = user.UserId,
                        LanguageTitles = professionalInfoRequestDto.Languages,
                        DisciplineTitles = professionalInfoRequestDto.Disciplines,
                        GradeNumbers = professionalInfoRequestDto.Grades
                    }),
            UpdateInstitutionRequestDto institutionRequestDto =>
                await mediator.Send(new UpdateUserInstitutionCommand
                {
                    UserId = user.UserId,
                    InstitutionTitle = institutionRequestDto.InstitutionTitle,
                    Address = institutionRequestDto.Address,
                    Types = institutionRequestDto.Types,
                }),
            UpdateUserEmailRequestDto emailRequestDto => await mediator.Send(new UpdateUserEmailCommand
            {
                UserId = user.UserId,
                Email = emailRequestDto.Email
            }),
            UpdateUserPasswordHashRequestDto passwordRequestDto => await mediator
                .Send(new UpdateUserPasswordHashCommand
                {
                    UserId = user.UserId,
                    Password = passwordRequestDto.Password
                }),
            _ => throw new Exception("Something went wrong")
        };
    }
}