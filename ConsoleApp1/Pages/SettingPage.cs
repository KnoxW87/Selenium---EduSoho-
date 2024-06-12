using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SettingPage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='/settings/avatar']")]
        private IWebElement AvatarSetting;

        [FindsBy(How = How.Id, Using = "profile_truename")]
        private IWebElement Name;

        [FindsBy(How = How.Id, Using = "profile_gender_0")]
        private IWebElement GenderMale;

        [FindsBy(How = How.Id, Using = "profile_gender_1")]
        private IWebElement GenderFemale;

        [FindsBy(How = How.Id, Using = "profile_idcard")]
        private IWebElement Id;

        [FindsBy(How = How.Id, Using = "profile_mobile")]
        private IWebElement Phone;

        [FindsBy(How = How.Id, Using = "profile_company")]
        private IWebElement Company;

        [FindsBy(How = How.Id, Using = "profile_job")]
        private IWebElement Job;

        [FindsBy(How = How.Id, Using = "profile_title")]
        private IWebElement Title;

        [FindsBy(How = How.Id, Using = "profile_signature")]
        private IWebElement Signature;

        [FindsBy(How = How.TagName, Using = "textarea")]
        private IWebElement Profile;

        [FindsBy(How = How.Id, Using = "profile_site")]
        private IWebElement PersonalWebsite;

        [FindsBy(How = How.Id, Using = "weibo")]
        private IWebElement Weibo;

        [FindsBy(How = How.Id, Using = "profile_weixin")]
        private IWebElement Wechat;

        [FindsBy(How = How.Id, Using = "profile_qq")]
        private IWebElement QQ;

        [FindsBy(How = How.Id, Using = "profile-save-btn")]
        private IWebElement SaveBtn;


        public void ChangeAvatar()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='/settings/avatar']")));

            AvatarSetting.Click();
        }

       public void Update(string name, string gender, string id, string phone, string company, string job, string title, string signature, string profile, string personalwebsite, string weibo, string wechat, string qq)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan (0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile_truename")));

            Name.Click();
            Name.Clear();
            Name.SendKeys(name);

            if (gender == "male") {
                GenderMale.Click();
            }
            else
            {
                GenderFemale.Click();
            }

            Id.Click();
            Id.Clear();
            Id.SendKeys(id);

            Phone.Click();
            Phone.Clear();
            Phone.SendKeys(phone);

            Company.Click();
            Company.Clear();
            Company.SendKeys(company);

            Job.Click();
            Job.Clear();
            Job.SendKeys(job);

            Title.Click();
            Title.Clear();
            Title.SendKeys(title);

            Signature.Click();
            Signature.Clear();
            Signature.SendKeys(signature);

            Profile.Click();
            Profile.Clear();
            Profile.SendKeys(profile);

            PersonalWebsite.Click();
            PersonalWebsite.Clear();
            PersonalWebsite.SendKeys(personalwebsite);

            Weibo.Click();
            Weibo.Clear();
            Weibo.SendKeys(weibo);

            Wechat.Click();
            Wechat.Clear();
            Wechat.SendKeys(wechat);

            QQ.Click();
            QQ.Clear();
            QQ.SendKeys(qq);

            SaveBtn.Click();
        }

        public List<string> GetErrorMsgs()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile_truename-error")));

            List<string> errMsgs = new List<string>
            {
                Browser.Driver2.FindElement(By.Id("profile_truename-error")).GetAttribute("innerHTML"),
                Browser.Driver2.FindElement(By.Id("profile_idcard-error")).GetAttribute("innerHTML"),
                Browser.Driver2.FindElement(By.Id("profile_mobile-error")).GetAttribute("innerHTML"),
                Browser.Driver2.FindElement(By.Id("profile_title-error")).GetAttribute("innerHTML"),
                Browser.Driver2.FindElement(By.Id("profile_site-error")).GetAttribute("innerHTML"),
                Browser.Driver2.FindElement(By.Id("weibo-error")).GetAttribute("innerHTML"),
                Browser.Driver2.FindElement(By.Id("profile_qq-error")).GetAttribute("innerHTML")
            };

            return errMsgs;
        }
    }
}
