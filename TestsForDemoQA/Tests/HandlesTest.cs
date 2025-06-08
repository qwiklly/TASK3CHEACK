using TestsForDemoQA.Pages;
using TestsForDemoQA.Core; 

namespace TestsForDemoQA.Tests
{
    [TestFixture]
    public class HandlesTests : BaseTest
    {
        [Test]
        public void TestWindowAndTabHandles()
        {
            var main = new MainPage();
            Assert.That(main.IsDisplayed(), Is.True, "Главная страница не открыта");

            main.ClickAlertsFrameWindows();
            var sidebar = new SidebarMenuPage();
            sidebar.ClickBrowserWindows();

            var bw = new BrowserWindowsPage();
            Assert.That(bw.IsDisplayed(), Is.True, "Browser Windows не открылась");

            string originalHandle = Browser.GetCurrentWindowHandle();
            bw.ClickNewTab();
            string handleAfterNewTab = Browser.SwitchToNewWindow();
            var samplePage = new SamplePage();
            Assert.That(samplePage.IsDisplayed, Is.True, "Ожидался sample page");

            Browser.CloseCurrentAndSwitchTo(handleAfterNewTab);
            Assert.That(bw.IsDisplayed(), Is.True, "Не вернулись к Browser Windows");

            sidebar.ClickElements();
            sidebar.ClickLinks();
            var links = new LinksPage();
            Assert.That(links.IsDisplayed(), Is.True, "Страница Links не открылась");

            string handleBeforeHome = Browser.GetCurrentWindowHandle();
            links.ClickHome();
            string handleHome = Browser.SwitchToNewWindow();
            Assert.That(main.IsDisplayed, Is.True, "Home не ведёт на главную");

            Browser.CloseCurrentAndSwitchTo(handleHome);
            Assert.That(links.IsDisplayed(), Is.True, "Не вернулись на страницу Links");
        }
    }
}
