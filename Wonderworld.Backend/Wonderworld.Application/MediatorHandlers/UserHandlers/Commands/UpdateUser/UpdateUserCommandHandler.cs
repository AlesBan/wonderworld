using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.MediatorHandlers.UserHandlers.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly ISharedLessonContext _context;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(ISharedLessonContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (_context.Users == null)
        {
            throw new DbSetNullException(nameof(User));
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(t =>
                    t.UserId == request.UserId,
                cancellationToken: cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        user = _mapper.Map(source: request, destination: user);

        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(Unit.Value);
    }
}