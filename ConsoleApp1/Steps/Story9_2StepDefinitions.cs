using NUnit.Framework;
using System;
using System.Security.AccessControl;
using TechTalk.SpecFlow;

namespace ConsoleApp1
{
    [Binding]
    public class Story9_2StepDefinitions
    {   
        private string actualStatus;
        [When(@"I change the status (.*)")]
        public void WhenIChangeTheStatus(string status)
        {
            actualStatus = Pages.ArticlePage.ChangeStatus(status);
        }

        [Then(@"I can see (.*)")]
        public void ThenICanSee(string result)
        {
            Assert.AreEqual(result, actualStatus);
        }
    }
}
