using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectAutomationC__HABR.COM.Pages
{
    public class LoginPage : BasePage
    {
        private By emailField => By.Name("email");
        private By passwordField => By.Name("password");
        private By checkboxCaptchaBtn => By.ClassName("CheckboxCaptcha-Button");
        private By submitBtn => By.XPath("/html/body/div[1]/div[2]/div[1]/fieldset/div[1]");
        private By errorMessage => By.CssSelector("#ident-alert");
        private By signUpBtn => By.ClassName("form-additional-message__link");
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public LoginPage EnterEmail(string email)
        {
            WaitForElement(emailField).SendKeys(email);
            return this;
        }
        public LoginPage EnterPassword(string password)
        {
            WaitForElement(passwordField).SendKeys(password);
            return this;
        }
        public MainPage SubmitLogin()
        {
            WaitForElement(checkboxCaptchaBtn).Click();
            WaitForElement(submitBtn).Click();
            return new MainPage(driver);
        }
    }
}
