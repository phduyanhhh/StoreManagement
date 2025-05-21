using Abp.Authorization;
using StoreManagement.Authorization.Roles;
using StoreManagement.Authorization.Users;

namespace StoreManagement.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
