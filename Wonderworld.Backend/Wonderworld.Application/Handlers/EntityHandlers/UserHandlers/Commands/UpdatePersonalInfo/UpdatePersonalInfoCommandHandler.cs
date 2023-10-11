using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;
using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetCountryByTitle;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdatePersonalInfo;

public class UpdatePersonalInfoCommandHandler: IRequestHandler<UpdatePersonalInfoCommand, User>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMediator _mediator;

    public UpdatePersonalInfoCommandHandler(ISharedLessonDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<User> Handle(UpdatePersonalInfoCommand request, CancellationToken cancellationToken)
    {
        var user = _context.Users
            .FirstOrDefault(u => 
                u.UserId == request.UserId);
        
        if (user == null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        var country = await _mediator.Send(new GetCountryByTitleQuery()
        {
            Title = request.CountryTitle
        }, cancellationToken);
        
        var city = await _mediator.Send(new GetCityQuery()
        {
            Title = request.CityTitle,
            CountryId = country.CountryId
        }, cancellationToken);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.IsATeacher = request.IsATeacher;
        user.IsAnExpert = request.IsAnExpert;
        user.Country = country;
        user.City = city;
        user.Description = request.Description;
        
        _context.Users.Attach(user).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
        
        return user;
    }
}