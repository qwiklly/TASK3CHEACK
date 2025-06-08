using OpenQA.Selenium;
using TestsForDemoQA.Core;
using TestsForDemoQA.Driver;
using TestsForDemoQA.Utils;

namespace TestsForDemoQA.Pages
{
    public class AlertsPage : BaseForm
    {
        private static readonly By Header = By.Id("javascriptAlertsWrapper");

        private readonly Button clickMeButton =
            new Button(By.Id("alertButton"), "ClickMe Alert Button");

        private readonly Button confirmButton =
            new Button(By.Id("confirmButton"), "Confirm Alert Button");

        private readonly Button promptButton =
            new Button(By.Id("promtButton"), "Prompt Alert Button");

        private readonly BaseElement confirmResultText =
            new BaseElement(By.Id("confirmResult"), "Confirm Result Text");

        private readonly BaseElement promptResultText =
            new BaseElement(By.Id("promptResult"), "Prompt Result Text");

        public AlertsPage() : base(Header, "Alerts Page")
        {
        }

        public void ClickSimpleAlert()
        {
            clickMeButton.Click();
            Logger.Info("Кликаем кнопку Simple Alert");
        }

        public string GetAlertText()
        {
            return Browser.GetAlertText();
        }

        public void AcceptAlert()
        {
            Browser.AcceptAlert();
        }

        public bool IsAlertPresent()
        {
            try
            {
                DriverSingleton.Instance.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public bool IsAlertClosed()
        {
            return !IsAlertPresent();
        }

        public void ClickConfirmAlert()
        {
            Logger.Info("Кликаем кнопку Confirm Alert");
            confirmButton.Click();
        }

        public string GetConfirmResult()
        {
            return confirmResultText.GetText();
        }

        public void ClickPromptAlert()
        {
            Logger.Info("Кликаем кнопку Prompt Alert");
            promptButton.Click();
        }

        public void SendTextToPrompt(string text)
        {
            Browser.SendKeysToAlert(text);
            Logger.Info($"Вводим текст в Prompt: {text}");
        }

        public string GetPromptResult()
        {
            return promptResultText.GetText();
        }
    }
}
