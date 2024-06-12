using ConsoleApp1.Modies;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ConsoleApp1
{
    [Binding]
    public class LoginTestingStepDefinitions
    {
        [Given(@"I am in Homepage")]
        public void GivenIAmInHomepage()
        {
            Pages.HomePage.Goto();
        }

        [Given(@"I select login\.")]
        public void GivenISelectLogin_()
        {
            Pages.HomePage.ClickLogin();
        }

        [When(@"I enter value with")]
        public void WhenIEnterValueWith(Table table)
        {
            var user = table.CreateInstance<Products>();
            Pages.LoginPage.Login(user.Name, user.Password);
        }

        [Then(@"login is successfule and avatar is seen")]
        public void ThenLoginIsSuccessfuleAndAvatarIsSeen()
        {
            Pages.HomePage.AvatarIsVisible();
        }

        [When(@"I input value with")]
        public void WhenIInputValueWith(Table table)
        {
            var user = table.CreateInstance<Products>();
            Pages.LoginPage.Login(user.Name, user.Password);
        }

        [Then(@"login is unsuccessful and errormessage is seen")]
        public void ThenLoginIsUnsuccessfulAndErrormessageIsSeen()
        {
            Pages.LoginPage.ErrorMessageIsVisible();
        }

        [When(@"I input value and click remenber me")]
        public void WhenIInputValueAndClickRemenberMe(Table table)
        {
            var user = table.CreateInstance<Products>();
            Pages.LoginPage.LoginWithRemenberme(user.Name, user.Password);
        }

        [Then(@"login is seccessful")]
        public void ThenLoginIsSeccessful()
        {
            Pages.HomePage.AvatarIsVisible();
        }
    }
}
