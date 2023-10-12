using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.UpdateUserLanguages;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.CreateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.CreateUserDisciplines;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;

public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, User>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMediator _mediator;

    public CreateUserAccountCommandHandler(ISharedLessonDbContext serviceDbContext, IMediator mediator)
    {
        _context = serviceDbContext;
        _mediator = mediator;
    }

    public async Task<User> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var user = _context
            .Users
            .Include(u => u.Country)
            .Include(u => u.City)
            .Include(u => u.Institution)
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
        user.Institution = request.Institution;
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
        var handler = new UpdateUserLanguagesCommandHandler(_context, _mediator);
        await handler.Handle(new UpdateUserLanguagesCommand
        {
            UserId = userId,
            NewLanguageIds = request.Languages
                .Select(l => l.LanguageId)
                .ToList()
        }, cancellationToken);
    }

    private async Task SeedUserDisciplines(Guid userId, CreateUserAccountCommand request,
        CancellationToken cancellationToken = default)
    {
        var handler = new CreateUserDisciplinesCommandHandler(_context);
        await handler.Handle(new CreateUserDisciplinesCommand()
        {
            UserId = userId,
            DisciplineIds = request.Disciplines
                .Select(d => d.DisciplineId)
                .ToList()
        }, cancellationToken);
    }
}