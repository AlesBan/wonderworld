using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;

public class GetUserCommandHandler : IRequestHandler<GetUserCommand, User>
{
    private readonly ISharedLessonDbContext _context;

    public GetUserCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.UserId == request.UserId, cancellationToken: cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        
        return user;
    }
}