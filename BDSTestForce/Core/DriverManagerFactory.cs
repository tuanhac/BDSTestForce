using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSTestForce.Core
{
    public static class DriverManagerFactory 
    {
        public static DriverManager getDriverManager(DriverType type) {

            switch (type) {
                case DriverType.FireFox:
                    return new FirefoxDriverManager();
                default:
                    return new ChromeDriverManager();
            }

        }
    }
}
