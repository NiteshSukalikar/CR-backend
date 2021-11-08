namespace AuthService.Common.StaticConstants
{
    /// <summary>
    /// Constants for Stored Procedure Names
    /// Defines the <see cref="SpConstants" />
    /// </summary>
    public static class SpConstants
    {
        /// <summary>
        /// Defines the <see cref="GetUserById" />
        /// </summary>
        public const string GetUserById = "USP_GetUserById";
        public const string GetUserByMrn = "USP_GetUserByMrn";

        ///<summery>
        ///Defines the <see cref="GetUserById" />
        /// </summery>       
        public const string ActivateUser = "USP_ActivateUser";

        public const string ResetPassword = "USP_ResetPassword";
        public const string ChangePassword = "USP_ChangePassword";

        public const string GetRolePermission = "USP_GetPermissionForSidebar";

        /// <summary>
        /// Defines the GetUserByEmail
        /// </summary>
        public const string GetUserByEmail = "USP_GetUserByEmail";
        public const string SaveLogUserSystem = "USP_SaveLogUserSystem";


        /// <summary>
        /// Defines the UpdateDeviceTokenByUserId
        /// </summary>
        public const string UpdateDeviceTokenByUserId = "USP_UpdateDeviceTokenByUserId";
        public const string addLoginLogs = "USP_addLoginLogs";
        public const string addOrganizationsToken = "USP_addOrganizationsToken";
        public const string getLoginDetail = "USP_getLoginDetail";
        public const string addPasswordToken = "USP_addPasswordToken";
        public const string PasswordTokenExpired = "USP_PasswordTokenExpired";

        /// <summary>
        /// Defines the GetUserByEmailAndRoleId
        /// </summary>
        public const string GetUserByEmailAndRoleId = "USP_GetUserByEmailAndRoleId";

        public const string GetUserDetailsForLogin = "USP_GetUserDetailsForLogin";
        public const string CheckIfUserAccountIsLocked = "USP_CheckIfUserAccountIsLocked";

        /// <summary>
        /// Defines the <see cref="AuditApiLog" />
        /// </summary>
        public const string AuditApiLog = "USP_AuditApiLog";

        public const string CreatePassword = "USP_ForgotNewPassword";

    }
}
