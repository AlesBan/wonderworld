using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Helpers;
using Wonderworld.API.Services.EditUserData;
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
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Services.EditUserServices;

public class EditUserAccountService : IEditUserAccountService
{
    private readonly IMapper _mapper;

    public EditUserAccountService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IActionResult> EditUserPersonalInfoAsync(Guid userId, UpdatePersonalInfoRequestDto requestUserDto,
        IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    public async Task<IActionResult> EditUserInstitutionAsync(Guid userId, UpdateInstitutionRequestDto requestUserDto,
        IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    public async Task<IActionResult> EditUserEmailAsync(Guid userId, UpdateUserEmailRequestDto requestUserDto,
        IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    public async Task<IActionResult> EditUserProfessionalInfoAsync(Guid userId,
        UpdateProfessionalInfoRequestDto requestUserDto, IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    public async Task<IActionResult> EditUserPasswordAsync(Guid userId, UpdateUserPasswordHashRequestDto requestUserDto,
        IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    private async Task<IActionResult> GetResultOfUpdatingUserAsync<TRequestDto>(Guid userId, TRequestDto requestUserDto,
        IMediator mediator)
    {
        var user = await UserHelper.GetUserById(userId, mediator);
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


        return new OkObjectResult(userProfileDto);
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
            UpdateProfessionalInfoRequestDto professionalInfoRequestDto => await mediator.Send(
                new UpdateProfessionalInfoCommand
                {
                    UserId = user.UserId,
                    LanguageTitles = professionalInfoRequestDto.Languages,
                    DisciplineTitles = professionalInfoRequestDto.Disciplines,
                    GradeNumbers = professionalInfoRequestDto.Grades
                }),
            UpdateInstitutionRequestDto institutionRequestDto => await mediator.Send(new UpdateUserInstitutionCommand
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
            UpdateUserPasswordHashRequestDto passwordRequestDto =>
                await GetUserUpdatedPassword(user.UserId, passwordRequestDto, mediator),
            _ => throw new Exception("Something went wrong")
        };
    }

    private static async Task<User> GetUserUpdatedPassword(Guid userId, UpdateUserPasswordHashRequestDto requestUserDto,
        IMediator mediator)
    {
        UserHelper.CreatePasswordHash(requestUserDto.Password, out var passwordHash, out var passwordSalt);
        var user = await mediator.Send(new UpdateUserPasswordHashCommand
        {
            UserId = userId,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        });

        return user;
    }
}