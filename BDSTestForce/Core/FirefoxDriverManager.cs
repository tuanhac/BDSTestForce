﻿using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSTestForce.Core
{
    public class FirefoxDriverManager : DriverManager
    {
        private static int _currSessionCount = 0;

        protected override int maxSessionCount => 2;
        protected override int currSessionCount
        {
            get
            {
                return _currSessionCount;
            }
            set
            {
                _currSessionCount = value;
            }
        }

        protected override async Task<bool> createWebDriver()
        {
            if (await base.createWebDriver())
            {
                var options = new FirefoxOptions();

                this.driver = new RemoteWebDriver(this.hubUri, options);

                //driver.Manage().Window.Maximize();
                driver.Manage().Window.Size = new System.Drawing.Size(1936, 1035);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                return true;
            }

            return false;
        }
    }
}
