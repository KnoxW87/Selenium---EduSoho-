using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp1
{
    public class ListPage
    {
        [FindsBy(How = How.LinkText, Using = "产品介绍")]
        private IWebElement Product;

        public void ClickProduct()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new System.TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("产品介绍")));

            Product.Click();
        }
    }
}
