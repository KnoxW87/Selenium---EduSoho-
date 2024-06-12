using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ConsoleApp1.Steps
{
    [Binding]
    public class Hooks
    {

        [BeforeScenario]
        public void InitDriver()
        {
            Browser.InitDriver();
        }

        [AfterScenario]
        public void CleanupDriver()
        {
            Browser.Close();
        }
    }
}
