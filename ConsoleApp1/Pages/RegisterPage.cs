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
    public class RegisterPage
    {
        [FindsBy(How = How.Id, Using = "register_email")]
        private IWebElement Email;

        [FindsBy(How = How.Id, Using = "register_nickname")]
        private IWebElement Nickname;

        [FindsBy(How = How.Id, Using = "register_password")]
        private IWebElement Password;

        //[FindsBy(How = How.Id, Using = "captcha_code")]
        //private IWebElement CaptchaCode;

        [FindsBy(How = How.Id, Using = "register-btn")]
        private IWebElement RegisterBtn;


        
         public void RegisterWithInvalidValue(string email, string nickname, string password)//, string captchacode)
         {
             WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
             wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register_email")));

             Email.Click();
             Email.SendKeys(email);
             Nickname.Click();
             Nickname.SendKeys(nickname);
             Password.Click();
             Password.SendKeys(password);
             //CaptchaCode.Click();
             //CaptchaCode.SendKeys(captchacode);
             RegisterBtn.Click();
         }

        public string ErrorMsgDisplayed(string error)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver2, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("captcha_code-error")));

            switch (error)
            {
                case "请输入有效的电子邮件地址":
                    String EmailErrorMsg = Browser.Driver2.FindElement(By.Id("register_email-error")).GetAttribute("innerHTML");
                    return EmailErrorMsg;
                    //String ExpectEmailErrorMsg = "请输入有效的电子邮件地址";

                case "字符长度必须大于等于4，一个中文字算2个字符":
                    String NicknameErrorMsg = Browser.Driver2.FindElement(By.Id("register_nickname-error")).GetAttribute("innerHTML");
                    return NicknameErrorMsg;
                    //String ExpectNicknameErrorMsg = "字符长度必须大于等于4，一个中文字算2个字符";

                case "最少需要输入 5 个字符":
                    String PasswordErrorMsg = Browser.Driver2.FindElement(By.Id("register_password-error")).GetAttribute("innerHTML");
                    return PasswordErrorMsg;
                    //String ExpectPasswordErrorMsg = "最少需要输入 5 个字符";

                case "请输入验证码":
                    String CaptchacodeErrorMsg = Browser.Driver2.FindElement(By.Id("captcha_code-error")).GetAttribute("innerHTML");
                    return CaptchacodeErrorMsg;
                    //String ExpectCaotchacodeErrorMsg = "验证码错误";

                default:
                    throw new ArgumentException($"Unsupported error type: {error}");
            }

         }       
    }
}
