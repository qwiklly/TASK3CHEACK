using OpenQA.Selenium;
using TestsForDemoQA.Core;
using TestsForDemoQA.Driver;
using TestsForDemoQA.Utils;

namespace TestsForDemoQA.Pages
{
    public class WebTablesPage : BaseForm
    {

        private static readonly By WebTablesHeader = By.ClassName("text-center");
        private readonly Button addButton = new Button(By.Id("addNewRecordButton"), "Add Button");
        private readonly By tableRowsLocator =
        By.XPath("//div[@class='rt-tbody']/div[contains(@class,'rt-tr-group') and not(contains(@class,'-padRow'))]");
        private readonly string deleteButtonInRowXPath = ".//span[@title='Delete']";

        public WebTablesPage() : base(WebTablesHeader, "Web Tables Page")
        {
        }

        public void ClickAdd()
        {
            Logger.Info("Кликаем кнопку Add на странице Web Tables");
            addButton.Click();
        }
        public int GetTableRowCount()
        {
            return DriverSingleton.Instance
                .FindElements(By.CssSelector("div.rt-tbody .rt-tr-group"))
                .Count(row => row
                    .FindElements(By.CssSelector(".rt-td"))
                    .Any(cell => !string.IsNullOrWhiteSpace(cell.Text)));
        }

        public void DeleteUserByEmail(string email)
        {
            Logger.Info($"Пытаемся удалить пользователя с Email = {email}");
            var rows = DriverSingleton.Instance.FindElements(tableRowsLocator);
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.XPath(".//div[contains(@class,'rt-td')]"));
                if (cells.Any(cell => cell.Text.Equals(email, StringComparison.OrdinalIgnoreCase)))
                {
                    var deleteButton = row.FindElement(By.XPath(deleteButtonInRowXPath));
                    deleteButton.Click();
                    Logger.Info($"Нажата кнопка Delete для пользователя с Email = {email}");
                    return;
                }
            }
            throw new InvalidOperationException($"Не удалось найти строку с Email = {email} для удаления");
        }
    }
}
