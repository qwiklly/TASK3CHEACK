using OpenQA.Selenium;
using TestsForDemoQA.Core;
using TestsForDemoQA.Utils;

namespace TestsForDemoQA.Pages
{
    public class SidebarMenuPage : BaseForm
    {
        private static readonly By SidebarLocator = By.ClassName("left-pannel");
        private readonly Button alertsMenuButton = new Button(By.XPath("//span[text()='Alerts']"), "Alerts Menu Button");
        private readonly Button framesMenuButton = new Button(By.XPath("//span[text()='Frames']"), "Frames Menu Button");
        private readonly Button nestedFramesMenuButton = new Button(By.XPath("//span[text()='Nested Frames']"), "Nested Frames Menu Button");
        private readonly Button webTablesMenuButton = new Button(By.XPath("//span[text()='Web Tables']"), "Web Tables Menu Button");

        private readonly Button browserWindowsButton = new Button(By.XPath("//span[text()='Browser Windows']"), "Browser Windows");
        private readonly Button elementsButton = new Button(By.XPath("//*[normalize-space(text())='Elements']"), "Elements");
        private readonly Button linksButton = new Button(By.XPath("//span[text()='Links']"), "Links");

        public SidebarMenuPage() : base(SidebarLocator, "Sidebar Menu")
        {
        }

        public void ClickAlerts()
        {
            Logger.Info("Кликаем пункт меню 'Alerts'");
            alertsMenuButton.Click();
        }
        public void ClickFrames()
        {
            Logger.Info("Кликаем пункт меню 'Frames'");
            framesMenuButton.Click();
        }
        public void ClickNestedFrames()
        {
            Logger.Info("Кликаем пункт меню 'Nested Frames'");
            nestedFramesMenuButton.Click();
        }
        public void ClickWebTables()
        {
            Logger.Info("Кликаем пункт меню 'Web Tables'");
            webTablesMenuButton.Click();
        }
        public void ClickBrowserWindows() 
        {
            Logger.Info("Кликаем окно браузера");
            browserWindowsButton.Click(); 
        
        }
        public void ClickElements()
        {
            elementsButton.Click();
        }
        public void ClickLinks() => linksButton.Click();
    }
}
