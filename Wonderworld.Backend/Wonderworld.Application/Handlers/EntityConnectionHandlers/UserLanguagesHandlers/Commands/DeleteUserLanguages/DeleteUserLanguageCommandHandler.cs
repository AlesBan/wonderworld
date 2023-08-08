using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.DeleteUserLanguages;

public class DeleteUserLanguageCommandHandler : IRequestHandler<DeleteUserLanguageCommand>
{
    private readonly ISharedLessonDbContext _context;

    public DeleteUserLanguageCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Handles the DeleteUserLanguageCommand request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(DeleteUserLanguageCommand request, CancellationToken cancellationToken)
    {
        var userLanguage = await _context.UserLanguages.FirstOrDefaultAsync(ul=>
            ul.User == request.User &&
            ul.Language == request.Language, cancellationToken);
        
        if (userLanguage == null)
        {
            throw new NotFoundException(nameof(UserLanguage), request.User.UserId, request.Language.LanguageId);
        }

        await RemoveUserLanguages(userLanguage, cancellationToken);

        return Unit.Value;
    }
    private async Task RemoveUserLanguages(UserLanguage userLanguage, CancellationToken cancellationToken)
    {
        _context.UserLanguages.RemoveRange(userLanguage);
        await _context.SaveChangesAsync(cancellationToken);
    }
}