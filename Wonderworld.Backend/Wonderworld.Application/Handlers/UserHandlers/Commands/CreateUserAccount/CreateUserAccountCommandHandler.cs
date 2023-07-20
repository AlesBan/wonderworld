using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.MediatorHandlers.UserHandlers.Commands.CreateUserAccount;

public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand>
{
    private readonly ISharedLessonDbContext? _context;
    private readonly IMapper? _mapper;

    public CreateUserAccountCommandHandler(ISharedLessonDbContext? serviceDbContext, IMapper? mapper)
    {
        _context = serviceDbContext;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
    {
        if (_context?.Users == null)
        {
            throw new DbSetNullException(nameof(User));
        }

        var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.UserId == request.UserId, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        user = _mapper?.Map(source: request, destination: user);
        if (user != null)
        {
            _context.Users.Update(user);
        }
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}