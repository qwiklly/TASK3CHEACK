using TestsForDemoQA.Pages;

namespace TestsForDemoQA.Tests
{
    [TestFixture]
    public class AlertsTests : BaseTest
    {
        [Test]
        public void AlertsTest()
        {
            var mainPage = new MainPage();
            Assert.That(mainPage.IsDisplayed(), Is.True, "Главная страница не открыта");

            mainPage.ClickAlertsFrameWindows();
            var sidebarMenu = new SidebarMenuPage();
            sidebarMenu.ClickAlerts();
            var alertsPage = new AlertsPage();
            Assert.That(alertsPage.IsDisplayed(), Is.True, "Страница Alerts не отобразилась");

            alertsPage.ClickSimpleAlert();
            Assert.That(alertsPage.IsAlertPresent(), Is.True, "Алерт не появился после нажатия кнопки");
            string alertText = alertsPage.GetAlertText();
            Assert.That(alertText, Is.EqualTo("You clicked a button"), "Текст алерта не соответствует");

            alertsPage.AcceptAlert();
            Assert.That(alertsPage.IsAlertClosed(), Is.True, "Алерт не был закрыт после нажатия OK");

            alertsPage.ClickConfirmAlert();
            Assert.That(alertsPage.IsAlertPresent(), Is.True, "Confirm алерт не появился");
            string confirmText = alertsPage.GetAlertText();
            Assert.That(confirmText, Is.EqualTo("Do you confirm action?"), "Текст confirm алерта не соответствует");

            alertsPage.AcceptAlert();
            Assert.That(alertsPage.IsAlertClosed(), Is.True, "Confirm алерт не был закрыт");
            string confirmResult = alertsPage.GetConfirmResult();
            Assert.That(confirmResult, Is.EqualTo("You selected Ok"), "Результат после confirm не соответствует");

            alertsPage.ClickPromptAlert();
            Assert.That(alertsPage.IsAlertPresent(), Is.True, "Prompt алерт не появился");
            string promptText = alertsPage.GetAlertText();
            Assert.That(promptText, Is.EqualTo("Please enter your name"), "Текст prompt алерта не соответствует");

            string randomText = Guid.NewGuid().ToString();
            alertsPage.SendTextToPrompt(randomText);
            Assert.That(alertsPage.IsAlertClosed(), Is.True, "Prompt алерт не был закрыт");
            string promptResult = alertsPage.GetPromptResult();
            Assert.That(promptResult.Contains(randomText), Is.True, "Результат prompt не содержит введённый текст");
        }
    }
}
