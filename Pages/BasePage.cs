using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProjectAutomationC__HABR.COM.Pages
{
    /// <summary>
    /// BasePage - базовый класс для страницы
    /// В нем находится драйвер и явное ожидаение, метод для открытия страницы
    /// </summary>
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public IWebElement WaitForElement(By locator)
        {
            return wait.Until(e => e.FindElement(locator));
        }
    }
}
