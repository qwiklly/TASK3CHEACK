using OpenQA.Selenium;
using TestsForDemoQA.Core;

namespace TestsForDemoQA.Pages
{
    public class BrowserWindowsPage : BaseForm
    {
        private static readonly By Header = By.Id("browserWindows");
        private readonly Button newTabBtn = new Button(By.Id("tabButton"), "New Tab");

        public BrowserWindowsPage() : base(Header, "Browser Windows") { }

        public void ClickNewTab() => newTabBtn.Click();
    }
}
