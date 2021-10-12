using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class UserDeleteVM
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Required]
        [DataMember(Name = "Id")]
        public long Id { get; set; }
        public int OrgId { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        [DataMember(Name = "UserId")]
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the IsDeleted
        /// </summary>
        [DataMember(Name = "IsDeleted")]
        public Boolean IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the DeletedBy
        /// </summary>
        [DataMember(Name = "DeletedBy")]
        public long DeletedBy { get; set; }

        /// <summary>
        /// Gets or sets the DeletedOn
        /// </summary>
        [DataMember(Name = "DeletedOn")]
        public DateTime DeletedOn { get; set; }

        /// <summary>
        /// Gets or sets the ResponseResult
        /// </summary>
        public string ResponseResult { get; set; }

    }
}
