using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestsForDemoQA.Config;

namespace TestsForDemoQA.Driver
{
    public static class BrowserFactory
    {
        public static IWebDriver CreateDriver()
        {
            IWebDriver driver;

            switch (ConfigReader.BrowserName)
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument(ConfigReader.VisibilityForBrowser);
                    chromeOptions.AddArgument($"--lang={ConfigReader.Language}");
                    chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument(ConfigReader.VisibilityForBrowser);
                    firefoxOptions.SetPreference("intl.accept_languages", ConfigReader.Language);
                    firefoxOptions.PageLoadStrategy = PageLoadStrategy.Eager;
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                default:
                    throw new ArgumentException($"Браузер {ConfigReader.BrowserName} не поддерживается");
            }

            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
