using OpenQA.Selenium;

namespace BankingSite.UITests.LogicalFunctionalModelStyle
{
    public class ApplyForCreditCardPage
    {
        private const string AgeId = "Age";
        private const string NameId = "Name";
        private const string AirlineNumberId = "AirlineRewardNumber";
        private readonly IWebDriver _driver;

        public ApplyForCreditCardPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public string Name
        {
            get
            {
                return _driver.FindElement(By.Id(NameId)).Text;
            }
            set
            {
                _driver.FindElement(By.Id(NameId)).SendKeys(value);
            }
        }

        public string Age
        {
            get
            {
                return _driver.FindElement(By.Id(AgeId)).Text;
            }
            set
            {
                _driver.FindElement(By.Id(AgeId)).SendKeys(value);
            }
        }

        public string AirlineNumber
        {
            get
            {
                return _driver.FindElement(By.Id(AirlineNumberId)).Text;
            }
            set
            {
                _driver.FindElement(By.Id(AirlineNumberId)).SendKeys(value);
            }
        }

        public void ClickApplyButton()
        {
            _driver.FindElement(By.Id("ApplyNow")).Click();
        }

        public AcceptedPage ApplyForCreditCard(string name, string age, string airlineNumber)
        {
            this.Name = name;
            this.Age = age;
            this.AirlineNumber = airlineNumber;

            ClickApplyButton();

            return new AcceptedPage(_driver);
        }
    }
}
