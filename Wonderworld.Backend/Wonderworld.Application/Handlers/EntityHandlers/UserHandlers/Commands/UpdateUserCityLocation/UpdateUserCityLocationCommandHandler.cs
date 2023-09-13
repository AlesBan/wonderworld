using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserCityLocation;

public class UpdateUserCityLocationCommandHandler : IRequestHandler<UpdateUserCityLocationCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserCityLocationCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserCityLocationCommand request, CancellationToken cancellationToken)
    {
        request.User.City = request.CityLocation;

        _context.Users.Update(request.User);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

}