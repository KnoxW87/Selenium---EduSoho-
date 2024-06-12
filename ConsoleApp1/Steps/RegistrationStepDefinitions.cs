using ConsoleApp1.Modies;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ConsoleApp1
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        [Given(@"I am in Register page")]
        public void GivenIAmInRegisterPage()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.ClickRegister();
        }

        [When(@"I enter (.*) and (.*) and (.*)")]
        public void WhenIEnterTestAndTestAndTest(string email, string nickname, string password)
        {
            var user = new Products();
            user.Email = email;
            user.Nickname = nickname;
            user.Password = password;
            Pages.RegisterPage.RegisterWithInvalidValue(user.Email, user.Nickname, user.Password);
        }

        [Then(@"Error massage (.*) is displayed")]
        public void ThenErrorMassageIsDisplayed(string error)
        {
            var expectedErrorMessage = "";

            switch (error)
            {
                case "请输入有效的电子邮件地址":
                    expectedErrorMessage = "请输入有效的电子邮件地址";
                    break;

                case "字符长度必须大于等于4，一个中文字算2个字符":
                    expectedErrorMessage = "字符长度必须大于等于4，一个中文字算2个字符";
                    break;

                case "最少需要输入 5 个字符":
                    expectedErrorMessage = "最少需要输入 5 个字符";
                    break;

                case "请输入验证码":
                    expectedErrorMessage = "请输入验证码";
                    break;

                default:
                    throw new ArgumentException($"Unsupported error type: {error}");
            }

            var actualErrorMessage = Pages.RegisterPage.ErrorMsgDisplayed(error);

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "Error message is not displayed correctly");
        }
    }
}
