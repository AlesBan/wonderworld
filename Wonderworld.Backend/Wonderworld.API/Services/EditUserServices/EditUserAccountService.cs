using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Helpers;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Dtos.UpdateDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdatePersonalInfo;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateProfessionalInfo;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserEmail;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserInstitution;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPassword;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Services.EditUserData;

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

    public async Task<IActionResult> EditUserPasswordAsync(Guid userId, UpdateUserPasswordRequestDto requestUserDto,
        IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    private async Task<IActionResult> GetResultOfUpdatingUserAsync<TRequestDto>(Guid userId, TRequestDto requestUserDto,
        IMediator mediator)
    {
        var user = await UserHelper.GetUser(userId, mediator);
        var updatedUser = await GetUpdatedUserAsync(user, requestUserDto, mediator);

        var userProfileDto = _mapper.Map<UserProfileDto>(updatedUser);

        userProfileDto.Disciplines = updatedUser.UserDisciplines
            .Select(d => d.Discipline.Title)
            .ToList();
        userProfileDto.Languages = updatedUser.UserLanguages
            .Select(l => l.Language.Title)
            .ToList();

        return new OkObjectResult(userProfileDto);
    }

    private static async Task<User> GetUpdatedUserAsync<TRequestDto>(User user, TRequestDto requestUserDto,
        IMediator mediator)
    {
        return requestUserDto switch
        {
            UpdatePersonalInfoRequestDto personalInfoRequestDto => await mediator.Send(new UpdatePersonalInfoCommand
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
            UpdateUserPasswordRequestDto passwordRequestDto => await mediator.Send(new UpdateUserPasswordCommand
            {
                UserId = user.UserId,
                Password = passwordRequestDto.Password
            }),
            _ => throw new Exception("Something went wrong")
        };
    }
}