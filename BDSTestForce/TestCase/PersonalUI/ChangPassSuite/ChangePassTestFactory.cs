using BDSTestForce.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSTestForce.TestCase.PersonalUI.ChangPassSuite
{
    public class ChangePassTestFactory : ITestSuitePageFactory
    {
        public List<Task<TestCaseResultInfo>> getAllTest()
        {
            return new List<Task<TestCaseResultInfo>>() {
                ChangePassTest.TestChangePassFailure(DriverType.Chrome)
                ,ChangePassTest.TestChangePassSuccess(DriverType.Chrome)
            };
        }
    }
}
