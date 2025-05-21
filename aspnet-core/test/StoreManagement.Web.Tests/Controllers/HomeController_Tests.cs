using System.Threading.Tasks;
using StoreManagement.Models.TokenAuth;
using StoreManagement.Web.Controllers;
using Shouldly;
using Xunit;

namespace StoreManagement.Web.Tests.Controllers
{
    public class HomeController_Tests: StoreManagementWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}