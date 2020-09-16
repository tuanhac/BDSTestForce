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

        public static async Task<string> TestLoginInValid(DriverType type)
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

                        return $"Done TestLoginInValid: {page.isLoginSuccess() == false}";
                    }
                    else
                        return $"NotStart TestLoginInValid";
                }
            });
        }

        public static async Task<string> TestLoginValid(DriverType type)
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

                        return $"Done TestLoginValid: {page.isLoginSuccess()}";
                    }
                    else
                        return $"NotStart TestLoginInValid";
                }
            });
        }

        public static List<Task<string>> getAllTest()
        {
            return new List<Task<string>>() {
                    LoginPageTest.TestLoginInValid(DriverType.FireFox),
                    LoginPageTest.TestLoginValid(DriverType.FireFox),
                    LoginPageTest.TestLoginInValid(DriverType.Chrome),
                    LoginPageTest.TestLoginValid(DriverType.Chrome),
                    LoginPageTest.TestLoginInValid(DriverType.Chrome),
                    LoginPageTest.TestLoginValid(DriverType.Chrome)
                };
        }
    }
}
