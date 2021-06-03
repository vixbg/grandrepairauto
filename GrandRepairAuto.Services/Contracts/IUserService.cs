using GrandRepairAuto.Data.Filters.Contracts;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<IEnumerable<UserDTO>> GetCustomersAsync();
        Task<UserDTO> GetByIDAsync(int id);
        Task<UserDTO> CreateAsync(UserCreateDTO dto);
        Task<UserDTO> UpdateAsync(UserUpdateDTO dto, int id);
        bool Delete(int id);
        bool Restore(int id);
    }
}
