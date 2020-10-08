using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BDSTestForce.TestCase.PersonalUI.ChangPassSuite
{
    public class ChangePassPage
    {
        protected IWebDriver driver;

        private By linkChangePass = By.LinkText("Thay đổi mật khẩu");
        private By txtOldPass = By.Id("MainContent__userPage_ctl00_txtOldPass");
        private By txtNewPass = By.Id("MainContent__userPage_ctl00_txtNewPass");
        private By txtConfirmNewPass = By.Id("MainContent__userPage_ctl00_txtConfirmNewPass");
        private By BtnSave = By.Id("MainContent__userPage_ctl00_BtnSave");
        private By lblMessage = By.CssSelector("td:nth-child(2) > span");

        public ChangePassPage(IWebDriver driver)
        {
            this.driver = driver;
            
            if (this.driver.Url.Contains("/trang-ca-nhan") == false)
                throw new ArgumentException($"Driver must in /trang-ca-nhan page: {this.driver.Url}");

            // 7 | click | linkText=Thay đổi mật khẩu | 
            driver.FindElement(this.linkChangePass).Click();
        }

        public void ChangePass(string oldPass, string newPass, string confirmPass) {
            // 9 | type | id=MainContent__userPage_ctl00_txtOldPass | 
            driver.FindElement(this.txtOldPass).SendKeys(oldPass);
            // 11 | type | id=MainContent__userPage_ctl00_txtNewPass
            driver.FindElement(this.txtNewPass).SendKeys(newPass);
            // 12 | type | id=MainContent__userPage_ctl00_txtConfirmNewPass
            driver.FindElement(this.txtConfirmNewPass).SendKeys(confirmPass);
            // 13 | click | id=MainContent__userPage_ctl00_BtnSave | 
            driver.FindElement(this.BtnSave).Click();
        }

        public bool isSuccess()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            wait.Until(d => driver.FindElement(this.lblMessage).Displayed);

            return driver.FindElement(this.lblMessage).Text.Equals("Cập nhật mật khẩu thành công");
        }
    }
}
