using OpenQA.Selenium;
using TestsForDemoQA.Core;

namespace TestsForDemoQA.Pages
{
    public class SamplePage : BaseForm
    {
        private static readonly By SamplePageLocator = By.Id("sampleHeading");
        public SamplePage() : base(SamplePageLocator, "Sample Page")
        {
        }
    }
}
