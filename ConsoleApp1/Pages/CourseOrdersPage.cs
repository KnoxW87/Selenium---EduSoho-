using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using System.Net.NetworkInformation;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace ConsoleApp1
{
    public class CourseOrdersPage
    {
        [FindsBy(How = How.ClassName, Using = "btn")]
        private IWebElement SearchBtn;

        [FindsBy(How = How.LinkText, Using = "班级订单")]
        private IWebElement ClassOrders;

        [FindsBy(How = How.Id, Using = "startDate")]
        private IWebElement Date;

        [FindsBy(How = How.Name, Using = "status")]
        private IWebElement Status;

        [FindsBy(How = How.Name, Using = "payment")]
        private IWebElement Payment;

        [FindsBy(How = How.Name, Using = "keywordType")]
        private IWebElement Keywords;


        public void SearchCourseOrders()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("btn")));

            SearchBtn.Click();
        }

        public void ClickClassOrders()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("班级订单")));

            ClassOrders.Click();
        }

        public void CustomSearch(string filter, string value)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("btn")));

            if (filter == "date")
            {
                Date.SendKeys(value);
                SearchBtn.Click();
            }
            else if (filter == "status")
            {
                Status.SendKeys(value);
                SearchBtn.Click();
            }
            else if (filter == "payment")
            {
                Payment.SendKeys(value);
                SearchBtn.Click();
            }
            else if (filter == "keyword")
            {
                Keywords.SendKeys(value);
                SearchBtn.Click();
            }
        }

        public void SearchResult(int result)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            IWebElement table = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("order-table")));

            try
            {
                IWebElement emptyOrderMsgElement = wait.Until(ExpectedConditions.ElementExists(By.ClassName("empty")));

                int expectedTr = result;
                int actualTr = 0;
                Assert.AreEqual(expectedTr, actualTr);
            }
            catch (WebDriverTimeoutException)
            {
                IWebElement tbody = table.FindElement(By.TagName("tbody"));

                ReadOnlyCollection<IWebElement> trElements = tbody.FindElements(By.TagName("tr"));

                int expectedTr = result;
                int actualTr = trElements.Count();
                Assert.AreEqual(expectedTr, actualTr);
            }

        }
    }
}
