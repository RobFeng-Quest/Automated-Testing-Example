using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BankingSite.UITests.LogicalFunctionalModelStyle
{
    [TestFixture]
    public class CreditCardApplicationTests
    {
        [Test]
        [STAThread]
        [Category("smoke")]
        public void ShouldShowCorrectApplicantDetailsOnSuccessPage()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl(UiAutomationSettings.ApplyPageUrl);

                var applyPage = new ApplyForCreditCardPage(driver);

                var acceptedPage = applyPage.ApplyForCreditCard(name: "Jason",
                                               age: "30",
                                               airlineNumber: "A1234567");

                Assert.That(acceptedPage.PageExist());

                Assert.That(acceptedPage.Name, Is.EqualTo("Jason"));
            }
        }


        [Test]
        [STAThread]
        public void ShouldShowValidationErrors()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl(UiAutomationSettings.ApplyPageUrl);

                var applyPage = new ApplyForCreditCardPage(driver);

                applyPage.ApplyForCreditCard(name: "Jason",
                                               age: "30",
                                               airlineNumber: "BadNumber");

                Assert.That(driver.PageSource.Contains("Airline membership number is invalid"));
            }
        }
    }
}
