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
        UpdateProfessionalInfoRequestDto requestUserDto,
        IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    public async Task<IActionResult> EditUserPasswordAsync(Guid userId, UpdateUserPasswordRequestDto requestUserDto,
        IMediator mediator)
    {
        return await GetResultOfUpdatingUserAsync(userId, requestUserDto, mediator);
    }

    private async Task<IActionResult> GetResultOfUpdatingUserAsync(Guid userId,
        object requestUserDto, IMediator mediator)
    {
        try
        {
            var user = await UserHelper.GetUser(userId, mediator);
            var updatedUser = requestUserDto switch
            {
                UpdatePersonalInfoRequestDto requestUserDtoType1 =>
                    await GetUpdatedUserAsync(user, requestUserDtoType1, mediator),
                UpdateInstitutionRequestDto requestUserDtoType2 =>
                    await GetUpdatedUserAsync(user, requestUserDtoType2, mediator),
                UpdateUserEmailRequestDto requestUserDtoType3 =>
                    await GetUpdatedUserAsync(user, requestUserDtoType3, mediator),
                UpdateProfessionalInfoRequestDto requestUserDtoType4 =>
                    await GetUpdatedUserAsync(user, requestUserDtoType4, mediator),
                UpdateUserPasswordRequestDto requestUserDtoType5 =>
                    await GetUpdatedUserAsync(user, requestUserDtoType5, mediator),
                _ => throw new Exception("Something went wrong")
            };

            var userProfileDto = _mapper.Map<UserProfileDto>(updatedUser);
            return new OkObjectResult(userProfileDto);
        }
        catch (Exception e)
        {
            return ResponseHelper.GetBadRequest(e.Message);
        }
    }

    private static async Task<User> GetUpdatedUserAsync(User user,
        UpdatePersonalInfoRequestDto requestUserDto, IMediator mediator)
    {
        var updatedUser = await mediator.Send(
            new UpdatePersonalInfoCommand
            {
                UserId = user.UserId,
                IsATeacher = requestUserDto.IsATeacher,
                IsAnExpert = requestUserDto.IsAnExpert,
                FirstName = requestUserDto.FirstName,
                LastName = requestUserDto.LastName,
                CityTitle = requestUserDto.CityTitle,
                CountryTitle = requestUserDto.CountryTitle,
                Description = requestUserDto.Description
            });

        return updatedUser;
    }

    private static async Task<User> GetUpdatedUserAsync(User user,
        UpdateProfessionalInfoRequestDto requestUserDto, IMediator mediator)
    {
        var updatedUser = await mediator.Send(
            new UpdateProfessionalInfoCommand
            {
                UserId = user.UserId,
                Languages = requestUserDto.Languages,
                Disciplines = requestUserDto.Disciplines,
                Grades = requestUserDto.Grades
            });

        return updatedUser;
    }

    private static async Task<User> GetUpdatedUserAsync(User user,
        UpdateInstitutionRequestDto requestUserDto, IMediator mediator)
    {
        var updatedUser = await mediator.Send(
            new UpdateUserInstitutionCommand
            {
                UserId = user.UserId,
                InstitutionTitle = requestUserDto.InstitutionTitle,
                Address = requestUserDto.Address,
                Types = requestUserDto.Types,
            });

        return updatedUser;
    }

    private static async Task<User> GetUpdatedUserAsync(User user,
        UpdateUserEmailRequestDto requestUserDto, IMediator mediator)
    {
        var updatedUser = await mediator.Send(
            new UpdateUserEmailCommand
            {
                UserId = user.UserId,
                Email = requestUserDto.Email
            });

        return updatedUser;
    }

    private static async Task<User> GetUpdatedUserAsync(User user,
        UpdateUserPasswordRequestDto requestUserDto, IMediator mediator)
    {
        var updatedUser = await mediator.Send(
            new UpdateUserPasswordCommand()
            {
                UserId = user.UserId,
                Password = requestUserDto.Password
            });

        return updatedUser;
    }
}