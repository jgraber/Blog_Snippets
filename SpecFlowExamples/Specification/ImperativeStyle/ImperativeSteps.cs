using System;
using TechTalk.SpecFlow;

namespace Specification.ImperativeStyle
{
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [Binding]
    public class ImperativeSteps
    {
        private IWebDriver driver;

        [Given(@"I am on the application start screen")]
        public void GivenIAmOnTheApplicationStartScreen()
        {
            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl("http://localhost:8920/Person/Create");
        }
        
        [Given(@"I enter a first name of Sherlock")]
        public void GivenIEnterAFirstNameOfSherlock()
        {
            var element = this.driver.FindElement(By.Id("FirstName"));
            element.SendKeys("Sherlock");
        }
        
        [Given(@"I enter a last name of Holmes")]
        public void GivenIEnterALastNameOfHolmes()
        {
            var element = this.driver.FindElement(By.Id("LastName"));
            element.SendKeys("Holmes");
        }
        
        [When(@"I submit my form")]
        public void WhenISubmitMyForm()
        {
            var element = this.driver.FindElement(By.CssSelector(".btn.btn-primary"));
            element.Click();
        }
        
        [Then(@"I should see the application complete confirmation for Sherlock")]
        public void ThenIShouldSeeTheApplicationCompleteConfirmationForSherlock()
        {
            var element = this.driver.FindElement(By.Id("successMessage"));

            Assert.True(element.Text.Contains("Sherlock"));
        }
    }
}
