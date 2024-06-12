using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ProfilephotoPage
    {
        [FindsBy(How = How.ClassName, Using = "webuploader-element-invisible")]
        private IWebElement UploadAvatarInput;

        [FindsBy(How = How.ClassName, Using = "webuploader-pick")]
        private IWebElement UploadAvatarButton;

        [FindsBy(How = How.LinkText, Using = "保存")]
        private IWebElement UploadAvatarSaveBtn;

        public void ProfilePhoto()
        {
            WebDriverWait wait1 = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait1.Until(ExpectedConditions.ElementIsVisible(By.ClassName("webuploader-element-invisible")));

            UploadAvatarInput.SendKeys("C:\\Users\\knoxw\\OneDrive\\Desktop\\pic2023.png");

            WebDriverWait wait2 = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.LinkText("保存")));

            UploadAvatarSaveBtn.Click();

            WebDriverWait wait3 = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait3.Until(ExpectedConditions.ElementIsVisible(By.ClassName("webuploader-pick")));

            Assert.True(UploadAvatarButton.Displayed);
        }
    }
}
