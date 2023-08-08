using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.CreateUserLanguages;

public class CreateUserLanguageCommandHandler : IRequestHandler<CreateUserLanguageCommand>
{
    private readonly ISharedLessonDbContext _context;

    public CreateUserLanguageCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Handle the CreateUserLanguagesCommand request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(CreateUserLanguageCommand request, CancellationToken cancellationToken)
    {
        var userLanguage = new UserLanguage()
        {
            Language = request.Language,
            User = request.User
        };

        await _context.UserLanguages.AddAsync(userLanguage, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}