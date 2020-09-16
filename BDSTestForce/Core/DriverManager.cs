using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSTestForce.Core
{
    public abstract class DriverManager : IDisposable
    {
        protected abstract int currSessionCount {
            get;
            set;
        }

        protected abstract int maxSessionCount {
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

                if (count < 10)
                {
                    Console.WriteLine($"[{count}] waiting for new session...");

                    await Task.Delay(1000);
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

        public void quitWebDriver() {
            if (driver != null)
            {
                driver.Quit();
                driver = null;

                currSessionCount--;
            }
        }

        public async Task<IWebDriver> getWebDriver() {
            if (null == driver)
                await this.createWebDriver();

            return driver;
        }

        public void Dispose()
        {
            this.quitWebDriver();
        }
    }
}
