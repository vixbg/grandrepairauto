using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.Extensions.Options;

namespace GrandRepairAuto.Web.ViewControllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
                ModelState.AddModelError("ErrorMessage", "Account is locked, try again in 5 minutes");
                return View(new LoginInputModel { ReturnUrl = model.ReturnUrl, Username = model.Username });
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);
            if (result.Succeeded)
            {
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
                return View(new InitialPasswordVM { IsValid =  false });
            }

            if (!(await userManager.VerifyUserTokenAsync(user, "Default", "ResetPassword", loginToken)))
            {
                return View(new InitialPasswordVM { IsValid =  false });
            }
            
            // userManager.ResetPasswordAsync()

            return View(new InitialPasswordVM { IsValid = true, Email = email, Token = loginToken});
        }
    }
}
