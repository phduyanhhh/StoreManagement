using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using StoreManagement.Controllers;

namespace StoreManagement.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : StoreManagementControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
