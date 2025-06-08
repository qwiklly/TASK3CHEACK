using TestsForDemoQA.Pages;

namespace TestsForDemoQA.Tests
{
    [TestFixture]
    public class TablesTests : BaseTest
    {
        [TestCase("Ivan", "Ivanov", "ivanov@example.com", "30", "50000", "IT")]
        [TestCase("Petr", "Petrov", "petrov@example.com", "25", "45000", "HR")]
        public void WebTables_AddAndDeleteUser_Test(string firstName, string lastName, string email, string age, string salary, string department)
        {
            var mainPage = new MainPage();
            Assert.That(mainPage.IsDisplayed(), Is.True, "Главная страница не открыта");

            mainPage.ClickElements();

            var sidebarMenu = new SidebarMenuPage();
            sidebarMenu.ClickWebTables();

            var webTablesPage = new WebTablesPage();
            Assert.That(webTablesPage.IsDisplayed(), Is.True, "Страница Web Tables не открылась");

            int initialCount = webTablesPage.GetTableRowCount();

            webTablesPage.ClickAdd();

            var registrationForm = new RegistrationFormPage();
            Assert.That(registrationForm.IsDisplayed(), Is.True, "Форма регистрации не появилась");

            registrationForm.FillFirstName(firstName);
            registrationForm.FillLastName(lastName);
            registrationForm.FillEmail(email);
            registrationForm.FillAge(age);
            registrationForm.FillSalary(salary);
            registrationForm.FillDepartment(department);
            registrationForm.ClickSubmit();
            
            int afterAddCount = webTablesPage.GetTableRowCount();
            Assert.That(afterAddCount, Is.EqualTo(initialCount + 1), $"Запись не добавилась в таблицу (ожидалось {initialCount + 1}, получили {afterAddCount})");

            webTablesPage.DeleteUserByEmail(email);

            int afterDeleteCount = webTablesPage.GetTableRowCount();
            Assert.That(afterDeleteCount, Is.EqualTo(initialCount), $"Запись не удалилась из таблицы (ожидалось {initialCount}, получили {afterDeleteCount})");
        }
    }
}
