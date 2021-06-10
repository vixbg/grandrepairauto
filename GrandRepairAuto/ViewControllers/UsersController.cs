using AutoMapper;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.UserDTOs;
using GrandRepairAuto.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrandRepairAuto.Web.ViewControllers
{

    [Authorize(Roles = Roles.AdminsAndEmployees)]
    public class UsersController : Controller
    {
        private IUserService userService;
        private IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<UserDTO> users = await userService.GetAllAsync();
            List<UserVM> usersVM = mapper.Map<List<UserVM>>(users);
            return View(usersVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(mapper.Map<UserVM>(new UserDTO()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserVM user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            UserCreateDTO createDTO = mapper.Map<UserCreateDTO>(user);
            await userService.CreateAsync(createDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            UserDTO getDTO = await userService.GetByIDAsync(id);
            if (getDTO == null)
            {
                return NotFound();
            }

            UserVM viewModel = mapper.Map<UserVM>(getDTO);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(UserVM user, int id)
        {
            if (user == null)
            {
                return BadRequest();
            }

            UserUpdateDTO updateDTO = mapper.Map<UserUpdateDTO>(user);
            UserDTO updatedUserDTO = await userService.UpdateAsync(updateDTO, id);
            if (updatedUserDTO == null)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await userService.Delete(id);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }
    }
}
