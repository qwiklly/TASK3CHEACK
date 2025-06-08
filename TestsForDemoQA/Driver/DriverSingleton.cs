using OpenQA.Selenium;

namespace TestsForDemoQA.Driver
{
    public static class DriverSingleton
    {
        private static IWebDriver? _driver;

        public static IWebDriver Instance => _driver ??= BrowserFactory.CreateDriver();

        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
