using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSTestForce.Core
{
    public interface ITestSuitePageFactory
    {
        List<Task<TestCaseResultInfo>> getAllTest();
    }
}
