using FluentAssertions.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace ConsoleApp1
{
    public class HomePage
    {
        static string Url = "http://lyratesting2.co.nz/";

        [FindsBy(How = How.LinkText, Using = "登录")]
        private IWebElement Login;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"course-list-section\"]/div/div[4]/a/i")]
        private IWebElement MoreCourse;

        [FindsBy(How = How.ClassName, Using = "avatar-xs")]
        private IWebElement Avatar;

        [FindsBy(How = How.LinkText, Using = "注册")]
        private IWebElement Register;



        public void ClickLogin()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("登录")));

            Login.Click();
        }

        public void ClickMoreCourse()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"course-list-section\"]/div/div[4]/a/i")));

            MoreCourse.Click();
        }

        public void Goto()
        {
            Browser.Goto(Url);
        }

        public void AvatarIsVisible()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("avatar-xs")));

            if (Avatar != null)
            {
                Console.WriteLine("Avatar is seen!");
            }
        }

        public void Logout()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("user-avatar-li")));

            Actions actions = new Actions(Browser.Driver2);
            IWebElement element = Browser.Driver2.FindElement(By.ClassName("user-avatar-li"));
            actions.MoveToElement(element).Perform();

            IWebElement subMenu = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("退出登录")));
            actions.MoveToElement(subMenu).Perform();

            actions.Click().Build().Perform();
        }

        public void Setting()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("user-avatar-li")));

            Actions actions = new Actions(Browser.Driver2);
            IWebElement element = Browser.Driver2.FindElement(By.ClassName("user-avatar-li"));
            actions.MoveToElement(element).Perform();

            IWebElement subMenu = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("个人设置")));
            actions.MoveToElement(subMenu).Perform();

            actions.Click().Build().Perform();
        }

        public void ClickRegister()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("注册")));

            Register.Click();
        }

        public void Admin()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("user-avatar-li")));

            Actions actions = new Actions(Browser.Driver2);
            IWebElement element = Browser.Driver2.FindElement(By.ClassName("user-avatar-li"));
            actions.MoveToElement(element).Perform();

            IWebElement subMenu = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("管理后台")));
            actions.MoveToElement(subMenu).Perform();

            actions.Click().Build().Perform();
        }
    }
}
