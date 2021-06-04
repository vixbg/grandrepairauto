﻿using AutoMapper;
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
    public class UserController : Controller
    {
        private IUserService userService;
        private IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAllAsync();
            var usersVM = mapper.Map<List<UserVM>>(users);
            return View(usersVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new UserVM());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserVM user)
        {
            UserCreateDTO createDTO = mapper.Map<UserCreateDTO>(user);
            await userService.CreateAsync(createDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var getDTO = await userService.GetByIDAsync(id);
            var viewModel = mapper.Map<UserVM>(getDTO);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(UserVM user, int id)
        {
            UserUpdateDTO updateDTO = mapper.Map<UserUpdateDTO>(user);
            await userService.UpdateAsync(updateDTO, id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
