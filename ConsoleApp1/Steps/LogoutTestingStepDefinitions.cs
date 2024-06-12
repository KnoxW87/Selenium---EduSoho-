using ConsoleApp1.Modies;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ConsoleApp1
{
    [Binding]
    public class LogoutTestingStepDefinitions
    {
        [Given(@"I am in the homepage")]
        public void GivenIAmInTheHomepage()
        {
            Pages.HomePage.Goto();
        }

        [Given(@"Go to the loginpage")]
        public void GivenGoToTheLoginpage()
        {
            Pages.HomePage.ClickLogin();
        }

        [When(@"I input valid value with")]
        public void WhenIInputValidValueWith(Table table)
        {
            var user = table.CreateInstance<Products>();
            Pages.LoginPage.Login(user.Name, user.Password);
        }

        [Then(@"Login is sucessful and click logout button")]
        public void ThenLoginIsSucessfulAndClickLogoutButton()
        {
            Pages.HomePage.Logout();
        }

        [Then(@"Logout is sucessful")]
        public void ThenLogoutIsSucessful()
        {
            Pages.LoginPage.isLoginPage();
        }
    }
}
