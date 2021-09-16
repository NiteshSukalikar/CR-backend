using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Model
{
    public class OpenTokSettingModel
    {
        public int Id { get; set; }
        public string APIKey { get; set; }
        public string APISecret { get; set; }
        public string APIUrl { get; set; }
        public int? OrganizationId { get; set; }
    }
    public class TelehealthSessionDetails 
    {
        
        public int Id { get; set; }
        //[ForeignKey("Staffs")]
        public int? StaffId { get; set; }
        //[ForeignKey("Patients")]
        public int? PatientID { get; set; }

        public string SessionID { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        
        public Exception exception { get; set; }

       
        public int result { get; set; }
        public int AppointmentId { get; set; }
        public int OrganizationId { get; set; }

       
    }
    public class TelehealthTokenDetails 
    {      
        public int Id { get; set; }       
        public int TelehealthSessionDetailID { get; set; }
        public string Token { get; set; }
        public double TokenExpiry { get; set; }
        public bool IsStaffToken { get; set; }
        public int OrganizationId { get; set; }
        public int? InvitationId { get; set; }       
        public Exception exception { get; set; }       
        public int result { get; set; }
        public OpenTokSettingModel openTokSetting { get; set; }
        

    }
    public class OpenTokModel
    {
        public OpenTokModel()
        {
            ApiKey = 46467482;
            ApiSecret = "7f048c7174acaaa0bbb1056b73ff8709ad6d8dec";
        }
        public int Id { get; set; }
        public int ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public string Token { get; set; }
        public string SessionID { get; set; }

        public string Name { get; set; }
        public int AppointmentId { get; set; }
    }

    public class SessionModel
    {
        public int patientID { get; set; }
        public int? userID { get; set; }
        public int aptID { get; set; }
        public bool? fromMobile { get; set; }
        public int staffID { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }

    public class RequestModel
    {
        
      public int staffID { get; set; }
        public int patientID { get; set; }
        public int aptID { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }

    }
    public class CallNotificationModel
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
      
    }

    public class CallDetails
    {
        public long PatUserId { get; set; }
        public long ProviderID { get; set; }
        public long PatientId { get; set; }
        public string PatientName { get; set; }
        public string StaffName { get; set; }
        public long AptId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
    public class NotificationModels
    {
        public int UserId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public string NotificationTitle { get; set; }

        public int? OrganizationID { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool? IsRead { get; set; }

    }
    public class PaginationModel
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public string searchText { get; set; } = "";
      //  public int? UserId { get; set; }
    }

    public class Pagination
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public int providerId { get; set; }
        // public string searchText { get; set; } = "";
        //  public int? UserId { get; set; }
    }
    public class SendNotificationModel
    {

        public int CreatedBy { get; set; }
  
        public string Description { get; set; }

        public string GoToLink { get; set; }

        public string ImageUrl { get; set; }
  
        public string NotificationTitle { get; set; }

        public int? OrganizationID { get; set; }

        public int UserID { get; set; }

        public bool IsRead { get; set; }
        public bool isNotified { get; set; }
        public string NotificationType { get; set; }

    }
}
