using _3lessonproject.Helpers;
using _3lessonproject.Models;
using Classroom.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _3lessonproject.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult SignUp()
    {



        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp([FromForm]CreateUserDto createUserDto)
    {
        if(!ModelState.IsValid)
        {
            return View(createUserDto);
        }

        var user = new User()
        {
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName,
            PhoneNumber = createUserDto.PhoneNumber,
            UserName = createUserDto.UserName,
        };

        user.PhotoUrl = await FileHelper.SaveUserFile(createUserDto.Photo);

        var result = await _userManager.CreateAsync(user,createUserDto.Password);

        if(!result.Succeeded)
        {
            ModelState.AddModelError("UserName", result.Errors.First().Description);

            return View();
        }

        await _signInManager.SignInAsync(user,isPersistent: true);


        return RedirectToAction("Index","Home");
    }


    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        return View(user);
    }




    [HttpGet]
    public IActionResult  SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn([FromForm]SigninUserDto signinUserDto )
    {

        var result = await _signInManager.PasswordSignInAsync(signinUserDto.UserName, signinUserDto.Password,true,false);

        if(!result.Succeeded)
        {
            ModelState.AddModelError("UserName", "UserName or Password is incorrecrt");
            return View();
        }

        return RedirectToAction("Profile");
    }



    [Authorize]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("SignIn");
    }
}
