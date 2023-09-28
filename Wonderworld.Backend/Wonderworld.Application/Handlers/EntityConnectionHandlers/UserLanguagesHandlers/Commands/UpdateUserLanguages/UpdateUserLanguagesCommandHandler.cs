using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.UpdateUserLanguages;

public class UpdateUserLanguagesCommandHandler : IRequestHandler<UpdateUserLanguagesCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserLanguagesCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserLanguagesCommand request, CancellationToken cancellationToken)
    {
        var userLanguages = _context.UserLanguages
            .Where(ul => 
                ul.User == request.User);

        _context.UserLanguages.RemoveRange(userLanguages);
        var userLanguagesToAdd = request.NewLanguages
            .Select(l =>
                new UserLanguage()
                {
                    User = request.User,
                    Language = l
                });

        await _context.UserLanguages.AddRangeAsync(userLanguagesToAdd, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}