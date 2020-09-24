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

            List<Task<TestCaseResultInfo>> lstTask = new List<Task<TestCaseResultInfo>>();// new LoginPageTestFactory().getAllTest();

            var typeInterface = typeof(ITestSuitePageFactory);
            var lstTypeImplemented = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => p.IsClass && typeInterface.IsAssignableFrom(p));

            foreach (var type in lstTypeImplemented) {
                var obj = Activator.CreateInstance(type) as ITestSuitePageFactory;
                if (obj != null)
                    lstTask.AddRange(obj.getAllTest());
            }

            while (lstTask.Count > 0) {
                var finished = await Task.WhenAny(lstTask);

                try
                {
                    Console.WriteLine($"{DateTime.Now}: {finished.Result.Message}: pass: {finished.Result.Pass}");
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }

                lstTask.Remove(finished);
            }

            //var driver = new FirefoxDriver();
            //driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Console.WriteLine($"Done");

            Console.ReadKey();
        }
    }
}
