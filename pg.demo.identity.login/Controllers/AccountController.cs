using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pg.demo.identity.login.Models;
using pg.demo.identity.login.Models.CommonDefault;
using pg.demo.identity.login.Models.ViewModels;

namespace pg.demo.identity.login.Controllers
{
	public class AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : Controller
	{
		private readonly SignInManager<ApplicationUser> SignInManager = signInManager;
		private readonly UserManager<ApplicationUser> UserManager = userManager;

		public IActionResult Login()
		{
			var loginVM = new LoginViewModel();
			return View(loginVM);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel viewModel)
		{
			if (!ModelState.IsValid)
				return View("login", viewModel);

			var UserManagerResult = await UserManager.FindByEmailAsync(viewModel.UserName);

			if (UserManagerResult == null) 
			{
				ModelState.AddModelError("", Messages.LoginAttemp);
				return View("login", viewModel);
			}
				
			var resultSignIn = await SignInManager.PasswordSignInAsync(UserManagerResult.UserName!, viewModel.Password, viewModel.RememberMe, false);

			if (!resultSignIn.Succeeded)
			{
				ModelState.AddModelError("", Messages.LoginAttemp);
				return View("login", viewModel);
			}

			return RedirectToAction("index", "home");
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel viewModel)
		{
			if (!ModelState.IsValid)
				return View(viewModel);

			var appUser = new ApplicationUser()
			{
				Name = viewModel.Name,
				NickName = viewModel.Email,
				UserName = viewModel.Email,
				Email = viewModel.Email
			};

			var result = await UserManager.CreateAsync(appUser, viewModel.Password);

			if (!result.Succeeded)
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}

				return View(viewModel);
			}

			await SignInManager.SignInAsync(appUser, false);

			return RedirectToAction("index", "home");
		}

		public async Task<IActionResult> Logout()
		{
			await SignInManager.SignOutAsync();
			return RedirectToAction("index", "home");
		}
	}
}
