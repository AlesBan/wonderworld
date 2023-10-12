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
        var userLanguagesToAdd = request.LanguageIds
            .Select(l =>
                new UserLanguage()
                {
                    UserId = request.UserId,
                    LanguageId = l
                });

        await _context.UserLanguages
            .AddRangeAsync(userLanguagesToAdd, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}