using OpenQA.Selenium.Support.PageObjects;
using System.Security.Policy;

namespace ConsoleApp1
{
    public static class Pages
    {
        public static HomePage HomePage
        {
            get
            {
                var homePage = new HomePage();
                PageFactory.InitElements(Browser.Driver, homePage);
                return homePage;
            }
        }

        public static LoginPage LoginPage
        {
            get
            {
                var loginPage = new LoginPage();
                PageFactory.InitElements(Browser.Driver, loginPage);
                return loginPage;
            }
        }

        public static ListPage ListPage
        {
            get
            {
                var listPage = new ListPage();
                PageFactory.InitElements(Browser.Driver, listPage);
                return listPage;
            }
        }

        public static SettingPage SettingPage
        {
            get
            {
                var settingPage = new SettingPage();
                PageFactory.InitElements(Browser.Driver, settingPage);
                return settingPage;
            }
        }

        public static ProfilephotoPage ProfilephotoPage
        {
            get
            {
                var profilephotoPage = new ProfilephotoPage();
                PageFactory.InitElements(Browser.Driver, profilephotoPage);
                return profilephotoPage;
            }
        }

        public static RegisterPage RegisterPage
        {
            get
            {
                var registerPage = new RegisterPage();
                PageFactory.InitElements(Browser.Driver, registerPage);
                return registerPage;
            }
        }

        public static ResetpasswordPage ResetpasswordPage
        {
            get
            {
                var resetpasswordPage = new ResetpasswordPage();
                PageFactory.InitElements(Browser.Driver, resetpasswordPage);
                return resetpasswordPage;
            }
        }

        public static AdminPage AdminPage
        {
            get
            {
                var adminPage = new AdminPage();
                PageFactory.InitElements(Browser.Driver, adminPage);
                return adminPage;
            }
        }

        public static ClassOrdersPage ClassOrdersPage
        {
            get
            {
                var classOrdersPage = new ClassOrdersPage();
                PageFactory.InitElements(Browser.Driver, classOrdersPage);
                return classOrdersPage;
            }
        }

        public static CourseOrdersPage CourseOrdersPage
        {
            get
            {
                var courseOrdersPage = new CourseOrdersPage();
                PageFactory.InitElements(Browser.Driver, courseOrdersPage);
                return courseOrdersPage;
            }
        }

        public static ArticlePage ArticlePage
        {
            get
            {
                var articlePage = new ArticlePage();
                PageFactory.InitElements(Browser.Driver, articlePage);
                return articlePage;
            }
        }

        public static CategoryManagementPage CategoryManagementPage
        {
            get
            {
                var categoryManagementPage = new CategoryManagementPage();
                PageFactory.InitElements(Browser.Driver, categoryManagementPage);
                return categoryManagementPage;
            }
        }
    }
}
