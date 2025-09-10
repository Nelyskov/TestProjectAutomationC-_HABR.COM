using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectAutomationC__HABR.COM.Pages;

namespace TestProjectAutomationC__HABR.COM.Tests
{
    [TestFixture]
    public class Tests : TestBase
    {
        protected override string url => "https://habr.com/ru/feed/";

        [Test]
        public void SuccessfullLogin_WithValidCredentials()
        {
            string email = "nlyskv12@gmail.com";
            string password = "Giftrat143";
            string expectedUsername = "Deepseeker";

            var loginPage = mainPage.OpenLoginPage();
            var resultPage = loginPage.EnterEmail(email).EnterPassword(password).SubmitLogin();

            Assert.That(mainPage.IsUserLoggedIn(expectedUsername));
        }
    }
}
