using LeaveManagementSystem.Models;
using LeaveManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

     
     
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var newUser = new User
        {
            // Name = model.Name,
            Name=model.Name,
            //LastName = model.LastName,
            Email = model.Email,
            //  Password = model.Password
            UserName = model.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(newUser, model.Password);

        if (result.Succeeded)
        {
            
            //await _userManager.AddToRoleAsync(newUser, "User");
            //await _signInManager.SignInAsync(newUser, isPersistent: false);
            return RedirectToAction("LogIn");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult LogIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(LoginViewModel loginModel)
    {
        if (ModelState.IsValid)
        {
            
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                HttpContext.Session.SetString("UserId", user.Id);
                return RedirectToAction("Privacy", "Home");
            }
            ModelState.AddModelError("", "LoginFailed");
        }
        return View(loginModel);
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        //HttpContext.Session.Clear();
        return RedirectToAction("LogIn");
    }

   

    #region organizer

    [Authorize(Roles = "Admin")]  
    [HttpGet]
    public IActionResult RegisterOrganizer()
    {
        return View();
    }

    //[Authorize(Roles = "Admin")]  
    [HttpPost]
    public async Task<IActionResult> RegisterOrganizer(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = new User
        {
            //FirstName = model.FirstName,
            
            //Email = model.Email,
            //UserName = model.Email,
            //EmailConfirmed = true
            //Name= ser.Name,
            //LeaveRequests=user.LeaveRequests

        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "Organizer");  
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }
    #endregion
}