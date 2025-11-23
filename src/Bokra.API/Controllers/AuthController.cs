using Bokra.API.AppMetaData;
using Bokra.API.DTOs.Auth.Request;
using Bokra.API.DTOs.Auth.Response;
using Bokra.Core.Entities.Identity;
using Bokra.Core.Services.AbstractServices;
using Bokra.Core.Services.ImplementServices;
using Microsoft.AspNetCore.Mvc;

namespace Bokra.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthController : AppControllerBase
    {

        #region Fields
        private IAuthService _authService { get; set; }
        private readonly ILogger<AuthService> _logger;
        #endregion

        #region Constructor
        public AuthController(IAuthService authService, ILogger<AuthService> logger = null)
        {
            _authService = authService;
            _logger = logger;
        }
        #endregion

        #region HandlerMethods
        [HttpPost(Router.Authentication.SignUp)]
        public async Task<IActionResult> SignUp([FromForm] SignUpDtos request)
        {
            try
            {
                var user = new User()
                {
                    FullName = request.FullName,
                    UserName = request.Email,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };
                var response = await _authService.SignUpAsync(user, request.Password);
                return NewResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user signup");
                return BadRequest(ex);
            }

        }
        [HttpPost(Router.Authentication.Login)]
        public async Task<IActionResult> Login([FromForm] LoginDtos request)
        {
            try
            {
                var user = new User()
                {
                    Email = request.Email,
                };
                var response = await _authService.Login(user, request.Password);
                return NewResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user signup");
                return BadRequest(ex);
            }

        }
        #endregion
    }
}
