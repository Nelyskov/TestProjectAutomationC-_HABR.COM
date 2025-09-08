using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProjectAutomationC__HABR.COM
{
    /// <summary>
    /// Базовый класс для управления драйвером и навигации в браузере
    /// url необходимо инициализировать в .cs файле с тестами (Например, protected override string url => "https://habr.com/";
    /// </summary>
    public abstract class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected abstract string url { get; }


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
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

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
