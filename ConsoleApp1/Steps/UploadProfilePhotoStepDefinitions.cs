using ConsoleApp1.Modies;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ConsoleApp1
{
    [Binding]
    public class UploadProfilePhotoStepDefinitions
    {
        [Given(@"I am in the Homepage")]
        public void GivenIAmInTheHomepage()
        {
            Pages.HomePage.Goto();
        }

        [Given(@"I click loginPage")]
        public void GivenIClickLoginPage()
        {
            Pages.HomePage.ClickLogin();
        }

        [When(@"I enter the username and password")]
        public void WhenIEnterTheUsernameAndPassword(Table table)
        {
            var user = table.CreateInstance<Products>();
            Pages.LoginPage.Login(user.Name, user.Password);
        }

        [Then(@"I entry the settingPage")]
        public void ThenIEntryTheSettingPage()
        {
            Pages.HomePage.Setting();
        }

        [Then(@"Upload the profile photo")]
        public void ThenUploadTheProfilePhoto()
        {
            Pages.SettingPage.ChangeAvatar();
            Pages.ProfilephotoPage.ProfilePhoto();
        }
    }
}
