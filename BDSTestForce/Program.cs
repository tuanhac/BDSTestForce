using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BDSTestForce.Core;
using BDSTestForce.TestCase.PersonalUI.LoginSuite;

namespace BDSTestForce
{
    /*
     * https://medium.com/@nitinbhardwaj6/selenium-grid-with-docker-c8ecb0d8404
     * http://localhost:4444/grid/console
     * $ docker-compose -f C:\Users\quoct\source\repos\BDSTestForce\BDSTestForce\docker-compose.yml up -d
     */
    class Program
    {   
        static async Task Main(string[] args)
        {
            //var chrome = ExecTest(DriverType.Chrome);
            //var firefox = ExecTest(DriverType.FireFox);

            var lstTask = LoginPageTest.getAllTest();

            while (lstTask.Count > 0) {
                var finished = await Task.WhenAny(lstTask);
                
                Console.WriteLine($"{DateTime.Now}: {finished.Result}");

                lstTask.Remove(finished);
            }

            //var driver = new FirefoxDriver();
            //driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Console.WriteLine($"Done");

            Console.ReadKey();
        }



        //static async Task<bool> ExecTest(DriverType type)
        //{
        //    return await Task.Run(() =>
        //    {
        //        Console.WriteLine($"begin: {type}");

        //        //return Login(DriverManagerFactory.getDriverManager(type));

        //        return false;
        //    });
        //}

        //static string Login(DriverManager driverMamanger)
        //{
        //    string title = null;
        //    var driver = driverMamanger.getWebDriver();

        //    try
        //    {
        //        // Test name: login
        //        // Step # | name | target | value
        //        // 1 | open | / | 
        //        driver.Navigate().GoToUrl("https://batdongsan.com.vn/");
        //        // 2 | click | id=kct_login | 
        //        //driver.FindElement(By.Id("kct_login")).Click();
        //        new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until<IWebElement>((dv) => dv.FindElement(By.Id("kct_login"))).Click();

        //        // 3 | type | id=UserName | quoctuan047@gmail.com
        //        driver.FindElement(By.Id("UserName")).SendKeys("quoctuan047@gmail.com");
        //        // 4 | type | id=Password | 12345678999
        //        driver.FindElement(By.Id("Password")).SendKeys("mậtkhẩutiếngviệt123A");
        //        // 5 | click | id=btnLogin | 
        //        driver.FindElement(By.Id("btnLogin")).Click();
        //        // 6 | click | linkText=Đăng tin rao bán/cho thuê | 
        //        //driver.FindElement(By.LinkText("Đăng tin rao bán/cho thuê")).Click();
        //        new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until<IWebElement>((dv) => dv.FindElement(By.LinkText("Đăng tin rao bán/cho thuê"))).Click();

        //        title = driver.Title;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        driverMamanger.quitWebDriver();
        //    }

        //    return title;
        //}
    }
}
