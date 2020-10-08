using BDSTestForce.Core;
using BDSTestForce.TestCase.PersonalUI.LoginSuite;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSTestForce.TestCase.PersonalUI.ChangPassSuite
{
    public class ChangePassTest : ChangePassPage
    {
        public ChangePassTest(IWebDriver driver) : base(driver)
        {

        }

        public static async Task<TestCaseResultInfo> TestChangePassFailure(DriverType type) {
            return await Task.Run(async () =>
            {
                Console.WriteLine($"{DateTime.Now}: begin TestChangePassFailure");

                using (DriverManager driverManager = DriverManagerFactory.getDriverManager(type))
                {
                    var driver = await driverManager.getWebDriver();
                    if (driver != null)
                    {
                        var loginPage = new LoginPage(driver);

                        loginPage.login(Config.CurrentUserEmail, Config.CurrentUserPass);
                        if (loginPage.isLoginSuccess())
                        {
                            var page = new ChangePassTest(driver);

                            page.ChangePass("invalidOldPass", "newPass@123", "newPass@321");

                            var screenShot = driverManager.takeSnapShot("ChangePassPage-TestChangePassFailure");

                            return new TestCaseResultInfo { Message = $"Done TestChangePassFailure, snapShot: {screenShot}", Pass = page.isSuccess() == false };
                        }
                        else
                        {
                            var screenShot = driverManager.takeSnapShot("ChangePassPage-TestChangePassFailure");

                            return new TestCaseResultInfo { Message = $"Done TestChangePassFailure, snapShot: {screenShot}", Pass = false };
                        }
                    }
                    else
                        return new TestCaseResultInfo { Message = $"NotStart TestChangePassFailure", Pass = false };
                }
            });
        }

        public static async Task<TestCaseResultInfo> TestChangePassSuccess(DriverType type)
        {
            return await Task.Run(async () =>
            {
                Console.WriteLine($"{DateTime.Now}: begin TestChangePassSuccess");

                using (DriverManager driverManager = DriverManagerFactory.getDriverManager(type))
                {
                    var driver = await driverManager.getWebDriver();
                    if (driver != null)
                    {
                        var loginPage = new LoginPage(driver);

                        loginPage.login(Config.CurrentUserEmail, Config.CurrentUserPass);

                        if (loginPage.isLoginSuccess())
                        {

                            var page = new ChangePassTest(driver);

                            string newPass = "Bds@123456";

                            page.ChangePass(Config.CurrentUserPass, newPass, newPass);

                            var screenShot = driverManager.takeSnapShot("ChangePassPage-TestChangePassSuccess");

                            if (page.isSuccess())
                                Config.CurrentUserPass = newPass;

                            return new TestCaseResultInfo { Message = $"Done TestChangePassSuccess, snapShot: {screenShot}", Pass = page.isSuccess() == true };
                        }
                        else
                        {
                            var screenShot = driverManager.takeSnapShot("ChangePassPage-TestChangePassSuccess");

                            return new TestCaseResultInfo { Message = $"Done TestChangePassSuccess, snapShot: {screenShot}", Pass = false };
                        }
                    }
                    else
                        return new TestCaseResultInfo { Message = $"NotStart TestChangePassSuccess", Pass = false };
                }
            });
        }
    }
}
