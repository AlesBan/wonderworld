using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.UpdateUserLanguages;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Wonderworld.Application.Common.Exceptions.User;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;

public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, User>
{
    private readonly ISharedLessonDbContext _context;

    public CreateUserAccountCommandHandler(ISharedLessonDbContext serviceDbContext)
    {
        _context = serviceDbContext;
    }

    public async Task<User> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var user = _context
            .Users
            .FirstOrDefault(u => u.UserId == request.UserId);
        
        if (user == null)
        {
            throw new UserNotFoundException(request.UserId);
        }
        
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.IsATeacher = request.IsATeacher;
        user.IsAnExpert = request.IsAnExpert;
        user.City = request.City;
        user.Country = request.Country;
        user.Establishment = request.Establishment;
        user.PhotoUrl = request.PhotoUrl;

        user.IsCreatedAccount = true;
        
        _context.Users.Attach(user).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        await SeedUserLanguages(user.UserId, request, cancellationToken);
        await SeedUserDisciplines(user.UserId, request, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }

    private async Task SeedUserLanguages(Guid userId, CreateUserAccountCommand request,
        CancellationToken cancellationToken = default)
    {
        var handler = new UpdateUserLanguagesQueryHandler(_context);
        await handler.Handle(new UpdateUserLanguagesQuery
        {
            UserId = userId,
            NewLanguages = request.Languages
                .Select(l => l.LanguageId)
                .ToList()
        }, cancellationToken);
    }

    private async Task SeedUserDisciplines(Guid userId, CreateUserAccountCommand request,
        CancellationToken cancellationToken = default)
    {
        var handler = new UpdateUserDisciplinesCommandHandler(_context);
        await handler.Handle(new UpdateUserDisciplinesCommand()
        {
            UserId = userId,
            NewDisciplines = request.Disciplines
                .Select(d => d.DisciplineId)
                .ToList()
        }, cancellationToken);
    }
}