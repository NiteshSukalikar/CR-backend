namespace AuthService.Common.StaticConstants
{
    /// <summary>
    /// Defines the <see cref="IEHMessages" />
    /// </summary>
    public static class IEHMessages
    {
        /// <summary>
        /// Gets or sets the SupportEmail
        /// </summary>
        public static string SupportEmail { get; set; }

        /// <summary>
        /// Gets or sets the GeneralException
        /// </summary>
        public static string GeneralException = "Something went wrong! Please try after sometime.";

        /// <summary>
        /// Gets or sets the RecordNotFound
        /// </summary>
        public static string RecordNotFound = "Record Not Found";

        /// <summary>
        /// Gets or sets the SavedSuccessfully
        /// </summary>
        public static string SavedSuccessfully = "Saved Successfully";

        /// <summary>
        /// Gets or sets the UpdatedSuccessfully
        /// </summary>
        public static string UpdatedSuccessfully = "Updated Successfully";

        /// <summary>
        /// Gets or sets the DeletedSuccessfully
        /// </summary>
        public static string DeletedSuccessfully = "Deleted Successfully";

        /// <summary>
        /// Gets or sets the VerificationRequired
        /// </summary>
        public static string VerificationRequired = "Only verified user can do this action. Please check the verification mail and verify your account by clicking the link.";

        /// <summary>
        /// Gets or sets the RegistrationRequired
        /// </summary>
        public static string RegistrationRequired = "Only Registed user can do this action. Please Register its free!";

        /// <summary>
        /// Gets or sets the RecordAlreadyExists
        /// </summary>
        public static string RecordAlreadyExists = "Record Already Exists";

        /// <summary>
        /// Gets or sets the AccountNotExist
        /// </summary>
        public static string AccountNotExist = "Account/Email not exist. Please try signing up.";

        /// <summary>
        /// Gets or sets the InvalidUser
        /// </summary>
        public static string InvalidUser = "Invalid user";

        /// <summary>
        /// Gets or sets the InvalidOTP
        /// </summary>
        public static string InvalidOTP = "Invalid OTP";

        /// <summary>
        /// Gets or sets the AccountAlreadyExist
        /// </summary>
        public static string AccountAlreadyExist = "Account/Email already exists. Please try logging in or use forgot password.";

        /// <summary>
        /// Gets or sets the InvalidToken
        /// </summary>
        public static string InvalidToken = "Invalid Token";

        /// <summary>
        /// Gets or sets the EmailAlreadyVerified
        /// </summary>
        public static string EmailAlreadyVerified = "Your account is already verified";

        /// <summary>
        /// Gets or sets the AccountBlocked
        /// </summary>
        public static string AccountBlocked = "This account is blocked by administrator. Please contact us on ";

        /// <summary>
        /// Gets or sets the EmailAccountExist
        /// </summary>
        public static string EmailAccountExist = "This email is already used to created account using email. Please try to login by entering Email and Password.";

        /// <summary>
        /// Gets or sets the DateGreaterThanNowError
        /// </summary>
        public static string DateGreaterThanNowError = "Date should be greter than or equal to current date";

        /// <summary>
        /// Gets or sets the InvalidPassword
        /// </summary>
        public static string InvalidPassword = "Invalid old password";

        /// <summary>
        /// Gets or sets the OperationSuccessful
        /// </summary>
        public static string OperationSuccessful = "Operation Successful";

        /// <summary>
        /// Constant of TokenExpired
        /// </summary>
        public static string TokenExpired = "Token is Expired";

        /// <summary>
        /// Constant of TokenActive
        /// </summary>
        public static string TokenActive = "Token is Active";

        /// <summary>
        /// Constant of AuthenticUser
        /// </summary>
        public static string AuthenticUser = "User is Authentic and can login!";

        ///<summary>
        /// Constant for ASctivation Successful
        /// </summary>
        public static string ActivatedSucces = "User is Activated!";

        public static string ActivatedFailure = "User is not Activated. Please check the Data!";


        /// <summary>
        /// Gets or sets the UnauthorizedUser
        /// </summary>
        public static string UnauthorizedUser = "User is not Authorized";

        /// <summary>
        /// Gets or sets the UserNotFound
        /// </summary>
        public static string UserNotFound = "User does not exist in the database";

        public static string YourAccountIsLockedContactAdmin = "Your account is locked. Contact admin";

        /// <summary>
        /// Gets or sets the EmailRoleNotMatched
        /// </summary>
        public static string EmailRoleNotMatched = "User email and role didn't match";

        /// <summary>
        /// Gets or sets the EmailorPasswordWrong
        /// </summary>
        public static string EmailorPasswordWrong = "Email or Password is wrong";

        /// <summary>
        /// Gets or sets the RestrictAdminLogin
        /// </summary>
        public static string RestrictAdminLogin = "Admin Login is not allowed";

        /// <summary>
        /// Gets or sets the RestrictReviewerLogin
        /// </summary>
        public static string RestrictReviewerLogin = "Reviewer Login is not allowed";

        /// <summary>
        /// Gets or sets the LoginSuspendedMessage
        /// </summary>
        public static string LoginSuspendedMessage = "Login Suspended By Admin till ";

        public static string LogoutSuccessfully = "You have been logged out successfully";

        /// <summary>
        /// Gets or sets the AccessDenied
        /// </summary>
        public static string AccessDenied = "Access Denied! You do not have permission to make this change.";

        /// <summary>
        /// Gets or sets the ImageUploaded
        /// </summary>
        public static string ImageUploaded = "Image uploaded successfully";

        /// <summary>
        /// Defines the EmailPasswordNotExist
        /// </summary>
        public static string EmailPasswordNotExist = "Email or  Password do not match.";

        /// <summary>
        /// Defines the InternalServerError
        /// </summary>
        public static string InternalServerError = "Internal server error";

        /// <summary>
        /// Defines the Ok
        /// </summary>
        public static string Ok = "200";

        public static string Success = "Success";

        public static string PasswordResetSuccess = "Password Reset Successfully";

        public static string PasswordResetFailed= "Password Reset Failed";

        public static string PasswordChangeSuccess = "Password Changed Successfully";
        public static string PasswordChangeFailed = "Password Change Failed";
        public static string PasswordDidnotMatch = "Password Didn't Match";

    }
}
