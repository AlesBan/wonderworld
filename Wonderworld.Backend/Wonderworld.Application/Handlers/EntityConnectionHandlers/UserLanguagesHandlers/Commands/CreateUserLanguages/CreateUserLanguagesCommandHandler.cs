using System.Collections.Concurrent;
using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.CreateUserLanguages;

public class CreateUserLanguagesCommandHandler : IRequestHandler<CreateUserLanguagesCommand>
{
    private readonly ISharedLessonDbContext _context;

    public CreateUserLanguagesCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Handle the CreateUserLanguagesCommand request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(CreateUserLanguagesCommand request, CancellationToken cancellationToken)
    {
        var userLanguagesToAdd = (from languageId in request.LanguageIds
                let exists = _context.UserLanguages.Any(l =>
                    l.LanguageId == languageId && l.UserId == request.UserId)
                where !exists
                select new UserLanguage()
                    { UserId = request.UserId, LanguageId = languageId })
            .ToList();
        
        if (userLanguagesToAdd.Count == 0)
        {
            return Unit.Value;
        }

        await _context.UserLanguages
            .AddRangeAsync(userLanguagesToAdd, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}