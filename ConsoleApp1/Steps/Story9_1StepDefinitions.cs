using ConsoleApp1.Modies;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ConsoleApp1
{
    [Binding]
    public class Story9_1StepDefinitions
    {
        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.ClickLogin();
        }

        [Given(@"I login")]
        public void GivenILogin(Table table)
        {
            var user = table.CreateInstance<Products>();
            Pages.LoginPage.Login(user.Name, user.Password); 
        }

        [Given(@"I am on the info management page")]
        public void GivenIAmOnTheInfoManagementPage()
        {
            Pages.HomePage.Admin();
            Pages.AdminPage.ClickArticle();
        }

        [When(@"I search with filter (.*) and (.*) and (.*) and (.*)")]
        public void WhenISearchWithFilterAndAndAnd(string category, string keywords, string property, string status)
        {
            var user = new Products();
            user.Category = category;
            user.Keywords = keywords;
            user.Property = property;
            user.Status = status;
            Pages.ArticlePage.InfoSearch(user.Category, user.Keywords, user.Property, user.Status); 
        }

        [Then(@"I see (.*)")]
        public void ThenISee(int result)
        {
            Pages.ArticlePage.SearchResult(result);
        }
    }
}
