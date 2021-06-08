using System.Security.Claims;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web;
using GrandRepairAuto.Controllers;
using GrandRepairAuto.Models;
using GrandRepairAuto.Services.Contracts;
using IdentityModel;
using Microsoft.Extensions.Options;
using GrandRepairAuto.Services.Models.UserDTOs;
using AutoMapper;

namespace GrandRepairAuto.Web.ViewControllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IEmailService emailService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailService emailService, IUserService userService, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailService = emailService;
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet("Login")]
        public IActionResult Login(string returnUrl)
        {
            if (User?.Identity.IsAuthenticated == true)
            {
                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction("Index", "Home");
                return Redirect(returnUrl);
            }
            return View(new LoginInputModel { ReturnUrl = returnUrl });
        }

        [HttpPost("Login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(new LoginInputModel { ReturnUrl = model.ReturnUrl, Username = model.Username });
            }

            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                ModelState.AddModelError("ErrorMessage", "Invalid username or password");
                return View(new LoginInputModel { ReturnUrl = model.ReturnUrl, Username = model.Username });
            }

            if (await userManager.IsLockedOutAsync(user))
            {
                ModelState.AddModelError("ErrorMessage", "Account is locked, try again later");
                return View(new LoginInputModel { ReturnUrl = model.ReturnUrl, Username = model.Username });
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, true);
            if (result.Succeeded)
            {
                await signInManager.SignInWithClaimsAsync(user, model.RememberMe, new Claim[]
                {
                    new Claim("amr", "pwd"),
                    new Claim("GrandRepair_Names", $"{user.FirstName} {user.LastName}"),
                });
                if (!string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("ErrorMessage", "Invalid username or password");
            return View(new LoginInputModel { ReturnUrl = model.ReturnUrl, Username = model.Username });
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (User?.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Index", "Home");
            }

            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("InitialLogin")]
        public async Task<IActionResult> InitialLogin([FromQuery] string email, [FromQuery] string loginToken)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return View(new InitialPasswordInputVM { IsValid =  false });
            }

            if (!(await userManager.VerifyUserTokenAsync(user, "Default", "EmailConfirmation", loginToken)))
            {
                return View(new InitialPasswordInputVM { IsValid =  false });
            }
            
            // userManager.ResetPasswordAsync()

            return View(new InitialPasswordInputVM { IsValid = true, Email = email, Token = loginToken});
        }

        [HttpPost("InitialLogin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitialLogin(InitialPasswordInputVM model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction("InitialLogin", new {email = model.Email, Token = model.Token});
            }

            if (!(await userManager.VerifyUserTokenAsync(user, "Default", "EmailConfirmation", model.Token)))
            {
                return RedirectToAction("InitialLogin", new {email = model.Email, Token = model.Token});
            }

            if (model.Password != model.RePassword)
            {
                ModelState.AddModelError("RePassword", "Passwords do not match");
                return RedirectToAction("InitialLogin", new {email = model.Email, Token = model.Token});
            }

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            await userManager.ResetPasswordAsync(user, token, model.Password);
            token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await userManager.ConfirmEmailAsync(user, token);

            return await Login(new LoginInputModel {Password = model.Password, Username = model.Email});
        }

        [HttpGet]
        public IActionResult ForgottenPassword()
        {
            ViewBag.EmailSent = false;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgottenPassword(PasswordResetVM model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = $"http://{Request.Host}/Account/InitialLogin?loginToken={HttpUtility.UrlEncode(token)}&email={HttpUtility.UrlEncode(user.Email)}";

            await emailService.SendForgottenPasswordEmailAsync(user.Email, $"{user.FirstName} {user.LastName}", link);
            ViewBag.EmailSent = true;
            return View();
        }

        [HttpGet("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View("~/Views/Errors/Status.cshtml", new ErrorStatusVM(403));
        }

        [HttpGet("Profile/{email}")]
        public async Task<IActionResult> Profile(string email)
        {
            UserDTO user = await userService.GetByEmailAsync(email);
            UserVM userVM = mapper.Map<UserVM>(user);

            return View(userVM);
        }
    }
}
