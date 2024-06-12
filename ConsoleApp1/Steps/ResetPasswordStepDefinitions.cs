using ConsoleApp1.Modies;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ConsoleApp1
{
    [Binding]
    public class ResetPasswordStepDefinitions
    {
        [Given(@"I am in Resetpassword page")]
        public void GivenIAmInResetpasswordPage()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.ClickLogin();
            Pages.LoginPage.ClickPasswordRest();
        }

        [When(@"I enter an (.*) address")]
        public void WhenIEnterAnAddress(string email)
        {
            var user = new Products();
            user.Email = email;
            Pages.ResetpasswordPage.SendEmail(user.Email);
        }

        [Then(@"I can see (.*) massage")]
        public void ThenICanSeeMassage(string error)
        {
            var expectedErrorMessage = "";

            switch (error)
            {
                case "该邮箱地址没有注册过帐号":
                    expectedErrorMessage = "该邮箱地址没有注册过帐号";
                    break;

                case "请输入有效的电子邮件地址":
                    expectedErrorMessage = "请输入有效的电子邮件地址";
                    break;

                default:
                    throw new ArgumentException($"Unsupported error type: {error}");
            }

            var actualErrorMessage = Pages.ResetpasswordPage.ErrorMsg(error);

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "Error message is not displayed correctly");
        }
    }
}
