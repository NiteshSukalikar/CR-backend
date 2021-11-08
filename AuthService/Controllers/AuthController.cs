using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Serilog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using AuthService.Model;
using AuthService.Services.Interfaces;
using Shared.Helper;
using AuthService.Utility;
using AuthService.Common.ResponseVM;
using AuthService.Common.StaticConstants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IEH_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Defines the _authService
        /// </summary>
        private readonly IAuthService _authService;
        private readonly CommonMethods _commonMethods;
        private IHttpContextAccessor _accessor;

        /// <summary>
        /// Defines the applicationsettings
        /// </summary>
        private readonly IOptions<ApplicationSettings> applicationsettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">The authService<see cref="IAuthService"/></param>
        public AuthController(IAuthService authService, IOptions<ApplicationSettings> application, IHttpContextAccessor accessor)
        {
            _authService = authService;
            applicationsettings = application;
            _commonMethods = new CommonMethods();
            _accessor = accessor;
        }


        /// <summary>
        /// RenewTokens to generate new token from refresh token
        /// </summary>
        /// <param name="tokenModal"></param>
        /// <returns></returns>
        /// 


        [HttpPost]
        [Route("RenewTokens")]
        public async Task<IActionResult> RenewTokens([FromBody] UserDataModel userData)
        {
            JsonModel result = await _authService.RenewTokens(userData);
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginVM)
        {
            ResponseVM result = new ResponseVM();
            result.Code = "205";
            GeoData geoData = new GeoData();
            geoData = GetIp();
            loginVM.ipAddress = geoData.Ip;
            loginVM.Country = geoData.Country;
            result = await _authService.Login(loginVM);
            return Ok(result);
        }
       
        [HttpPost]
        // [Authorize]
        [Route("LoginOTPVerification")]
        public async Task<IActionResult> LoginOTPVerification([FromBody] OTPModel model)
        {
            GeoData geodata = new GeoData();
            geodata = GetIp();
            model.ipAddr = geodata.Ip;
            model.Country = geodata.Country;
            ResponseVM result = await _authService.LoginOTPVerification(model);
            return Ok(result);
        }

        
        [HttpPost]
        [AllowAnonymous]
        [Route("forgotPassword")]
        public async Task<IActionResult> forgotPassword([FromBody] ForgotPassword forgotPassword)
        {
            ResponseVM result = await _authService.forgotPassword(forgotPassword);
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("forgotPasswordExpired")]
        public async Task<IActionResult> forgotPasswordExpired([FromBody] ForgotPassword forgotPassword)
        {
            ResponseVM result = await _authService.forgotPasswordExpired(forgotPassword);
            return Ok(result);
        }

        [HttpPost]
        [Route("verfyOtpForgotPassword")]
        public async Task<IActionResult> verfyOtpForgotPassword([FromBody] OTPModel otp)
        {
            ResponseVM result = await _authService.verfyOtpForgotPassword(otp);
            return Ok(result);
        }

        [HttpPost]
        [Route("resetPasswordForgot")]
        public async Task<IActionResult> resetPasswordForgot([FromBody] ResetPassword resetPassword)
        {
            ResponseVM result = await _authService.resetPasswordForgot(resetPassword);
            return Ok(result);
        }

        [NonAction]
        public Shared.Model.TokenClaimsModal GetUserByClaim()
        {
            HttpContext httpContext = HttpContext.Request.HttpContext;
            var claims = _commonMethods.GetUserClaimsFromToken(httpContext);
            return claims;
        }

        [HttpPost]
        [Authorize]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword password)
        {
            ResponseVM result = await _authService.ChangePassword(password, GetUserByClaim());
            return Ok(result);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> logout([FromBody] int userId)
        {
            HttpContext context = HttpContext.Request.HttpContext;
            var isMobile = _commonMethods.checkForMobileCall(context);
            ResponseVM result = await _authService.updateDeviceToken(isMobile, userId);
            //  await context.SignOutAsync();
            return Ok(result);
        }

        [NonAction]
        public GeoData GetIp()
        {
            HttpContext httpContext = HttpContext.Request.HttpContext;
            GeoData geoData = new GeoData();
            geoData.Ip = httpContext.Request.Headers["Ip-Address"];
            geoData.Country = httpContext.Request.Headers["Country"];
            return geoData;
        }

    }
}
