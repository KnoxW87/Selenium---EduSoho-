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
    public class AdminPage
    {
        [FindsBy(How = How.LinkText, Using = "订单")]
        private IWebElement Orders;

        [FindsBy(How = How.LinkText, Using = "运营")]
        private IWebElement Article;

        public void ClickOrders()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("订单")));

            Orders.Click();
        }

        public void ClickArticle()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("运营")));

            Article.Click();
        }
    }
}
