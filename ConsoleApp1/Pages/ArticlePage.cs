using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System.Threading;

namespace ConsoleApp1
{
    public class ArticlePage
    {
        [FindsBy(How = How.Id, Using = "s2id_autogen1")]
        private IWebElement Category;

        [FindsBy(How = How.ClassName, Using = "select2-input")]
        private IWebElement CategoryInput;

        [FindsBy(How = How.ClassName, Using = "select2-results-dept-0")]
        private IWebElement CategoryInputSection;

        [FindsBy(How = How.Name, Using = "keywords")]
        private IWebElement Keywords;

        [FindsBy(How = How.Name, Using = "property")]
        private IWebElement Property;

        [FindsBy(How = How.Name, Using = "status")]
        private IWebElement Status;

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        private IWebElement SearchBtn;

        [FindsBy(How = How.CssSelector, Using = "a[title='栏目管理']")]
        private IWebElement CategoryPageBtn;

        public void InfoSearch(string category, string keywords, string property, string status)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("btn")));

            if (category != "")
            {
                Category.Click();

                WebDriverWait wait1 = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
                wait1.Until(ExpectedConditions.ElementIsVisible(By.ClassName("select2-input")));

                CategoryInput.Click();
                CategoryInput.SendKeys(category);

                WebDriverWait wait2 = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
                wait2.Until(ExpectedConditions.ElementIsVisible(By.ClassName("select2-results-dept-0")));

                CategoryInputSection.Click();
            }

            if (keywords != "")
            {
                Keywords.Click();
                Keywords.SendKeys(keywords);
            }

            if (property != "")
            {
                Property.Click();
                SelectElement select = new SelectElement(Property);
                select.SelectByText(property);
            }

            if (status != "")
            {
                Status.Click();
                SelectElement select = new SelectElement(Status);
                select.SelectByText(status);
            }

            SearchBtn.Click();
        }

        public void SearchResult(int result)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            IWebElement table = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("article-table")));

            
            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.ClassName("empty")));

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

        public string ChangeStatus(string status)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("btn-primary")));

            SearchBtn.Click();

            WebDriverWait wait1 = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait1.Until(ExpectedConditions.ElementIsVisible(By.LinkText("编辑")));

            IWebElement SearchStatus = Browser.Driver2.FindElement(By.XPath($"//tr[.//span[text()='{status}']]"));
            string IdOfSearchStatus = SearchStatus.GetAttribute("id");
            IWebElement Id = Browser.Driver2.FindElement(By.Id(IdOfSearchStatus));
            IReadOnlyCollection<IWebElement> targetTd = Id.FindElements(By.TagName("td"));
            IWebElement LastTd = targetTd.Last();
            IWebElement targetDiv = LastTd.FindElement(By.TagName("div"));
            IWebElement DropdownToggle = targetDiv.FindElement(By.ClassName("dropdown-toggle"));
            DropdownToggle.Click();

            IWebElement UlElement = targetDiv.FindElement(By.TagName("ul"));
            IReadOnlyCollection<IWebElement> LiElement = UlElement.FindElements(By.TagName("li"));
            IWebElement button = LiElement.First();
            button.Click();

            Thread.Sleep(2000);

            string afterChangeStatus = status == "未发布" ? "已发布" : "未发布";
            return afterChangeStatus;
        }

        public void GotoCategpryPage()
        {
            CategoryPageBtn.Click();
        }
    }
}
