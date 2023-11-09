using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.CreateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.CreateUserGrade;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.CreateUserLanguages;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserToken;
using Wonderworld.Application.Helpers.TokenHelper;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;

public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, User>
{
    private readonly ISharedLessonDbContext _context;
    private readonly ITokenHelper _tokenHelper;
    public CreateUserAccountCommandHandler(ISharedLessonDbContext serviceDbContext, ITokenHelper tokenHelper)
    {
        _context = serviceDbContext;
        _tokenHelper = tokenHelper;
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
        user.CityId = request.CityId;
        user.CountryId = request.CountryId;
        user.InstitutionId = request.InstitutionId;
        user.PhotoUrl = request.PhotoUrl;

        user.IsCreatedAccount = true;
        user.CreatedAt = DateTime.UtcNow;
        
        var newToken = _tokenHelper.CreateToken(user);

        user.AccessToken = newToken;

        _context.Users.Attach(user).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        await SeedUserLanguages(user.UserId, request, cancellationToken);
        await SeedUserDisciplines(user.UserId, request, cancellationToken);
        await SeedUserGrades(user.UserId, request, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        var userWithAccount = _context
            .Users
            .Include(u => u.Country)
            .Include(u => u.City)
            .Include(u => u.Institution)
            .Include(u => u.UserDisciplines)
            .ThenInclude(ud => ud.Discipline)
            .Include(u => u.UserLanguages)
            .ThenInclude(ul => ul.Language)
            .Include(u => u.UserGrades)
            .ThenInclude(ug => ug.Grade)
            .FirstOrDefault(u => u.UserId == request.UserId);

        return userWithAccount;
    }

    private async Task SeedUserLanguages(Guid userId, CreateUserAccountCommand request,
        CancellationToken cancellationToken = default)
    {
        var handler = new CreateUserLanguagesCommandHandler(_context);
        await handler.Handle(new CreateUserLanguagesCommand
        {
            UserId = userId,
            LanguageIds = request.LanguageIds
        }, cancellationToken);
    }

    private async Task SeedUserDisciplines(Guid userId, CreateUserAccountCommand request,
        CancellationToken cancellationToken = default)
    {
        var handler = new CreateUserDisciplinesCommandHandler(_context);
        await handler.Handle(new CreateUserDisciplinesCommand()
        {
            UserId = userId,
            DisciplineIds = request.DisciplineIds
        }, cancellationToken);
    }

    private async Task SeedUserGrades(Guid userId, CreateUserAccountCommand request,
        CancellationToken cancellationToken = default)
    {
        var handler = new CreateUserGradesCommandHandler(_context);
        await handler.Handle(new CreateUserGradesCommand()
        {
            UserId = userId,
            GradeIds = request.GradeIds
        }, cancellationToken);
    }
}