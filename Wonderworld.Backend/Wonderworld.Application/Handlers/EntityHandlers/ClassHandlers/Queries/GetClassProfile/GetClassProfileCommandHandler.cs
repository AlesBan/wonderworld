using AutoMapper;
using MediatR;
using Wonderworld.Application.Dtos;
using Wonderworld.Application.Dtos.ClassDtos;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClassProfile;

public class GetClassProfileCommandHandler: IRequestHandler<GetClassProfileCommand, ClassProfileDto>
{
    private readonly IMapper _mapper;
    public GetClassProfileCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    public Task<ClassProfileDto> Handle(GetClassProfileCommand request, CancellationToken cancellationToken)
    {
        var classProfile = _mapper.Map<ClassProfileDto>(request.Class);
        return Task.FromResult(classProfile);
    }
}