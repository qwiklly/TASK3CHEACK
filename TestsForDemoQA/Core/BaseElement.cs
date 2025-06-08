using OpenQA.Selenium;
using TestsForDemoQA.Driver;
using TestsForDemoQA.Utils;

namespace TestsForDemoQA.Core
{
    public class BaseElement
    {
        protected readonly By Locator;
        protected readonly string Name;

        public BaseElement(By locator, string name)
        {
            Locator = locator;
            Name = name;
        }

        private IWebElement FindElement()
        {
            return WaitHelper.WaitUntilVisible(DriverSingleton.Instance, Locator)
                  ?? throw new NoSuchElementException($"Элемент '{Name}' ({Locator}) не найден");
        }

        public void Click()
        {
            try
            {
                Logger.Info($"Клик по элементу '{Name}' ({Locator})");
                var element = WaitHelper.WaitUntilClickable(DriverSingleton.Instance, Locator);
                element.Click();
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error($"Не удалось кликнуть по элементу '{Name}' ({Locator}). {ex.Message}");
                throw new InvalidOperationException($"Не удалось кликнуть по элементу '{Name}' ({Locator}). {ex.Message}");
            }
        }

        public string GetText()
        {
            try
            {
                Logger.Info($"Получен текст из элемента '{Name}'");
                return FindElement().Text;
            }
            catch (NoSuchElementException ex)
            {
                Logger.Error($"Не удалось найти элемент '{Name}' по локатору {Locator}. Ошибка: {ex.Message}");
                throw new InvalidOperationException($"Не удалось получить текст '{Name}' ({Locator}). {ex.Message}");
            }
        }
    }
}
