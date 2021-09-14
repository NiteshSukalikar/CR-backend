

namespace Shared.Enum
{
    public enum UserType
    {
        Patient = 1,
        Provider = 2,
        Agency = 3,
        SuperAdmin = 4
    }
    public enum ProviderType
    {
        Hospital = 1,
        Lab = 2,
        Pharmacy = 3
    }
    public enum AgencyType
    {
        Government = 1,
        NonGovernment = 2
    }
    public enum Consent
    {
        APPROVED = 1,
        DENIED = 2,
        REQUESTED = 3,
        REVOKED = 4
    }
    public enum Roles
    {
        PATIENT = 1,
        DOCTOR = 10,
        ADMIN = 9
    }
}
