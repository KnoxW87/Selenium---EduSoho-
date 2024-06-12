using ConsoleApp1.Modies;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ConsoleApp1
{
    [Binding]
    public class OrdersTestingStepDefinitions
    {
        [Given(@"I am on the HomePage")]
        public void GivenIAmOnTheHomePage()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.ClickLogin();
        }

        [Given(@"I Login with")]
        public void GivenILoginWith(Table table)
        {
            var user = table.CreateInstance<Products>();
            Pages.LoginPage.Login(user.Name, user.Password);
        }

        [Given(@"I go to AdminPage")]
        public void GivenIGoToAdminPage()
        {
            Pages.HomePage.Admin();
        }

        [Given(@"I am on the CoursePage")]
        public void GivenIAmOnTheCoursePage()
        {
            Pages.AdminPage.ClickOrders();
        }

        [When(@"I click Search Button")]
        public void WhenIClickSearchButton()
        {
            Pages.CourseOrdersPage.SearchCourseOrders();
        }

        [Then(@"I see <(.*)> results\.")]
        public void ThenISeeResults_(int result)
        {
            Pages.CourseOrdersPage.SearchResult(result);
        }

        [Given(@"I am on the ClassPage")]
        public void GivenIAmOnTheClassPage()
        {
            Pages.AdminPage.ClickOrders();
            Pages.CourseOrdersPage.ClickClassOrders();
        }

        [When(@"I do course order search with filter (.*) and (.*)")]
        public void WhenIDoCourseOrderSearchWithFilterDateAnd(string filter, string value)
        {
            var user = new Products();
            user.Filter = filter;
            user.Value = value;
            Pages.CourseOrdersPage.CustomSearch(user.Filter, user.Value);
        }

        [Then(@"I see (.*) course orders")]
        public void ThenISeeCourseOrders(int result)
        {
            Pages.CourseOrdersPage.SearchResult(result);
        }

        [When(@"I do class order search with filter (.*) and (.*)")]
        public void WhenIDoClassOrderSearchWithFilterDateAnd(string filter, string value)
        {
            var user = new Products();
            user.Filter = filter;
            user.Value = value;
            Pages.ClassOrdersPage.CustomSearch(user.Filter, user.Value);
        }

        [Then(@"I see (.*) class orders")]
        public void ThenISeeClassOrders(int result)
        {
            Pages.ClassOrdersPage.SearchResult(result);
        }
    }
}
