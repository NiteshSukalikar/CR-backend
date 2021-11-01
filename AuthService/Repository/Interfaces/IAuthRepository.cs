namespace AuthService.Repository.Interfaces
{
    using AuthService.Model;
    using IEH_Shared.Model;
    using Shared.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IUserRepository" />
    /// </summary>
    public interface IAuthRepository
    {
        Task<UserDetails> GetUserDetailsById(string UserId);
        Task<UserDetails> GetUserDetailsByEmail(string email);

        Task<string> UpdateDeviceTokenByUserId(string deviceToken, string userId);
        Task<UserDetails> GetUserDetailsByEmailAndRoleId(string email, string roleId);
        Task<UserDetails> GetUserDetailsForLogin(LoginModel loginVM);
        Task<UserDetails> CheckIfUserAccountIsLocked(LoginModel loginVM);
        
        string ActivateUser(UserDetails userDetails);

        string resetPasswordForgot(ResetPassword resetPassword);
        string ChangePassword(ChangePassword password, TokenClaimsModal claims);
        Task<UserDetails> GetUserDetailsbyMRN(string mrn);

        List<RolePermissionsModel> GetRolePermissions(int roleId);
        string loginLog(LoginLogs model);
        string OrganizationsToken(OrganizationsToken model);
        string SaveLogUserSystem(SaveLogUserSystem model);
    }
}
