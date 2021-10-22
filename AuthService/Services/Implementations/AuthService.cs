﻿namespace AuthService.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json.Linq;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.IO;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using Twilio;
    using NLog.Common;
    using Twilio.Rest.Verify.V2.Service;
    using Twilio.Exceptions;
    using global::AuthService.Services.Interfaces;
    using global::AuthService.Model.Auth;
    using Shared.Helper;
    using global::AuthService.Model;
    using global::AuthService.Common.ResponseVM;
    using Shared.Enum;
    using global::AuthService.Common.StaticConstants;
    using Shared.StaticConstants;
    using IdentityModel.Client;
    using RestSharp;
    using Newtonsoft.Json;
    using global::AuthService.Repository.UnitOfWorkAndBaseRepo;
    using global::AuthService.Utility;
    using System.Net.Mail;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="AuthService" />
    /// </summary>
    public class AuthServices : IAuthService
    {
        /// <summary>
        /// Defines the _jWTSecret
        /// </summary>
        private string _jWTSecret;

        /// <summary>
        /// Gets the _httpClient
        /// </summary>
        public HttpClient _httpClient { get; }

        /// <summary>
        /// Defines the _unitOfWork
        /// </summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// Defines the _configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Defines the responseTokenVM
        /// </summary>
        private ResponseTokenVM responseTokenVM;

        /// <summary>
        /// Defines commonMethods
        /// </summary>
        private CommonMethods _commonMethods;


        /// <summary>
        /// Defines Configuration.Twilio
        /// </summary>
        //private readonly Configuration.Twilio _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unitOfWork<see cref="IUnitOfWork"/></param>
        /// <param name="client">The unitOfWork<see cref="HttpClient"/></param>
        /// <param name="Configuration">The Configuration<see cref="IConfiguration"/></param>
        public AuthServices(IUnitOfWork unitOfWork, HttpClient client, IConfiguration Configuration)
        {
            _unitOfWork = unitOfWork;
            _httpClient = client;
            _configuration = Configuration;
            _commonMethods = new CommonMethods();
            TwilioClient.Init(Constants.AccountSid, Constants.AuthToken);
        }


        public async Task<UserDetails> GetUserDetailsById(string userId)
        {
            var user = new UserDetails();
            try
            {
                user = await _unitOfWork.User.GetUserDetailsById(userId);
                return user;
            }
            catch (Exception e)
            {
                return user;
            }
        }

        public async Task<UserDetails> GetUserDetailsByEmail(string email)
        {
            var user = new UserDetails();
            try
            {
                user = await _unitOfWork.User.GetUserDetailsByEmail(email);
                return user;
            }
            catch (Exception e)
            {
                return user;
            }
        }

        public async Task<ResponseVM> Login(LoginModel loginVM)
        {
            var responseVM = new ResponseVM();
            responseVM.Code = ((int)StatusCode.StatusCode203).ToString();
            try
            {
                var user = new UserDetails();

                // user = await _unitOfWork.User.GetUserDetailsByEmailAndRoleId(loginVM.Email, loginVM.RoleId);

                // Database
                //user = await _unitOfWork.User.GetUserDetailsForLogin(loginVM);

                user.Password = "hLhLbZFF52WHGESayQxLZA==";
                user.ContactNumber = "789456123";
                user.EmailAddress = "admin5@yopmail.com";


                // Key and Iv Values
                var keybytes = Encoding.UTF8.GetBytes(Constants.keybytes);
                var iv = Encoding.UTF8.GetBytes(Constants.iv);


                if (user == null)
                {
                    LoginLogs loginLogs = new LoginLogs();
                    loginLogs.Action = "LOGIN";
                    loginLogs.CreatedDate = DateTime.UtcNow;
                    loginLogs.CreatedById = 0;
                    loginLogs.IPAddress = loginVM.ipAddress;//model.ipAddr;
                    loginLogs.Country = loginVM.Country;

                    loginLogs.OrganizationID = Convert.ToInt32(loginVM.OrganizationId);
                    loginLogs.LoginAttempt = "FAILED";
                    var log = _unitOfWork.User.loginLog(loginLogs);

                    responseVM.Code = ((int)StatusCode.StatusCode202).ToString();
                    responseVM.Data = null;
                    responseVM.Message = IEHMessages.UserNotFound;
                }
                else if (user.Password != loginVM.Password)
                {
                    LoginLogs loginLogs = new LoginLogs();
                    loginLogs.Action = "LOGIN";
                    loginLogs.CreatedDate = DateTime.UtcNow;
                    loginLogs.CreatedById = Convert.ToInt64(user.UserId);
                    loginLogs.IPAddress = loginVM.ipAddress;    //model.ipAddr;
                    loginLogs.Country = loginVM.Country;

                    loginLogs.OrganizationID = Convert.ToInt32(user.OrganizationId);
                    loginLogs.LoginAttempt = "FAILED";
                    var log = _unitOfWork.User.loginLog(loginLogs);

                    responseVM.Code = ((int)StatusCode.StatusCode204).ToString();
                    responseVM.Data = null;
                    responseVM.Message = IEHMessages.EmailorPasswordWrong;
                }
                else
                {
                    var _otpSent = false;
                    var responseData = new ResponseVM();
                    var ActivationRequired = false;

                    if (user.ContactNumber != null)
                    {
                        //var decryptedNUmber = DecryptRijndael(user.ContactNumber, keybytes, iv);
                        //var decrypetEmail = DecryptRijndael(user.EmailAddress, keybytes, iv);

                        var respOTP = await StartVerificationAsync(user.ContactNumber, loginVM.otpVia, user.EmailAddress);
                        if (loginVM.otpVia != "email")
                        {
                            responseData = JsonConvert.DeserializeObject<ResponseVM>(respOTP.Response);
                        }
                        _otpSent = respOTP.IsValid;

                        if (loginVM.otpVia != "email")
                        { responseVM.Data = new { userId = user.UserId, otpSent = _otpSent, activationRequired = ActivationRequired, responseData = responseData }; }

                        responseVM.Code = ((int)StatusCode.StatusCode200).ToString();
                        responseVM.Message = IEHMessages.OperationSuccessful;
                    }
                    else
                    {
                        _otpSent = false;

                        responseVM.Code = ((int)StatusCode.StatusCode200).ToString();
                        responseVM.Data = new { userId = user.UserId, otpSent = _otpSent, activationRequired = ActivationRequired };
                        responseVM.Message = IEHMessages.OperationSuccessful;
                    }
                }
                return responseVM;
            }
            catch (Exception e)
            {
                responseVM.Code = ((int)StatusCode.StatusCode203).ToString(); ;
                responseVM.Message = IEHMessages.InternalServerError;
                return responseVM;
            }
        }
        public async Task<ResponseVM> ActivateUser(ActivationModel activationModel)
        {
            var responseVM = new ResponseVM();
            try
            {
                var data = await _unitOfWork.User.GetUserDetailsbyMRN(activationModel.mrn);
                var keybytes = Encoding.UTF8.GetBytes(Constants.keybytes);
                var iv = Encoding.UTF8.GetBytes(Constants.iv);
                if (data != null && data.ActivationCode == activationModel.activationCode
                    //&& data.SSN != 0 ? data.SSN.ToString().Substring(9 - 4) == activationModel.ssn.ToString() : true
                    //&& data.Dob.ToShortDateString() == activationModel.dob.ToShortDateString())
                    && data.DobEncrypted == activationModel.dob)
                {
                    data.isActivated = true;
                    var _otpSent = false;
                    var update = _unitOfWork.User.ActivateUser(data);

                    if (update == "201")
                    {

                        var decryptedNUmber = DecryptRijndael(data.ContactNumber, keybytes, iv);
                        var decrypetEmail = DecryptRijndael(data.EmailAddress, keybytes, iv);

                        var respOTP = await StartVerificationAsync(decryptedNUmber, "sms", decrypetEmail);
                        _otpSent = respOTP.IsValid;

                        responseVM.Code = ((int)StatusCode.StatusCode200).ToString();
                        responseVM.Data = new { userId = data.UserId };
                        responseVM.Message = IEHMessages.ActivatedSucces;
                        return responseVM;
                    }
                    else
                    {
                        responseVM.Code = ((int)StatusCode.StatusCode500).ToString();
                        responseVM.Data = new { userId = data.UserId, otpSent = _otpSent };
                        responseVM.Message = IEHMessages.ActivatedFailure;
                        return responseVM;
                    }
                }
                else
                {
                    responseVM.Code = ((int)StatusCode.StatusCode400).ToString();
                    responseVM.Data = null;
                    responseVM.Message = IEHMessages.ActivatedFailure;
                    return responseVM;
                }

            }
            catch (Exception ex)
            {

                responseVM.Code = ((int)StatusCode.StatusCode301).ToString();
                responseVM.Data = null;
                responseVM.Message = IEHMessages.ActivatedFailure;
                return responseVM;
            }

        }
        public async Task<ResponseVM> updateDeviceToken(bool isMobile, int userId)
        {
            ResponseVM response = new ResponseVM();
            try
            {
                if (isMobile)
                {
                    var res = await _unitOfWork.User.UpdateDeviceTokenByUserId(string.Empty, Convert.ToString(userId));
                    response.Data = null;
                    response.Message = IEHMessages.LogoutSuccessfully;
                    response.Code = ((int)StatusCode.StatusCode200).ToString();
                    return response;
                }
                else
                {
                    // var res = await _unitOfWork.User.UpdateDeviceTokenByUserId(string.Empty, Convert.ToString(userId));
                    response.Data = null;
                    response.Message = IEHMessages.LogoutSuccessfully;
                    response.Code = ((int)StatusCode.StatusCode200).ToString();
                    return response;
                }
            }
            catch (Exception ex)
            {

                var res = await _unitOfWork.User.UpdateDeviceTokenByUserId(string.Empty, Convert.ToString(userId));
                response.Data = null;
                response.Message = IEHMessages.InternalServerError;
                response.Code = ((int)StatusCode.StatusCode500).ToString();
                return response;
            }
        }
        public async Task<ResponseVM> resetPasswordForgot(ResetPassword resetPassword)
        {
            var responseVM = new ResponseVM();

            try
            {
                var user = new UserDetails();
                var keybytes = Encoding.UTF8.GetBytes(Constants.keybytes);
                var iv = Encoding.UTF8.GetBytes(Constants.iv);
                resetPassword.UserId = DecryptRijndael(resetPassword.UserId, keybytes, iv);
                user = await _unitOfWork.User.GetUserDetailsById(resetPassword.UserId);

                var data = _unitOfWork.User.resetPasswordForgot(resetPassword);

                if (data == "201")
                {
                    responseVM.Code = ((int)StatusCode.StatusCode200).ToString();
                    responseVM.Data = null;
                    responseVM.Message = IEHMessages.PasswordResetSuccess;
                    return responseVM;
                }
                else
                {
                    responseVM.Code = ((int)StatusCode.StatusCode500).ToString();
                    responseVM.Data = null;
                    responseVM.Message = IEHMessages.PasswordResetFailed;
                    return responseVM;
                }
            }
            catch (Exception e)
            {

                responseVM.Code = ((int)StatusCode.StatusCode500).ToString();
                responseVM.Data = null;
                responseVM.Message = IEHMessages.PasswordResetFailed;
                return responseVM;
            }
        }

        public async Task<ResponseVM> ChangePassword(ChangePassword password, Shared.Model.TokenClaimsModal claims)
        {
            var responseVM = new ResponseVM();

            try
            {
                var data = _unitOfWork.User.ChangePassword(password, claims);

                if (data == ((int)StatusCode.StatusCode200).ToString())
                {
                    responseVM.Code = ((int)StatusCode.StatusCode200).ToString();
                    responseVM.Data = null;
                    responseVM.Message = IEHMessages.PasswordChangeSuccess;
                    return responseVM;
                }
                else if (data == ((int)StatusCode.StatusCode201).ToString())
                {
                    responseVM.Code = ((int)StatusCode.StatusCode201).ToString();
                    responseVM.Data = null;
                    responseVM.Message = IEHMessages.PasswordDidnotMatch;
                    return responseVM;
                }
                else
                {
                    responseVM.Code = ((int)StatusCode.StatusCode500).ToString();
                    responseVM.Data = null;
                    responseVM.Message = IEHMessages.PasswordChangeFailed;
                    return responseVM;
                }
            }
            catch (Exception e)
            {

                responseVM.Code = ((int)StatusCode.StatusCode500).ToString();
                responseVM.Data = null;
                responseVM.Message = IEHMessages.PasswordResetFailed;
                return responseVM;
            }
        }

        public async Task<ResponseVM> verfyOtpForgotPassword(OTPModel model)
        {
            var responseVM = new ResponseVM();

            try
            {

                var otpValid = true;
                var user = new UserDetails();
                var result = new TermiiResponseModel();
                var keybytes = Encoding.UTF8.GetBytes(Constants.keybytes);
                var iv = Encoding.UTF8.GetBytes(Constants.iv);

                model.UserId = DecryptRijndael(model.UserId, keybytes, iv);
                user = await _unitOfWork.User.GetUserDetailsById(model.UserId);
                user.ContactNumber = DecryptRijndael(user.ContactNumber, keybytes, iv);
                user.EmailAddress = DecryptRijndael(user.EmailAddress, keybytes, iv);
                var respOTP = await CheckVerificationAsync(user.ContactNumber, model.OTP, user.EmailAddress, model.otpVia, model.PinId);
                if (model.otpVia != "email")
                {
                    result = JsonConvert.DeserializeObject<TermiiResponseModel>(respOTP.Response);

                    if (result.pinId != null)
                    {
                        if (result.verified == "false")
                        {
                            otpValid = false;
                        }
                        else
                        {
                            otpValid = respOTP.IsValid;
                        }
                    }
                    else
                    {
                        otpValid = false;
                    }


                }
                else
                {
                    otpValid = respOTP.IsValid;
                }
                if (otpValid)
                {
                    var UserId = _commonMethods.EncryptStringToBytes(model.UserId, keybytes, iv);

                    responseVM.Code = ((int)StatusCode.StatusCode200).ToString();
                    responseVM.Data = new { otpVerified = true, userId = UserId, };
                    responseVM.Message = IEHMessages.Success;
                    return responseVM;
                }
                else
                {
                    responseVM.Code = ((int)StatusCode.StatusCode202).ToString();
                    responseVM.Data = null;
                    responseVM.Message = IEHMessages.InvalidOTP;
                    return responseVM;
                }
            }
            catch (Exception e)
            {

                responseVM.Code = ((int)StatusCode.StatusCode202).ToString();
                responseVM.Data = null;
                responseVM.Message = IEHMessages.InvalidOTP;
                return responseVM;
            }
        }
        public async Task<ResponseVM> LoginOTPVerification(OTPModel model)
        {
            var responseVM = new ResponseVM()
            {
                Code = ((int)StatusCode.StatusCode500).ToString(),
                Data = null,
                Message = "Internal Server Error"
            };
            try
            {
                var user = new UserDetails();
                //user = await _unitOfWork.User.GetUserDetailsById(model.UserId);

                // Database
                //user = await _unitOfWork.User.GetUserDetailsForLogin(loginVM);


                user.ContactNumber = "789456123";
                user.EmailAddress = "admin5@yopmail.com";


                // Key and Iv Values
                var keybytes = Encoding.UTF8.GetBytes(Constants.keybytes);
                var iv = Encoding.UTF8.GetBytes(Constants.iv);

                //var decryptedNUmber = DecryptRijndael(user.ContactNumber, keybytes, iv);
                //var decrypetEmail = DecryptRijndael(user.EmailAddress, keybytes, iv);

                if (user != null && user.ContactNumber != null)
                {
                    var otpValid = true;
                    if (model.otpVia != "notrequired")
                    {
                        var respOTP = await CheckVerificationAsync(user.ContactNumber, model.OTP, user.EmailAddress, model.otpVia, model.PinId);
                        if (respOTP != null)
                        {
                            if (respOTP.Sid == "200")
                            {
                             otpValid = respOTP.IsValid;
                            }
                            else
                            {
                                otpValid = false;
                            }
                        }

                    }
                    if (otpValid)
                    {

                        // After Identity -->
                        //JsonModel obj = await IdentityLogin(user);

                        //if (obj.StatusCode.ToString() == ((int)StatusCode.StatusCode200).ToString())
                        //{
                        //    model.LoginAttempt = "SUCCESS";
                        //    model.OrganizationId = model.RoleId == 1 ? model.OrganizationId : Convert.ToInt32(user.OrganizationId);
                        //    var log = SaveLoginLogs(model);
                        //}
                        //if (obj.StatusCode.ToString() == ((int)StatusCode.StatusCode200).ToString() && !string.IsNullOrEmpty(model.DeviceToken))
                        //{
                        //    var res = await _unitOfWork.User.UpdateDeviceTokenByUserId(model.DeviceToken, model.UserId);
                        //}
                        responseVM.Code = "200";
                        responseVM.Data = "Sucess";
                        responseVM.Message = "Sucessfully Login";
                    }
                    else
                    {
                        responseVM.Code = ((int)StatusCode.StatusCode201).ToString();
                        responseVM.Data = null;
                        responseVM.Message = IEHMessages.InvalidOTP;
                    }
                }
                else
                {
                    responseVM.Code = ((int)StatusCode.StatusCode202).ToString();
                    responseVM.Data = null;
                    responseVM.Message = IEHMessages.InvalidUser;
                }
                return responseVM;
            }
            catch (Exception e)
            {
                return responseVM;
            }
        }

        public async Task<string> SaveLoginLogs(OTPModel model)
        {
            string log = "205";
            try
            {
                LoginLogs loginLogs = new LoginLogs();
                loginLogs.Action = "LOGIN";
                loginLogs.CreatedDate = DateTime.UtcNow;
                loginLogs.CreatedById = Convert.ToInt64(model.UserId);
                loginLogs.IPAddress = model.ipAddr;
                loginLogs.Country = model.Country;
                loginLogs.OrganizationID = model.OrganizationId;
                loginLogs.LoginAttempt = model.LoginAttempt;
                log = _unitOfWork.User.loginLog(loginLogs);
                return log;
            }
            catch (Exception e)
            {
                return log;
            }
        }


        /// <summary>
        /// The sendOTP
        /// </summary>
        /// <param name="user">The user<see cref="sendOTPToUser"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        public string VerifyOTPForUser(UserModel user, string OTP)
        {
            const string AccountSid = "AC83331bcf9fce56c848d70b52c8304b1f";
            const string AuthToken = "fff89c53e7e419cb9423d1ad5218bf2c";

            TwilioClient.Init(AccountSid, AuthToken);

            try
            {
                var verificationCheck = VerificationCheckResource.Create(
                    to: "+919981538167",
                    code: OTP,
                    pathServiceSid: "VA5f8e55ded10fc430f0508949c293e5bd"
                );
                return verificationCheck.Status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// The sendOTP
        /// </summary>
        /// <param name="user">The user<see cref="sendOTPToUser"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        public string sendOTPToUser(UserModel user)
        {
            string sOTP = generateRandomOTP();

            const string AccountSid = "AC83331bcf9fce56c848d70b52c8304b1f"; // for testing
            const string AuthToken = "fff89c53e7e419cb9423d1ad5218bf2c"; // for testing
            const string StatusCallbackUrl = "StatusCallbackUrl"; // for testing
            const string FromFaxNumber = "+12059227555"; // for testing

            TwilioClient.Init(AccountSid, AuthToken);

            InternalLogger.Debug("callbackUrl : " + StatusCallbackUrl);
            try
            {
                //user.ContactNumber = "+919981538167"; // for testing

                //var to = new PhoneNumber(user.ContactNumber);

                //var sms = MessageResource.Create(
                //from: FromFaxNumber,
                //to: to,
                //body: "Your One Time OTP Is " + sOTP
                //);

                var verificationCheck = VerificationResource.Create(
                    to: "+919981538167",
                    channel: "sms",
                    pathServiceSid: "VA5f8e55ded10fc430f0508949c293e5bd"
                );
                return verificationCheck.Status;

                //return sOTP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// The generateRandomOTP
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public string generateRandomOTP()
        {
            string sOTP = String.Empty;
            string sTempChars = String.Empty;

            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            Random rand = new Random();

            for (int i = 0; i < 6; i++)
            {
                int p = rand.Next(0, saAllowedCharacters.Length);
                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
                sOTP += sTempChars;
            }

            return sOTP;
        }

        public string GenerateTokenString(UserDataModel tokenModel)
        {
            JObject body = tokenModel.Claims;
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("RefreshToken", tokenModel.refreshToken));
            claims.Add(new Claim("AccessToken", tokenModel.AccessToken));

            try
            {
                foreach (var c in body.Properties())
                {
                    claims.Add(
                        new Claim(
                                c.Name.ToString(),
                                c.Value.ToString()
                                )
                            );
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"].ToString()));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["Authentication:issuer"].ToString(),
                audience: _configuration["Authentication:audience"].ToString(),
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Authentication:ExpirationTime"].ToString())),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

        public async Task<JsonModel> RenewTokens(UserDataModel userData)
        {
            try
            {
                var client = new HttpClient();
                var disco = await client.GetDiscoveryDocumentAsync(SharedConstants.IdentityURL);

                var res = new JsonModel();
                UserDataModel tokenModal = new UserDataModel();
                var response = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
                {
                    Address = SharedConstants.IdentityURL + "/connect/token",
                    ClientId = SharedConstants.ClientId,
                    ClientSecret = SharedConstants.ClientSecret,
                    RefreshToken = userData.refreshToken
                });
                if (response.AccessToken != null && response.RefreshToken != null)
                {
                    tokenModal.refreshToken = response.RefreshToken;
                    tokenModal.AccessToken = response.AccessToken;
                    if (tokenModal.AccessToken != null && tokenModal.refreshToken != null)
                    {
                        var resp = await client.GetUserInfoAsync(new UserInfoRequest
                        {
                            Address = disco.UserInfoEndpoint,
                            Token = tokenModal.AccessToken,
                        });
                        tokenModal.Claims = resp.Json;

                        tokenModal.auth_token = GenerateTokenString(tokenModal);

                        res = new JsonModel()
                        {
                            data = tokenModal,
                            Message = response.HttpResponse.ReasonPhrase,
                            StatusCode = (int)StatusCode.StatusCode200
                        };
                    }
                }
                else
                {
                    res = new JsonModel()
                    {
                        data = tokenModal,
                        Message = response.ErrorDescription,
                        StatusCode = (int)StatusCode.StatusCode400
                    };
                }
                return res;
            }
            catch (Exception ex)
            {
                var res = new JsonModel()
                {
                    data = new object(),
                    Message = ex.Message,
                    StatusCode = (int)StatusCode.StatusCode400
                };
                return res;
            }
        }

        public async Task<JsonModel> IdentityLogin(UserDetails logiModel)
        {
            try
            {
                var client = new HttpClient();
                var disco = new DiscoveryDocumentResponse();
                try
                {
                    disco = await client.GetDiscoveryDocumentAsync(SharedConstants.IdentityURL);
                }
                catch (Exception ex)
                {
                    var _res = new JsonModel()
                    {
                        data = new object(),
                        Message = ex.Message,
                        StatusCode = (int)StatusCode.StatusCode500
                    };
                    return _res;
                }
                //var disco = await client.GetDiscoveryDocumentAsync(SharedConstants.IdentityURL);
                UserDataModel tokenModal = new UserDataModel();
                List<RolePermissionsModel> MainrolePermissionsModel = new List<RolePermissionsModel>();
                List<RolePermissionsModel> rolePermissionsModel = new List<RolePermissionsModel>();

                var res = new JsonModel();
                var response = new TokenResponse();
                try
                {
                    response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                    {
                        Address = SharedConstants.IdentityURL + "/connect/token",
                        ClientId = SharedConstants.ClientId,
                        ClientSecret = SharedConstants.ClientSecret,
                        Scope = SharedConstants.Scope,
                        UserName = logiModel.EmailAddress,
                        Password = logiModel.Password
                    });
                }
                catch (Exception ex)
                {
                    var _res = new JsonModel()
                    {
                        data = new object(),
                        Message = ex.Message,
                        StatusCode = 600
                    };
                    return _res;
                }

                tokenModal.refreshToken = response.RefreshToken;
                tokenModal.AccessToken = response.AccessToken;

                if (tokenModal.AccessToken != null && tokenModal.refreshToken != null)
                {
                    var resp = new UserInfoResponse();
                    try
                    {
                        resp = await client.GetUserInfoAsync(new UserInfoRequest
                        {
                            Address = disco.UserInfoEndpoint,
                            Token = tokenModal.AccessToken,
                        });
                    }
                    catch (Exception ex)
                    {
                        var _res = new JsonModel()
                        {
                            data = new object(),
                            Message = ex.Message,
                            StatusCode = 700
                        };
                        return _res;
                    }
                    tokenModal.Claims = resp.Json;

                    var _resp = "";
                    try
                    {
                        tokenModal.auth_token = GenerateTokenString(tokenModal);
                        _resp = tokenModal.auth_token;
                    }
                    catch (Exception ex)
                    {
                        var _res = new JsonModel()
                        {
                            data = tokenModal,
                            Message = _resp,
                            StatusCode = 1000
                        };
                        return _res;
                    }

                    //tokenModal.rolePermissions  = _unitOfWork.User.GetRolePermissions(Convert.ToInt32(logiModel.RoleId));
                    //rolePermissionsModel = tokenModal.rolePermissions;

                    //tokenModal.rolePermissions.ForEach(item =>
                    //{
                    //    tokenModal.rolePermissions.ForEach(items =>
                    //    {
                    //        if (items.ParentModuleId == item.ModuleId)
                    //        {
                    //            item.subModules = item.subModules !=null ? item.subModules : new List<RolePermissionsModel>();
                    //            item.subModules.Add(items);
                    //         //   tokenModal.rolePermissions.Remove(item);

                    //        }
                    //    });
                    //});




                    res = new JsonModel()
                    {
                        data = tokenModal,
                        Message = response.HttpResponse.ReasonPhrase,
                        StatusCode = (int)StatusCode.StatusCode200
                    };
                }
                else
                {
                    res = new JsonModel()
                    {
                        data = tokenModal,
                        Message = response.ErrorDescription,
                        StatusCode = 800
                    };
                }
                return res;
            }
            catch (Exception ex)
            {
                var res = new JsonModel()
                {
                    data = ex,
                    Message = ex.Message,
                    StatusCode = (int)StatusCode.StatusCode400
                };
                return res;
            }
        }
        public async Task<ResponseVM> GetRolePermissiononRefresh(int RoleID)
        {
            ResponseVM response = new ResponseVM();

            try
            {
                List<RolePermissionsModel> rolePermissions = new List<RolePermissionsModel>();
                rolePermissions = _unitOfWork.User.GetRolePermissions(Convert.ToInt32(RoleID));

                rolePermissions.ForEach(item =>
                {
                    rolePermissions.ForEach(items =>
                    {
                        if (items.ParentModuleId == item.ModuleId)
                        {
                            item.subModules = item.subModules != null ? item.subModules : new List<RolePermissionsModel>();
                            item.subModules.Add(items);
                            //   tokenModal.rolePermissions.Remove(item);

                        }
                    });
                });
                //rolePermissions.ForEach(item =>
                //{
                //    if (item.subModules != null)
                //    {
                //        item.subModules.ForEach(subModule =>
                //        {
                //            rolePermissions.ForEach(items =>
                //            {
                //                if (items.ParentModuleId == subModule.ModuleId)
                //                {
                //                    subModule.subModules = subModule.subModules != null ? subModule.subModules : new List<RolePermissionsModel>();
                //                    subModule.subModules.Add(items);
                //                    //   tokenModal.rolePermissions.Remove(item);

                //                }
                //            });
                //        });
                //    }
                //});
                if (rolePermissions.Count > 0)
                {
                    rolePermissions.ForEach(s => s.iconPath = Constants.ImagePath + s.iconPath);
                    response.Data = rolePermissions;
                    response.Message = IEHMessages.Success;
                    response.Code = ((int)StatusCode.StatusCode200).ToString();
                }
                else
                {
                    response.Data = rolePermissions;
                    response.Message = IEHMessages.RecordNotFound;
                    response.Code = ((int)StatusCode.StatusCode200).ToString();

                }
                return response;

            }
            catch (Exception e)
            {

                response.Data = null;
                response.Message = IEHMessages.RecordNotFound;
                response.Code = ((int)StatusCode.StatusCode500).ToString();
                return response;
            }
        }

        public async Task<VerificationResult> StartVerificationAsync(string phoneNumber, string channel, string email)
        {
            try
            {
                //var verification = VerificationResource.Create(
                //to: email,
                //channel: "email",
                //pathServiceSid: Constants.VerificationSid
                //);
                //return new VerificationResult(verification.Sid, null);

                int port = 587;
                string host = "smtp.zoho.in";
                string username = "nitesh12345@zohomail.in";
                string password = "App_store12345";
                string mailFrom = "nitesh12345@zohomail.in";
                string mailTo = email;
                string mailTitle = "Authentication Code";
                string mailMessage = "Your Otp is 123456";

                using (SmtpClient client = new SmtpClient())
                {
                    MailAddress from = new MailAddress(mailFrom);
                    MailMessage message = new MailMessage
                    {
                        From = from
                    };
                    message.To.Add(mailTo);
                    message.Subject = mailTitle;
                    message.Body = mailMessage;
                    message.IsBodyHtml = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Host = host;
                    client.Port = port;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential
                    {
                        UserName = username,
                        Password = password
                    };
                    client.Send(message);
                }
                return new VerificationResult("200", null);
            }
            catch (TwilioException e)
            {
                return new VerificationResult(new List<string> { e.Message });
            }
        }

        public static byte[] ToByteArray(string StringToConvert)

        {

            char[] CharArray = StringToConvert.ToCharArray();

            byte[] ByteArray = new byte[CharArray.Length];

            for (int i = 0; i < CharArray.Length; i++)

            {

                ByteArray[i] = Convert.ToByte(CharArray[i]);

            }

            return ByteArray;

        }
        public async Task<ResponseVM> forgotPassword(ForgotPassword forgotPassword)
        {
            ResponseVM response = new ResponseVM();

            try
            {
                var otpsend = false;
                var responseData = new TermiiResponseModel();
                Task<UserDetails> data = _unitOfWork.User.GetUserDetailsByEmail(forgotPassword.Email);

                UserDetails userDetails = new UserDetails();
                userDetails = data.Result;
                var keybytes = Encoding.UTF8.GetBytes(Constants.keybytes);
                var iv = Encoding.UTF8.GetBytes(Constants.iv);

                if (userDetails != null)
                {
                    if (userDetails.UserType != forgotPassword.RoleId)
                    {
                        response.Data = new { otpSend = otpsend };
                        response.Message = IEHMessages.EmailRoleNotMatched;
                        response.Code = ((int)StatusCode.StatusCode204).ToString();
                        return response;
                    }

                    var decryptedNumber = DecryptRijndael(userDetails.ContactNumber, keybytes, iv);
                    var decryptedEmail = DecryptRijndael(userDetails.EmailAddress, keybytes, iv);
                    var respOTP = await StartVerificationAsync(decryptedNumber, forgotPassword.otpVia, decryptedEmail);
                    if (forgotPassword.otpVia != "email")
                    {
                        responseData = JsonConvert.DeserializeObject<TermiiResponseModel>(respOTP.Response);
                    }
                    if (respOTP.IsValid)
                    {
                        otpsend = true;
                    }
                    var userID = _commonMethods.EncryptStringToBytes(userDetails.UserId.ToString(), keybytes, iv);
                    if (forgotPassword.otpVia != "email")
                    { response.Data = new { userId = userID, otpSent = otpsend, responseData = responseData }; }
                    else
                    { response.Data = new { userId = userID, otpSent = otpsend }; }
                    response.Message = IEHMessages.Success;
                    response.Code = ((int)StatusCode.StatusCode200).ToString();
                    return response;
                    //  var emailHtml = "WelCome to EHealth ,Please use this Activation code for first login. Your Activation code is " + userDetailsModel.ActivationCode;
                    //  _emailSender.sendEmail(userDetailsModel.EmailAddress, "Activation Email", emailHtml);
                }
                else
                {
                    response.Data = new { otpSend = otpsend };
                    response.Message = IEHMessages.UserNotFound;
                    response.Code = ((int)StatusCode.StatusCode205).ToString();
                    return response;
                }

            }
            catch (Exception e)
            {
                response.Data = null;
                response.Message = IEHMessages.UserNotFound;
                response.Code = ((int)StatusCode.StatusCode500).ToString();
                return response;
            }
        }

        public async Task<VerificationResult> CheckVerificationAsync(string phoneNumber, string code, string email, string OtpVia, string? pinId)
        {
            try
            {

                //var verificationCheck = VerificationCheckResource.Create(
                //to: email,
                //code: code,
                //pathServiceSid: Constants.VerificationSid
                //);

                //return verificationCheck.Status.Equals("approved") ?
                //   new VerificationResult(verificationCheck.Sid, null) :
                //   new VerificationResult(new List<string> { "Wrong OTP, Try Again." });


                if (code == "123456")
                {
                    return new VerificationResult("200", null);
                }
                return new VerificationResult("400", null);
            }
            catch (TwilioException e)
            {
                return new VerificationResult(new List<string> { e.Message });
            }
        }
        public static string DecryptRijndael(string value, byte[] key, byte[] iv)
        {

            //   var key = Encoding.UTF8.GetBytes(encryptionKey); //must be 16 chars 
            var rijndael = new RijndaelManaged
            {
                BlockSize = 128,
                IV = key,
                KeySize = 192,
                Key = key
            };

            var buffer = Convert.FromBase64String(value);
            var transform = rijndael.CreateDecryptor();
            string decrypted;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                {
                    cs.Write(buffer, 0, buffer.Length);
                    cs.FlushFinalBlock();
                    decrypted = Encoding.UTF8.GetString(ms.ToArray());
                    cs.Close();
                }
                ms.Close();
            }

            return decrypted;

        }
        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.

            //var key = Encoding.UTF8.GetBytes(Constants.keybytes);
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
