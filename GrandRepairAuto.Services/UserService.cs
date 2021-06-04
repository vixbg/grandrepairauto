using AutoMapper;
using GrandRepairAuto.Data.Filters.Contracts;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.UserDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Enums;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Http;

namespace GrandRepairAuto.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IEmailService emailService;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IUserRepository repository, IEmailService emailService, IMapper mapper, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.repository = repository;
            this.emailService = emailService;
            this.mapper = mapper;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = this.repository.Get().ToList();
            var userDTOs = new List<UserDTO>();
            foreach(var user in users)
            {
                var userDTO = mapper.Map<UserDTO>(user);
                userDTO.Roles.AddRange(await userManager.GetRolesAsync(user));
                userDTOs.Add(userDTO);
            }

            return userDTOs;
        }

        public async Task<IEnumerable<UserDTO>> GetCustomersAsync()
        {
            var users = this.repository.Get().ToList();
            var userDTOs = new List<UserDTO>();
            foreach(var user in users)
            {
                if (!(await userManager.IsInRoleAsync(user, Roles.Customer)))
                    continue;
                var userDTO = mapper.Map<UserDTO>(user);
                userDTO.Roles.AddRange(await userManager.GetRolesAsync(user));
                userDTOs.Add(userDTO);
            }

            return userDTOs;
        }

        public async Task<UserDTO> GetByIDAsync(int id)
        {
            var user = this.repository.GetByID(id);
            if (user == null)
            {
                return null;
            }
            var userDTO = mapper.Map<UserDTO>(user);
            userDTO.Roles.AddRange(await userManager.GetRolesAsync(user));

            return userDTO;
        }

        public async Task<UserDTO> CreateAsync(UserCreateDTO createDto)
        {
            var user = mapper.Map<User>(createDto);
            user.UserName = user.Email;
            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return null;
            }
            await userManager.AddToRolesAsync(user, createDto.Roles);

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = $"http://{httpContextAccessor.HttpContext.Request.Host}/Account/InitialLogin?loginToken={HttpUtility.UrlEncode(token)}&email={HttpUtility.UrlEncode(user.Email)}";

           await emailService.SendNewUserRegistraionEmailAsync(user.UserName,  $"{user.FirstName} {user.LastName}", user.Email, link);

            var userDto = mapper.Map<UserDTO>(user);
            userDto.Roles.AddRange(await userManager.GetRolesAsync(user));

            return userDto;
        }

        public async Task<UserDTO> UpdateAsync(UserUpdateDTO dto, int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return null;
            }

            mapper.Map(dto, user);

            await userManager.UpdateAsync(user);

            var currentRoles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, currentRoles.ToArray());

            await userManager.AddToRolesAsync(user, dto.Roles);

            return mapper.Map<UserDTO>(user);
        }

        public bool Delete(int id)
        {
            return this.repository.Delete(id);
        }

        public bool Restore(int id)
        {
            return this.repository.Restore(id);
        }
    }
}
