using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.MediatorHandlers.UserHandlers.Commands.UpdateTeacher;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IServiceDbContext _context;

    public UpdateUserCommandHandler(IServiceDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (_context.Users == null)
        {
            throw new DbSetNullException(nameof(User));
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(t => t.UserId == request.UserId, cancellationToken: cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        await UpdateTeacher(user, request, cancellationToken);

        return await Task.FromResult(Unit.Value);
    }

    private async Task UpdateTeacher(User user, UpdateUserCommand request, CancellationToken cancellationToken)
    {
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.Password = request.Password;

        user.IsATeacher = request.IsATeacher;
        user.IsAnExpert = request.IsAnExpert;

        user.Aims = request.Aims;
        user.Description = request.Description;
        user.InterfaceLanguage = request.InterfaceLanguage;
        user.CityLocation = request.CityLocation;
        user.Appointment = request.Appointment;
        user.Establishment = request.Establishment;
        user.PhotoUrl = request.PhotoUrl;
        user.BannerPhotoUrl = request.BannerPhotoUrl;
        user.IsVerified = request.IsVerified;

        await _context.SaveChangesAsync(cancellationToken);
    }
}