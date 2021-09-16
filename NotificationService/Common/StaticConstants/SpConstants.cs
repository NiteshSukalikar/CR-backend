namespace NotificationService.Common.StaticConstants
{
    /// <summary>
    /// Constants for Stored Procedure Names
    /// Defines the <see cref="SpConstants" />
    /// </summary>
    public static class SpConstants
    {

        public const string SetIsEvisitVisited = "USP_SetIsEvisitVisited";

        /// <summary>
        /// Defines the <see cref="GetAdminDashboardDetail" />
        /// </summary>
        public const string GetAdminDashboardDetail = "USP_GetAdminDashboardDetail";

        /// <summary>
        /// Defines the <see cref="GetPatientDashboardDetails" />
        /// </summary>
        public const string GetProviderDashboardDetails = "USP_GetProviderDashboardDetails";
        public const string USP_GetNotifications = "GetData";

        /// <summary>
        /// Defines the <see cref="USP_AuditApiLog" />
        /// </summary>
        public const string AuditApiLog = "USP_AuditApiLog";

        public const string GetPatientCheckInList = "APT_PatientCheckInList";
        public const string SaveAppointment = "APT_SaveAppoitment";
        public const string CancelAppointment = "APT_CancelAppointment";
        public const string GetAppointment = "APT_GetAppointmentList";
        public const string GetAppointmentsforPatient = "APT_GetAppointmentListforPatient";
        public const string UpdateAppointment = "APT_UpdateAppoitment";
        public const string DeleteAppointment = "APT_DeleteAppoitment";
        public const string SaveAvailability = "USP_SaveAvailability";
        public const string SaveAvailability2 = "USP_SaveAvailability2";
        public const string USP_GetDropdownDataForSchedular = "USP_GetDropdownDataForSchedular";
        public const string GetDoctorListbyCategoryandDate = "USP_GetDoctorListbyCategoryandDate";
        public const string ValidateAppointment = "USP_ValidateAppointment";
        public const string CheckInAppointment = "APT_CheckInAppointment";

        public const string GetAvailability = "USP_GetAvailability";
        public const string TodaysAppointment = "APT_GetTodayAppointment";

        public const string UpcomingAppointment = "APT_GetUpcomingAppointment";


        public const string GetAppointmentStaffDetails = "APT_GetAppointmentStaffDetails";

        //Telehealth
        public const string GettelehealthToken = "VID_GettelehealthToken";
        public const string SaveTelehealthSession = "VID_SaveTelehealthSession";
        public const string GetTelehealthSession = "VID_GetTelehealthSession";
        public const string SaveTelehealthToken = "VID_SaveTelehealthToken";
        public const string GetCallConnectionId = "VID_GetCallConnectionId";
        public const string GetCallUserDetails = "VID_GetCallUserDetails";
        public const string SaveUpdateCallUser = "GetData";
        public const string SaveNotification = "USP_SaveNotifications";
        public const string GetDoctorsAvailabilitySlots = "USP_GetDoctorsAvailabilitySlots";
    }
}
