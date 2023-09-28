using MediatR;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.UpdateUserLanguages;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;

public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand>
{
    private readonly ISharedLessonDbContext _context;

    public CreateUserAccountCommandHandler(ISharedLessonDbContext serviceDbContext)
    {
        _context = serviceDbContext;
    }

    public async Task<Unit> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var user = request.User;
        MapUser(user, request);

        user.IsCreatedAccount = true;
        
        await _context.SaveChangesAsync(cancellationToken);
        
        await SeedUserLanguages(user, request, cancellationToken);
        await SeedUserDisciplines(user, request, cancellationToken);
        return Unit.Value;
    }

    private async Task SeedUserLanguages(User user, CreateUserAccountCommand request,
        CancellationToken cancellationToken = default)
    {
        var handler = new UpdateUserLanguagesCommandHandler(_context);
        await handler.Handle(new UpdateUserLanguagesCommand
        {
            User = user,
            NewLanguages = request.Languages
        }, cancellationToken);
    }

    private async Task SeedUserDisciplines(User user, CreateUserAccountCommand request,
        CancellationToken cancellationToken = default)
    {
        var handler = new UpdateUserDisciplinesCommandHandler(_context);
        await handler.Handle(new UpdateUserDisciplinesCommand()
        {
            User = user,
            NewDisciplines = request.Disciplines
        }, cancellationToken);
    }

    private static void MapUser(User user, CreateUserAccountCommand request)
    {
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.IsATeacher = request.IsATeacher;
        user.IsAnExpert = request.IsAnExpert;
        user.City = request.City;
        user.Country = request.Country;
        user.Establishment = request.Establishment;
        user.PhotoUrl = request.PhotoUrl;
    }
}