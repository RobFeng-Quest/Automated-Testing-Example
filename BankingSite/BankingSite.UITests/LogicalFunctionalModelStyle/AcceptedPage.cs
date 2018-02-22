using OpenQA.Selenium;

namespace BankingSite.UITests.LogicalFunctionalModelStyle
{
    public class AcceptedPage
    {
        private const string NameId = "Name";
        private readonly IWebDriver _driver;

        public AcceptedPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string Name
        {
            get
            {
                return _driver.FindElement(By.Id(NameId)).Text;
            }
        }

        public bool PageExist()
        {
            return _driver.Url.Contains("ApplicationAccepted.aspx");
        }
    }
}