using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class BirthPaginationModel
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public string searchText { get; set; } = "";

        public int? OrganizationId { get; set; }
    }
}
