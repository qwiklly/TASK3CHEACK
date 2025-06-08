using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace TestsForDemoQA.Utils
{
    public static class WaitHelper
    {
        public static IWebElement WaitUntilVisible(IWebDriver driver, By locator, int timeout = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public static IWebElement WaitUntilClickable(IWebDriver driver, By locator, int timeout = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public static void WaitUntilElementCountChanges(IWebDriver driver, By locator, int oldCount, int timeout = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => d.FindElements(locator).Count != oldCount);
        }
        public static IWebElement WaitUntilElementWithTextAppears(IWebDriver driver, By locator, string text, int timeout = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(d =>
            {
                var elements = d.FindElements(locator);
                return elements.FirstOrDefault(e =>
                    !string.IsNullOrWhiteSpace(e.Text) &&
                    e.Text.Trim().Contains(text, StringComparison.OrdinalIgnoreCase));
            });
        }
    }
}
