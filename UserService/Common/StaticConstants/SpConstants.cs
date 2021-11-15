namespace UserService.Common.StaticConstants
{
    /// <summary>
    /// Constants for Stored Procedure Names
    /// Defines the <see cref="SpConstants" />
    /// </summary>
    public static class SpConstants
    {       
        public const string GetPatientByMob = "USP_GetPatientByMob";
        public const string GetOrganizationList = "USP_GetOrganizationsList";
        public const string GetOrganization = "USP_GetOrganization";
        public const string SaveOrganization = "USP_AddOrganizations";
        public const string UpdateOrganization = "USP_UpdateOrganizations";
        public const string SaveVendor = "USP_AddVendor";
    }
}
