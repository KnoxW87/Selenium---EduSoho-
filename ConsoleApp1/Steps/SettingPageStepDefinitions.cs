using ConsoleApp1.Modies;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ConsoleApp1
{
    [Binding]
    public class SettingPageStepDefinitions
    {
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.ClickLogin();
        }

        [Given(@"login")]
        public void GivenLogin(Table table)
        {
            var user = table.CreateInstance<Products>();
            Pages.LoginPage.Login(user.Name, user.Password);
        }

        [Given(@"I am on the Setting page")]
        public void GivenIAmOnTheSettingPage()
        {
            Pages.HomePage.Setting();
        }

        [When(@"I update date with")]
        public void WhenIUpdateDateWith(Table table)
        {
            var user = table.CreateInstance<Products>();
            Pages.SettingPage.Update(user.Name, user.Gender, user.ID, user.Phone, user.Company, user.Job, user.Title, user.Signature, user.Profile, user.PersonalWebsite, user.Weibo, user.Wechat, user.QQ);
        }

        [Then(@"I can see ""([^""]*)"" message")]
        public void ThenICanSeeMessage(string acturalMsg)
        {
            var expectedMsg = "基础信息保存成功。";
            Assert.AreEqual(expectedMsg, acturalMsg);
        }

        [Given(@"Click personalsetting page")]
        public void GivenClickPersonalsettingPage()
        {
            Pages.HomePage.Setting();
        }

        [When(@"Update data with")]
        public void WhenUpdateDataWith(Table table)
        {
            var user = table.CreateInstance<Products>();
            Pages.SettingPage.Update(user.Name, user.Gender, user.ID, user.Phone, user.Company, user.Job, user.Title, user.Signature, user.Profile, user.PersonalWebsite, user.Weibo, user.Wechat, user.QQ);
        }

        [Then(@"I see errors")]
        public void ThenISeeErrors(Table table)
        {
            var expectedErrors = table.Rows.Select(row => row["error"]).ToList();
            var actualErrors = Pages.SettingPage.GetErrorMsgs();

            for (int i = 0; i < expectedErrors.Count; i++)
            {
                Assert.AreEqual(expectedErrors[i], actualErrors[i]);
            }
        }
    }
}
