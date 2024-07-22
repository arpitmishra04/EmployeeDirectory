using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager,ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._tokenService = tokenService;
            this._signInManager = signInManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel register)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var appUser = new AppUser { 
                    UserName = register.UserName
                    ,Email=register.EmailAddress
                };
                var createdUser=await _userManager.CreateAsync(appUser,register.Password!);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new UserModel
                            {
                                UserName = appUser.UserName!,
                                EmailId = appUser.Email!,
                                Token = _tokenService.CreateToken(appUser)
                            }
                            );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user =await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName==login.UserName);
            if (user == null)  return Unauthorized("Invalid User");
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password,false);
            if(!result.Succeeded) {
                return Unauthorized("Username not found and/or Password incorrect.");
            }
            return Ok(
                new UserModel
                {
                    UserName = user!.UserName!,
                    EmailId = user.Email!,
                    Token = _tokenService.CreateToken(user)
                }
                );
        }
    }
}
