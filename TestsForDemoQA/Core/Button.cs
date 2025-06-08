using OpenQA.Selenium;

namespace TestsForDemoQA.Core
{
    public class Button : BaseElement
    {
        public Button(By locator, string name) : base(locator, name) 
        { 
        }
    }
}
