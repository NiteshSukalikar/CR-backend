using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class UserPaginationModel
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public string searchText { get; set; } = "";
        public int? organizationId { get; set; }
        public int? providerTypeId { get; set; }
        public int? userRoleId { get; set; }
    }
}
