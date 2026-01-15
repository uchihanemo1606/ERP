using ERP.DTOs;

namespace ERP.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDTO loginDTO);
        Task<bool> CreateUserAsync(CreateUserDTO createUserDTO);
    }
}
