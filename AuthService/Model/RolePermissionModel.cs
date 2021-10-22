using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AuthService.Model
{
    public class RolePermissionsModel
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>


        [DataMember(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the RoleId
        /// </summary>

        [DataMember(Name = "RoleId")]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the ModuleId
        /// </summary>

        [DataMember(Name = "ModuleId")]
        public int ModuleId { get; set; }


        [DataMember(Name = "ScreenId")]
        public int ScreenId { get; set; }

        /// <summary>
        /// Gets or sets the ModuleId
        /// </summary>
        [DataMember(Name = "ModuleName")]
        public string ModuleName { get; set; }


        /// <summary>
        /// Gets or sets the CreatePermission
        /// </summary>
        [DataMember(Name = "CreatePermission")]
        public bool CreatePermission { get; set; }

        /// <summary>
        /// Gets or sets the EditPermission
        /// </summary>
        [DataMember(Name = "EditPermission")]
        public bool EditPermission { get; set; }

        /// <summary>
        /// Gets or sets the ViewPermission
        /// </summary>
        [DataMember(Name = "ViewPermission")]
        public bool ViewPermission { get; set; }

        /// <summary>
        /// Gets or sets the DeletePermission
        /// </summary>
        [DataMember(Name = "DeletePermission")]
        public bool DeletePermission { get; set; }

        /// <summary>
        /// Gets or sets the ResponseResult
        /// </summary>
        public string ResponseResult { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreayedOn
        /// </summary>
        [DataMember(Name = "CreatedOn")]
        public long CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedBy
        /// </summary>
        [DataMember(Name = "ModifiedBy")]
        public long ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedOn
        /// </summary>
        [DataMember(Name = "ModifiedOn")]
        public long ModifiedOn { get; set; }

        public string isVisible { get; set; }

        public int ParentModuleId { get; set; }
        public Int16 TemplateId { get; set; }

        public string NavigationLink { get; set; }

        public string iconPath { get; set; }
        public string ModuleType { get; set; }

        public List<RolePermissionsModel> subModules { get; set; }
    }
}
