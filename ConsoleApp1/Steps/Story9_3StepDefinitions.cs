using ConsoleApp1.Modies;
using System;
using TechTalk.SpecFlow;

namespace ConsoleApp1
{
    [Binding]
    public class Story9_3StepDefinitions
    {
        [Given(@"Go to the CategoryManegement page")]
        public void GivenGoToTheCategoryManegementPage()
        {
            Pages.ArticlePage.GotoCategpryPage();
        }

        [When(@"I add new category with (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void WhenIAddNewCategoryWithWwwAndWAndAndAnd(string categoryName, string categoryCode, string categoryTitle, string categoryKeyword, string categoryDesc)
        {
            var user = new Products();
            user.categoryName = categoryName;
            user.categoryCode = categoryCode;
            user.categoryTitle = categoryTitle;
            user.categoryKeyword = categoryKeyword;
            user.categoryDesc = categoryDesc;
            Pages.CategoryManagementPage.AddNewCategory(user.categoryName, user.categoryCode, user.categoryTitle, user.categoryKeyword, user.categoryDesc);
        }

        [Then(@"New category (.*) can be added")]
        public void ThenNewCategoryWwwCanBeAdded(string categoryName)
        {
            Pages.CategoryManagementPage.AddedCategoryIsVisble(categoryName);
        }

        [When(@"I change the Category name (.*)")]
        public void WhenIChangeTheCategoryNameQqq(string NewName)
        {
            Pages.CategoryManagementPage.EditCategory(NewName);
        }

        [Then(@"Category name (.*) is change")]
        public void ThenCategoryNameQqqIsChange(string NewName)
        {
            Pages.CategoryManagementPage.AddedCategoryIsVisble(NewName);
        }
    }
}
