using OpenQA.Selenium;
using TestsForDemoQA.Core;
using TestsForDemoQA.Driver;
using TestsForDemoQA.Utils;

namespace TestsForDemoQA.Pages
{
    public class RegistrationFormPage : BaseForm
    {
        private static readonly By RegistrationFormHeader = By.Id("registration-form-modal");

        private readonly BaseElement firstNameInput = new BaseElement(By.Id("firstName"), "First Name Input");
        private readonly BaseElement lastNameInput = new BaseElement(By.Id("lastName"), "Last Name Input");
        private readonly BaseElement emailInput = new BaseElement(By.Id("userEmail"), "Email Input");
        private readonly BaseElement ageInput = new BaseElement(By.Id("age"), "Age Input");
        private readonly BaseElement salaryInput = new BaseElement(By.Id("salary"), "Salary Input");
        private readonly BaseElement departmentInput = new BaseElement(By.Id("department"), "Department Input");

        private readonly Button submitButton = new Button(By.Id("submit"), "Submit Button");

        public RegistrationFormPage() : base(RegistrationFormHeader, "Registration Form")
        {
        }

        public void FillFirstName(string firstName)
        {
            Logger.Info($"Устанавливаем First Name = {firstName}");
            firstNameInput.Click();
            DriverSingleton.Instance.FindElement(By.Id("firstName")).Clear();
            DriverSingleton.Instance.FindElement(By.Id("firstName")).SendKeys(firstName);
        }

        public void FillLastName(string lastName)
        {
            Logger.Info($"Устанавливаем Last Name = {lastName}");
            lastNameInput.Click();
            DriverSingleton.Instance.FindElement(By.Id("lastName")).Clear();
            DriverSingleton.Instance.FindElement(By.Id("lastName")).SendKeys(lastName);
        }

        public void FillEmail(string email)
        {
            Logger.Info($"Устанавливаем Email = {email}");
            emailInput.Click();
            DriverSingleton.Instance.FindElement(By.Id("userEmail")).Clear();
            DriverSingleton.Instance.FindElement(By.Id("userEmail")).SendKeys(email);
        }

        public void FillAge(string age)
        {
            Logger.Info($"Устанавливаем Age = {age}");
            ageInput.Click();
            DriverSingleton.Instance.FindElement(By.Id("age")).Clear();
            DriverSingleton.Instance.FindElement(By.Id("age")).SendKeys(age);
        }

        public void FillSalary(string salary)
        {
            Logger.Info($"Устанавливаем Salary = {salary}");
            salaryInput.Click();
            DriverSingleton.Instance.FindElement(By.Id("salary")).Clear();
            DriverSingleton.Instance.FindElement(By.Id("salary")).SendKeys(salary);
        }

        public void FillDepartment(string department)
        {
            Logger.Info($"Устанавливаем Department = {department}");
            departmentInput.Click();
            DriverSingleton.Instance.FindElement(By.Id("department")).Clear();
            DriverSingleton.Instance.FindElement(By.Id("department")).SendKeys(department);
        }

        public void ClickSubmit()
        {
            Logger.Info("Нажимаем кнопку Submit в Registration Form");
            submitButton.Click();
        }
    }
}
