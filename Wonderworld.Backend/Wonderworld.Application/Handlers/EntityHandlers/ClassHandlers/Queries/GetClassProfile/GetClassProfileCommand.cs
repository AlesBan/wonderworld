using MediatR;
using Wonderworld.Application.Dtos;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClassProfile;

public class GetClassProfileCommand : IRequest<ClassProfileDto>
{
    public Class Class { get; set; }
}