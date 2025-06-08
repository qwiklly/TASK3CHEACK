using OpenQA.Selenium;
using TestsForDemoQA.Core;
using TestsForDemoQA.Driver;
using TestsForDemoQA.Utils;

namespace TestsForDemoQA.Pages
{
    public class NestedFramesPage : BaseForm
    {
        private static readonly By nestedFramesHeader = By.Id("framesWrapper");
        private readonly By parentFrameLocator = By.XPath("//*[contains(text(),'Parent frame')]");
        private readonly By childFrameLocator = By.TagName("p");

        public NestedFramesPage() : base(nestedFramesHeader, "Nested Frames Page")
        {
        }

        public string GetParentFrameText()
        {
            Browser.SwitchToFrame("frame1");
            string parentText = DriverSingleton.Instance.FindElement(parentFrameLocator).Text;
            Logger.Info($"Parent Frame text: {parentText}");
            Browser.SwitchToDefaultContent();
            return parentText;
        }

        public string GetChildFrameText()
        {
            Browser.SwitchToFrame("frame1");
            Browser.SwitchToFrame(0);
            string childText = DriverSingleton.Instance.FindElement(childFrameLocator).Text;
            Logger.Info($"Child Frame text: {childText}");
            Browser.SwitchToDefaultContent();
            return childText;
        }
    }
}
