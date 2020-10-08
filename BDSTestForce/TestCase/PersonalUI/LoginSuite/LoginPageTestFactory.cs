using BDSTestForce.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSTestForce.TestCase.PersonalUI.LoginSuite
{
    [Obsolete("not current in use", true)]
    public class LoginPageTestFactory : ITestSuitePageFactory
    {
        public List<Task<TestCaseResultInfo>> getAllTest()
        {
            return new List<Task<TestCaseResultInfo>>() {
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
