using BDSTestForce.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSTestForce.TestCase.PersonalUI.LoginSuite
{
    public class LoginPage
    {
        protected IWebDriver driver;
        private By linkLogin = By.Id("kct_login");
        private By userNameTextBox = By.Id("UserName");
        private By passwordTextBox = By.Id("Password");
        private By loginButton = By.Id("btnLogin");
        private By lblLoginMessage = By.ClassName("loginerror"); //By.XPath("//*[@id="updateInfoForm"]/div[1]/div[5]");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Navigate().GoToUrl("https://batdongsan.com.vn/");
        }

        public void login(string userName, string password) {
            this.showLoginForm();
            this.setUserName(userName);
            this.setPassword(password);
            this.clickLogin();
        }

        private void showLoginForm() {
            if (this.driver != null)
                this.driver.FindElement(this.linkLogin).Click();
        }

        private void setUserName(string userName) {
            if (this.driver != null)
                this.driver.FindElement(userNameTextBox).SendKeys(userName);
        }

        private void setPassword(string password)
        {
            if (this.driver != null)
                this.driver.FindElement(passwordTextBox).SendKeys(password);
        }

        private void clickLogin() {
            if (this.driver != null)
                this.driver.FindElement(loginButton).Click();
        }

        public string getLoginErrorMessage() {
            if (this.driver != null)
                return this.driver.FindElement(lblLoginMessage).Text;
            else
                return null;
        }

        public bool isLoginSuccess() {
            if (this.driver != null)
                return this.driver.Url.Contains("/trang-ca-nhan");
            else
                return false;
        }
    }
}
