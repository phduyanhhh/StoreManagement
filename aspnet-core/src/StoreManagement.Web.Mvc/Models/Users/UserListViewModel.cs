using System.Collections.Generic;
using StoreManagement.Roles.Dto;

namespace StoreManagement.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
