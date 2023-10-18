using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserByToken;

public class GetUserByTokenCommandHandler : IRequestHandler<GetUserByTokenCommand, User>
{
    private readonly ISharedLessonDbContext _context;

    public GetUserByTokenCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserByTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x =>
                x.VerificationToken == request.Token, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(request.Token);
        }

        return user;
    }
}