using BoilerPlateApi.Authentication;
using BoilerPlateApi.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlateApi.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthController(UserManager<AuthUser> userManager, SignInManager<AuthUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager; 
        }

        [Route("api/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            try
            {
            // In future, Do Validations with Data Annotations
            var errors = RegistrationUtil.ValidateRegistrationModel(model);
            if(errors.Count() > 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, errors);
            }
            // ------------

            var aspUserEmail = await _userManager.FindByEmailAsync(model.Email);
            var aspUserUsername = await _userManager.FindByNameAsync(model.Username);

            if(aspUserEmail != null || aspUserUsername != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "User Already Exist with this email.");
            }
            AuthUser user = new AuthUser
            {
                UserName = model.Username,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                return StatusCode(StatusCodes.Status201Created, "User Created Successfully");
            }
            return StatusCode(StatusCodes.Status400BadRequest, result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("api/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                var aspUser = await _userManager.FindByEmailAsync(login.Email);
                if (aspUser == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Invalid Email");
                }
                var result = await _signInManager.PasswordSignInAsync(aspUser, login.Password, false, false);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK, "Login Successfull!");
                }

                return StatusCode(StatusCodes.Status403Forbidden, "Login Failed!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return StatusCode(StatusCodes.Status200OK, "Signout Successfull");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        [Route("api/generateroles")]
        public async Task<IActionResult> GenerateRoles()
        {
            try
            {
                if(!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await _roleManager.RoleExistsAsync(UserRoles.UserManager))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.UserManager));
                }
                if (!await _roleManager.RoleExistsAsync(UserRoles.Operator))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Operator));
                }
                return StatusCode(StatusCodes.Status200OK, "Roles Created Succesfully!");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
