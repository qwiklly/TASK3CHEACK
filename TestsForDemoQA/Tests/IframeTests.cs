using TestsForDemoQA.Pages;

namespace TestsForDemoQA.Tests
{
    [TestFixture]
    class IframeTests : BaseTest
    {
        [Test]
        public void IframeTest()
        {
            var mainPage = new MainPage();
            Assert.That(mainPage.IsDisplayed(), Is.True, "Главная страница не открыта");

            mainPage.ClickAlertsFrameWindows();
            var sidebarMenu = new SidebarMenuPage();

            sidebarMenu.ClickNestedFrames();
            var nestedFramesPage = new NestedFramesPage();
            Assert.That(nestedFramesPage.IsDisplayed(), Is.True, "Страница Nested Frames не открылась");

            string parentText = nestedFramesPage.GetParentFrameText();
            string childText = nestedFramesPage.GetChildFrameText();

            Assert.That(parentText, Is.EqualTo("Parent frame"), "Неверный текст в parent frame");
            Assert.That(childText, Is.EqualTo("Child Iframe"), "Неверный текст в child frame");

            sidebarMenu.ClickFrames();
            var framesPage = new FramesPage();
            Assert.That(framesPage.IsDisplayed(), Is.True, "Страница Frames не открылась");

            string upperFrameText = framesPage.GetTextFromFrame("frame1");
            string lowerFrameText = framesPage.GetTextFromFrame("frame2");

            Assert.That(upperFrameText, Is.EqualTo(lowerFrameText), "Тексты в верхнем и нижнем фрейме не совпадают");
        }
    }
}
