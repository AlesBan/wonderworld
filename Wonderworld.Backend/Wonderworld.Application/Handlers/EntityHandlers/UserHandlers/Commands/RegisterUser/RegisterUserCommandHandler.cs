using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Helpers;
using Wonderworld.Application.Helpers.TokenHelper;
using Wonderworld.Application.Helpers.UserHelper;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
{
    private readonly ISharedLessonDbContext _context;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserHelper _userHelper;

    public RegisterUserCommandHandler(ISharedLessonDbContext context, ITokenHelper tokenHelper, IUserHelper userHelper)
    {
        _context = context;
        _tokenHelper = tokenHelper;
        _userHelper = userHelper;
    }

    public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userEmail = request.Email;
        var userPassword = request.Password;

        var userExists = await _context.Users
            .AnyAsync(x => x.Email == userEmail, cancellationToken);

        if (userExists)
        {
            throw new UserAlreadyExistsException(userEmail);
        }

        var newUser = new User
        {
            Email = userEmail
        };

        PasswordHelper.SetUserPasswordHash(newUser, userPassword);

        newUser.AccessToken = _tokenHelper.CreateToken(newUser);
        newUser.VerificationCode = _userHelper.GenerateVerificationCode();

        await AddUserToDataBase(newUser, cancellationToken);

        return await Task.FromResult(newUser);
    }

    private async Task AddUserToDataBase(User user, CancellationToken cancellationToken)
    {
        await _context.Users
            .AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}