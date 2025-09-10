using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectAutomationC__HABR.COM.Pages;

namespace TestProjectAutomationC__HABR.COM.Tests
{
    /// <summary>
    /// Базовый класс для создания драйвера / завершения работы
    /// url - обязательное открытие url в методе Setup(). Поэтому при создании тестов/тестовый фикстуры - перезаписать url
    /// В классе BasePage (BasePage.cs) - добавлен метод для свободного перемещения по страницами - public void NavigateTo(string url)
    /// </summary>
    public abstract class TestBase
    {
        private IWebDriver driver;
        protected MainPage mainPage;
        protected abstract string url { get; }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            mainPage = new MainPage(driver);
            mainPage.NavigateTo("https://habr.com/");
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
