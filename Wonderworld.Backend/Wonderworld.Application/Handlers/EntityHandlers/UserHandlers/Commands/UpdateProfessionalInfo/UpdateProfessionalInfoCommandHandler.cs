using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.UpdateUserGrades;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.UpdateUserLanguages;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguages;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateProfessionalInfo;

public class UpdateProfessionalInfoCommandHandler : IRequestHandler<UpdateProfessionalInfoCommand, User>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMediator _mediator;

    public UpdateProfessionalInfoCommandHandler(ISharedLessonDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<User> Handle(UpdateProfessionalInfoCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u =>
                u.UserId == request.UserId, cancellationToken: cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        var languages = await _mediator.Send(new GetLanguagesQuery
        {
            LanguageTitles = request.LanguageTitles
        }, cancellationToken);


        var disciplines = await _mediator.Send(new GetDisciplinesQuery
        {
            DisciplineTitles = request.DisciplineTitles
        }, cancellationToken);


        var grades = await _mediator.Send(new GetGradesQuery
        {
            GradeNumbers = request.GradeNumbers
        }, cancellationToken);

        var updateUserLanguagesQuery = new UpdateUserLanguagesCommand
        {
            UserId = user.UserId,
            NewLanguageIds = languages.Select(l => l.LanguageId).ToList()
        };
        
        var updateUserDisciplinesQuery = new UpdateUserDisciplinesCommand
        {
            UserId = user.UserId,
            NewDisciplineIds = disciplines.Select(d => d.DisciplineId).ToList()
        };
        
        var updateUserGradesQuery = new UpdateUserGradesCommand()
        {
            UserId = user.UserId,
            NewGradeIds = grades.Select(g => g.GradeId).ToList()
        };
        
        await _mediator.Send(updateUserLanguagesQuery, cancellationToken);
        await _mediator.Send(updateUserDisciplinesQuery, cancellationToken);
        await _mediator.Send(updateUserGradesQuery, cancellationToken);

        _context.Users.Attach(user).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }
}