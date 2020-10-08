using BDSTestForce.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSTestForce.TestCase.PersonalUI.LoginSuite
{
    public class LoginPageTest : LoginPage
    {
        //DriverManager driverManager;
        //IWebDriver driver;
        //LoginPage loginPage;

        public LoginPageTest(IWebDriver driver) : base(driver)
        {

        }

        public static async Task<TestCaseResultInfo> TestLoginInValid(DriverType type)
        {
            return await Task.Run(async () =>
            {
                Console.WriteLine($"{DateTime.Now}: begin TestLoginInValid");

                using (DriverManager driverManager = DriverManagerFactory.getDriverManager(type))
                {
                    var driver = await driverManager.getWebDriver();
                    if (driver != null)
                    {
                        var page = new LoginPageTest(driver);
                        page.login("invalidusername", "invalidpassword");

                        var screenShot = driverManager.takeSnapShot("LoginPage-TestLoginInValid");

                        return new TestCaseResultInfo { Message = $"Done TestLoginInValid, snapShot: {screenShot}", Pass = page.isLoginSuccess() == false };
                    }
                    else
                        return new TestCaseResultInfo { Message = $"NotStart TestLoginInValid", Pass = false };
                }
            });
        }

        public static async Task<TestCaseResultInfo> TestLoginValid(DriverType type)
        {
            return await Task.Run(async () =>
            {
                Console.WriteLine($"{DateTime.Now}: begin TestLoginValid");

                using (DriverManager driverManager = DriverManagerFactory.getDriverManager(type))
                {
                    var driver = await driverManager.getWebDriver();
                    if (driver != null)
                    {
                        var page = new LoginPageTest(driver);
                        page.login(Config.CurrentUserEmail, Config.CurrentUserPass);

                        var screenShot = driverManager.takeSnapShot("LoginPage-TestLoginValid");

                        return new TestCaseResultInfo { Message = $"Done TestLoginValid, snapShot: {screenShot}", Pass = page.isLoginSuccess() };
                    }
                    else
                        return new TestCaseResultInfo { Message = $"NotStart TestLoginInValid", Pass = false };
                }
            });
        }
    }
}
