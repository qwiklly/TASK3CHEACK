using TestsForDemoQA.Utils;
using OpenQA.Selenium;
using TestsForDemoQA.Core;

namespace TestsForDemoQA.Pages
{
    public class MainPage : BaseForm
    {
        private static readonly By MainFormLocator = By.XPath("//h5[normalize-space()='Widgets']");

        private readonly Button alertsFrameWindowsButton =
            new Button(By.XPath("//h5[text()='Alerts, Frame & Windows']"), "AlertsFrameWindows Button");

        private readonly Button elementsButton =
           new Button(By.XPath("//h5[text()='Elements']"), "Elements Button");

        public MainPage() : base(MainFormLocator, "Main Page")
        {
        }

        public void ClickAlertsFrameWindows()
        {
            Logger.Info("Кликаем Alerts, Frame & Windows");
            alertsFrameWindowsButton.Click();
        }
        public void ClickElements()
        {
            Logger.Info("Кликаем Elements");
            elementsButton.Click();
        }
    }
}
