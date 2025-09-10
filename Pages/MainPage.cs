using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectAutomationC__HABR.COM.Pages
{
    public class MainPage : BasePage
    {
        private By loginBtn => By.XPath("//a[contains(text(),'Войти')]");
        private By registrationFormBtn => By.XPath("//a[contains(text(),'Зарегистрируйтесь')]"); // Кнопка на форме авторизации для открытия формы регистрации
        private By registrationBtn => By.XPath("//a[contains(text(),'Регистрация')]");
        private By checkboxCaptchaBtn => By.ClassName("CheckboxCaptcha-Button");
        private By userMenu => By.CssSelector(".tm-header-user-menu");
        private By userName => By.CssSelector(".tm-user-item__username");
        public MainPage(IWebDriver driver) : base(driver)
        {

        }
        public string GetCurrentUserName()
        {
            try
            {
                return WaitForElement(userName).Text;
            }
            catch
            {
                return string.Empty;
            }
        }
        public bool IsUserLoggedIn(string username)
        {
            try
            {
                var userMenu = WaitForElement(this.userMenu);
                var userNameElement = WaitForElement(userName);
                return userNameElement.Text.Contains($"@{username}");
            }
            catch
            {
                return false; //Если проверка на авторизацию не прошла, то всегда возвращается false
            }
        }

        public LoginPage OpenLoginPage()
        {
            WaitForElement(loginBtn).Click();
            return new LoginPage(driver);
        }

        public RegistrationPage OpenRegistrationPage()
        {
            WaitForElement(loginBtn).Click();
            WaitForElement(registrationFormBtn).Click();
            return new RegistrationPage(driver);
        }
    }
}
