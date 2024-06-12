using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace ConsoleApp1
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "login_username")]
        private IWebElement Username;

        [FindsBy(How = How.Id, Using = "login_password")]
        private IWebElement Password;

        [FindsBy(How = How.ClassName, Using = "js-btn-login")]
        private IWebElement Button;

        private String isChecked = Browser.Driver2.FindElement(By.TagName("input")).GetAttribute("checked");

        [FindsBy(How = How.LinkText, Using = "找回密码")]
        private IWebElement PasswordRest;

        public void Login(string name, string password)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_username")));

            Username.Click();
            Username.SendKeys(name);
            Password.Click();
            Password.SendKeys(password);
            Button.Click();
        }

        public void ErrorMessageIsVisible()
        {
            String actualMsg = Browser.Driver2.FindElement(By.XPath("//*[@id=\"login-form\"]/div[1]")).GetAttribute("innerHTML");
            String errorMsg = "用户名或密码错误";

            if (actualMsg.Contains(errorMsg))
            {
                Console.WriteLine(errorMsg);
            }
            else
            {
                Console.WriteLine("Test Case Failed");
            }
        }


        public void LoginWithRemenberme(string name, string password)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_username")));

            Username.Click();
            Username.SendKeys(name);
            Password.Click();
            Password.SendKeys(password);

            if (isChecked == "false")
            {
                Browser.Driver2.FindElement(By.TagName("input")).Click();
            }

            Button.Click();
        }

        public void isLoginPage()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_username")));

            Browser.Title.Contains("登录 - EduSoho网络课堂 - 三分钟帮助您建设功能完备的网校！ - Powered By EduSoho");
       }

        public void ClickPasswordRest()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("找回密码")));

            PasswordRest.Click();
        }
    }
}
