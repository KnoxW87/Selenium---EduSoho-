using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

namespace ConsoleApp1
{
    public class CategoryManagementPage
    {
        [FindsBy(How = How.LinkText, Using = "添加栏目")]
        private IWebElement AddCategoryBtn;

        [FindsBy(How = How.Id, Using = "category-name-field")]
        private IWebElement CategoryNameField;

        [FindsBy(How = How.Id, Using = "category-code-field")]
        private IWebElement CategoryCodeField;

        [FindsBy(How = How.Id, Using = "category-seoTitle-field")]
        private IWebElement CategoryTitleField;

        [FindsBy(How = How.Id, Using = "category-seoKeyword-field")]
        private IWebElement CategoryKeywordField;

        [FindsBy(How = How.Id, Using = "category-seoDesc-field")]
        private IWebElement CategoryDescField;

        [FindsBy(How = How.Id, Using = "category-save-btn")]
        private IWebElement CategorySaveBtn;

        public void AddNewCategory(string categoryName, string categoryCode, string categoryTitle, string categoryKeyword, string categoryDesc)
        {
            AddCategoryBtn.Click();

            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("category-name-field")));

            CategoryNameField.Click();
            CategoryNameField.SendKeys(categoryName);

            CategoryCodeField.Click();
            CategoryCodeField.SendKeys(categoryCode);

            CategoryTitleField.Click();
            CategoryTitleField.SendKeys(categoryTitle);

            CategoryKeywordField.Click();
            CategoryKeywordField.SendKeys(categoryKeyword);

            CategoryDescField.Click();
            CategoryDescField.SendKeys(categoryDesc);

            CategorySaveBtn.Click();
        }

        public void AddedCategoryIsVisble(string categoryName)
        {
            Thread.Sleep(2000);
            
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            IWebElement ListTable = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("sortable-list")));

            IReadOnlyCollection<IWebElement> LiElements = ListTable.FindElements(By.TagName("li"));

            IWebElement firstLiElement = LiElements.First();
            IWebElement targetDiv = firstLiElement.FindElement(By.CssSelector("div"));

            IReadOnlyCollection<IWebElement> childDivs = targetDiv.FindElements(By.CssSelector("div"));

            string textContent = childDivs.First().Text;

            Assert.AreEqual(categoryName, textContent);
        }

        public void EditCategory(string NewName)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            IWebElement ListTable = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("sortable-list")));

            IReadOnlyCollection<IWebElement> LiElements = ListTable.FindElements(By.TagName("li"));

            IWebElement firstLiElement = LiElements.First();
            IWebElement targetDiv = firstLiElement.FindElement(By.CssSelector("div"));

            IReadOnlyCollection<IWebElement> childDivs = targetDiv.FindElements(By.CssSelector("div"));

            IWebElement LastDiv = childDivs.Last();

            IWebElement editBtn = LastDiv.FindElement(By.XPath(".//a[contains(text(), '编辑')]"));

            editBtn.Click();

            WebDriverWait wait1 = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait1.Until(ExpectedConditions.ElementIsVisible(By.Id("category-name-field")));

            CategoryNameField.Clear();
            CategoryNameField.SendKeys(NewName);

            CategorySaveBtn.Click();
        }
    }
}
