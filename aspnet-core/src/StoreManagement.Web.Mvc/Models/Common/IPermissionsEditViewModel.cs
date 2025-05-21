using System.Collections.Generic;
using StoreManagement.Roles.Dto;

namespace StoreManagement.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}