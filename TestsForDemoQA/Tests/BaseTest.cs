using TestsForDemoQA.Config;
using TestsForDemoQA.Driver;

namespace TestsForDemoQA.Tests
{
    public class BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            _ = DriverSingleton.Instance;
            DriverSingleton.Instance.Navigate().GoToUrl(ConfigReader.BaseUrl);
        }

        [TearDown]
        public void TearDown() => DriverSingleton.QuitDriver();
    }
}
