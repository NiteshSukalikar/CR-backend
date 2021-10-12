using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.ViewModel
{
    public class DateRegistationVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DOD { get; set; }
        public DateTime? DeathDate { get; set; }

        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long PatientId { get; set; }
        public int Gender { get; set; }
        public string MotherLastName { get; set; }
        public string FatherLastName { get; set; }
        public string PlaceOfOccurrenceOfDeath { get; set; }
        public int TypeOfPlaceOfOccurrence { get; set; }
        public string CauseOfDeath { get; set; }
        public int Certifier { get; set; }
        public string GenderName { get; set; }
        public string PatientName { get; set; }
        public string MobileNumber { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
        public long TotalRecords { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
