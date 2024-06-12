using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp1
{
    public class ResetpasswordPage
    {
        [FindsBy(How = How.Id, Using = "form_email")]
        private IWebElement EmailInput;

        [FindsBy(How = How.ClassName, Using = "btn")]
        private IWebElement SendEmailBtn;

        public void SendEmail(string email)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("form_email")));

            EmailInput.Click();
            EmailInput.SendKeys(email);
            SendEmailBtn.Click();
        }

        public string ErrorMsg(string error)
        {
            switch (error)
            {
                case "该邮箱地址没有注册过帐号":
                    WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("alertxx")));

                    String EmailNotExist = Browser.Driver2.FindElement(By.Id("alertxx")).GetAttribute("innerHTML");
                    return EmailNotExist;

                case "请输入有效的电子邮件地址":
                    WebDriverWait wait1 = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));                   
                    wait1.Until(ExpectedConditions.ElementIsVisible(By.Id("form_email-error")));

                    String EmailIsInvalid = Browser.Driver2.FindElement(By.Id("form_email-error")).GetAttribute("innerHTML");
                    return EmailIsInvalid;

                default:
                    throw new ArgumentException($"Unsupported error type: {error}");
            }
        }
    }
}
