using Bokra.Core.Common;
using Bokra.Core.Entities.Identity;
using Bokra.Core.Services.AbstractServices;
using Microsoft.AspNetCore.Identity;

namespace Bokra.Core.Services.ImplementServices
{
    public class AuthService : ResponseHandler, IAuthService
    {

        #region Fields
        private UserManager<User> _userManager { get; set; }
        public SignInManager<User> _signInManager { get; set; }
        #endregion

        #region Constructor 
        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion




        #region HandlerMethods
        public async Task<Response<string>> SignUpAsync(User user, string password)
        {
            // 1) Check if email already exists
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser != null)
                return BadRequest<string>("UserAlreadyExists");

            // 2) Create the user
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return BadRequest<string>("ErrorCreatingUser");

            return Success<string>("UserCreatedSuccessfully");
        }

        public async Task<Response<string>> Login(User user, string password)
        {
            // 1) Check if user exists by email
            var dbUser = await _userManager.FindByEmailAsync(user.Email);
            if (dbUser == null)
                return BadRequest<string>("UserNotExist");

            // 2) Password Check
            var signIn = await _signInManager.CheckPasswordSignInAsync(dbUser, password, false);

            if (!signIn.Succeeded)
                return BadRequest<string>("PasswordNotCorrect");

            // 3) Generate Token (later)
            // var token = await _jwtTokenService.GetJWTToken(dbUser);
            // return Success(token, "LoginSuccessful");

            return Success("LoginSuccessful");
        }

        #endregion
    }

}
