using Manager.Services.DTO;

namespace Manager.Services.Interfaces;

public interface IUserService
{
    Task<UserDTO> Create(UserDTO userDto);
    Task<UserDTO> Update(UserDTO userDto);
    Task Remove(long id);
    Task<UserDTO> Get(long id);
    Task<UserDTO> GetByEmail(string email);
    Task<List<UserDTO>> Get();
    Task<List<UserDTO>> SearchByName(string name);
    Task<List<UserDTO>> SearchByEmail(string email);
    
}