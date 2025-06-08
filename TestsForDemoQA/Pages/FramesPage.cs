using OpenQA.Selenium;
using TestsForDemoQA.Core;
using TestsForDemoQA.Driver;
using TestsForDemoQA.Utils;

namespace TestsForDemoQA.Pages
{
    public class FramesPage : BaseForm
    {
        private static readonly By framesHeader = By.Id("framesWrapper");
        private readonly By headingLocator = By.Id("sampleHeading");

        public FramesPage() : base(framesHeader, "Frames Page")
        {
        }

        public string GetTextFromFrame(string frameId)
        {
            Browser.SwitchToFrame(frameId);
            string text = DriverSingleton.Instance.FindElement(headingLocator).Text;
            Logger.Info($"Текст во фрейме {frameId}: {text}");
            Browser.SwitchToDefaultContent();
            return text;
        }
    }
}
