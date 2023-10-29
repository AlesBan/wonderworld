using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Helpers;
using Wonderworld.Application.Helpers.TokenHelper;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
{
    private readonly ISharedLessonDbContext _context;
    private readonly ITokenHelper _tokenHelper;

    public RegisterUserCommandHandler(ISharedLessonDbContext context, ITokenHelper tokenHelper)
    {
        _context = context;
        _tokenHelper = tokenHelper;
    }

    public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var requestUserDto = request.RegisterRequestDto;
        var userExists = await _context.Users
            .AnyAsync(x => x.Email == requestUserDto.Email, cancellationToken);
        
        if (userExists)
        {
            throw new UserAlreadyExistsException(requestUserDto.Email);
        }
        
        var newUser = new User()
        {
            Email = requestUserDto.Email
        };

        PasswordHelper.SetUserPasswordHash(newUser, requestUserDto.Password);

        newUser.VerificationToken = _tokenHelper.CreateToken(newUser);
        
        await AddUserToDataBase(newUser, cancellationToken);

        return await Task.FromResult(newUser);
    }

    private async Task AddUserToDataBase(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}