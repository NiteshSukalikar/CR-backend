using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class ProfileSettingModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int16 GenderId { get; set; }
        public int ResidenceCountryId { get; set; }
        public int ResidenceStateId { get; set; }
        public int ResidenceCityId { get; set; }
        public string ResidenceAddress { get; set; }
        public string PostalCode { get; set; }
        public string Key { get; set; }
        public long UserId { get; set; }
    }
}
