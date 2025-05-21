using System.Collections.Generic;
using StoreManagement.Roles.Dto;

namespace StoreManagement.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
