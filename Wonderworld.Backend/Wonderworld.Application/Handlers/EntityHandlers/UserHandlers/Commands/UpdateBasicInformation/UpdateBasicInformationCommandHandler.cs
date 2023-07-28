using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateBasicInformation;

public class UpdateBasicInformationCommandHandler: IRequestHandler<UpdateBasicInformationCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateBasicInformationCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateBasicInformationCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(t => t.UserId == request.UserId, 
                cancellationToken: cancellationToken);
         
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        
        MapUser(user, request);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }

    private void MapUser(User user, UpdateBasicInformationCommand request)
    {
        user.CityLocation = request.CityLocation;
        user.UserLanguages = request.UserLanguages;
    }
}