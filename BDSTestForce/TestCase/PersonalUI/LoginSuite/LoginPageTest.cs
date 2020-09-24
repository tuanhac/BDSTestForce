using BDSTestForce.Core;
using OpenQA.Selenium;
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

                        return new TestCaseResultInfo { Message = $"Done TestLoginInValid", Pass = page.isLoginSuccess() == false };
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
                        page.login("validusername", "validpassword");

                        return new TestCaseResultInfo { Message = $"Done TestLoginValid", Pass = page.isLoginSuccess() };
                    }
                    else
                        return new TestCaseResultInfo { Message = $"NotStart TestLoginInValid", Pass = false };
                }
            });
        }
    }
}
