using Wonderworld.Application.Dtos.UpdateDtos;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Interfaces.Services;

public interface IUserDataService
{
    public User GetUserById(Guid userId);
    public void RegisterUser(User user);
    public void CreateUserAccount(User user);
    public void DeleteUser(User user);
    public void UpdatePhotoUser(User user, string photoUrl);
    public void UpdatePosition(User user, UpdatePositionDto positionDto);
    public void UpdateName(User user, UpdateNameDto nameDto);
    public void UpdateEstablishment(User user, Establishment establishment);
    public void UpdateDescription(User user, string description);
    public void UpdateBasicInformation(User user, BasicInformationDto basicInformationDto);
    
}