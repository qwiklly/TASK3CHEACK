using OpenQA.Selenium;

namespace TestsForDemoQA.Core
{
    public class Link : BaseElement
    {
        public Link(By locator, string name) : base(locator, name)
        {
        }
    }
}
