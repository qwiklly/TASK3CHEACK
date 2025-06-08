using OpenQA.Selenium;
using TestsForDemoQA.Driver;
using TestsForDemoQA.Utils;

namespace TestsForDemoQA.Core
{
    public class BaseForm
    {
        protected readonly By FormLocator;
        protected readonly string FormName;

        public BaseForm(By locator, string name)
        {
            FormLocator = locator;
            FormName = name;
            Logger.Info($"Открыта форма '{FormName}'");
        }

        public bool IsDisplayed()
        {
            try
            {
                var element = WaitHelper.WaitUntilVisible(DriverSingleton.Instance, FormLocator);
                Logger.Info($"Форма '{FormName}' отображается: {element.Displayed}");
                return element.Displayed;
            }
            catch (Exception ex)
            {
                Logger.Error($"Форма '{FormName}' не найдена: {ex.Message}");
                return false;
            }
        }

        public void WaitForForm()
        {
            Logger.Info($"Ожидание отображения формы '{FormName}'");
            WaitHelper.WaitUntilVisible(DriverSingleton.Instance, FormLocator);
        }
    }
}
