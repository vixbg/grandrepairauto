using GrandRepairAuto.Services.Models.UserDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<IEnumerable<UserDTO>> GetCustomersAsync();
        Task<UserDTO> GetByIDAsync(int id);
        Task<UserDTO> GetByEmailAsync(string email);
        Task<UserDTO> CreateAsync(UserCreateDTO dto);
        Task<UserDTO> UpdateAsync(UserUpdateDTO dto, int id);
        Task<bool> Delete(int id);
        Task<bool> Restore(int id);
    }
}
