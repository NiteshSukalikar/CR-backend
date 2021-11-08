namespace AuthService.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AuthService.Common.ResponseVM;
    using AuthService.Model;
    using AuthService.Utility;

    /// <summary>
    /// Defines the <see cref="IUserService" />
    /// </summary>
    public interface IAuthService
    {
        Task<UserDetails> GetUserDetailsByEmail(string email);
        Task<UserDetails> GetUserDetailsById(string userId);
        Task<ResponseVM> Login(LoginModel loginVM);
        Task<ResponseVM> LoginOTPVerification(OTPModel model);

        Task<ResponseVM> forgotPassword(ForgotPassword forgotPassword);
        Task<ResponseVM> forgotPasswordExpired(ForgotPassword forgotPassword);
        Task<ResponseVM> verfyOtpForgotPassword(OTPModel otp);

        Task<ResponseVM> resetPasswordForgot(ResetPassword resetPassword);
        Task<ResponseVM> ChangePassword(ChangePassword password, Shared.Model.TokenClaimsModal claims);
        
        Task<ResponseVM> updateDeviceToken(bool isMobile, int userId);

        string sendOTPToUser(UserModel user);

        string generateRandomOTP();

        string VerifyOTPForUser(UserModel user, string OTP);

        string GenerateTokenString(UserDataModel tokenModel);
        Task<JsonModel> RenewTokens(UserDataModel userData);

        Task<VerificationResult> StartVerificationAsync(string phoneNumber, string channel,string email, string? forgotPasswordUrl);
        Task<VerificationResult> CheckVerificationAsync(string phoneNumber, string code,string email,string otpVia, string? pinId);
    }
}

