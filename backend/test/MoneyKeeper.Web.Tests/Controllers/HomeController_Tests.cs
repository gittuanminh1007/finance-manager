using System.Threading.Tasks;
using MoneyKeeper.Models.TokenAuth;
using MoneyKeeper.Web.Controllers;
using Shouldly;
using Xunit;

namespace MoneyKeeper.Web.Tests.Controllers
{
    public class HomeController_Tests: MoneyKeeperWebTestBase
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