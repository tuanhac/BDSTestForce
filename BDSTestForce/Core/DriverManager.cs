using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSTestForce.Core
{
    public abstract class DriverManager : IDisposable
    {
        protected abstract int currSessionCount
        {
            get;
            set;
        }

        protected abstract int maxSessionCount
        {
            get;
        }

        protected abstract string DriverName {
            get;
        }

        protected Uri hubUri = new Uri("http://localhost:4444/wd/hub");

        protected IWebDriver driver;

        protected virtual async Task<bool> createWebDriver()
        {
            int count = 0;
            while (currSessionCount >= maxSessionCount)
            {
                count++;

                if (count < 100)
                {
                    Console.WriteLine($"[{count}][{this.DriverName}] waiting for new session...");

                    await Task.Delay(3000);
                }
                else
                {
                    Console.WriteLine("create driver timeout");

                    return false;
                }
            }

            currSessionCount++;

            return true;
        }

        public void quitWebDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;

                currSessionCount--;
            }
        }

        public async Task<IWebDriver> getWebDriver()
        {
            if (null == driver)
                await this.createWebDriver();

            return driver;
        }

        public string takeSnapShot(string testName)
        { 
            if (this.driver != null)
            {
                string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{testName}-{this.DriverName}-{DateTime.Now:ddMMyyyyHHmmssfff}.png");

                this.driver.TakeScreenshot().SaveAsFile(fileName: filePath, ScreenshotImageFormat.Png);

                return filePath;
            }

            return null;
        }

        public void Dispose()
        {
            this.quitWebDriver();
        }
    }
}
