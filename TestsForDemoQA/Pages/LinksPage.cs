using OpenQA.Selenium;
using TestsForDemoQA.Core;

namespace TestsForDemoQA.Pages
{
    public class LinksPage : BaseForm
    {
        private static readonly By Header = By.Id("linkWrapper");
        private readonly Link homeLink = new Link(By.Id("simpleLink"), "Home Link");

        public LinksPage() : base(Header, "Links") { }

        public void ClickHome() => homeLink.Click();
    }
}
