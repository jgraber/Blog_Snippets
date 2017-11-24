using System;
using TechTalk.SpecFlow;

namespace Specification.DeclarativeStyle
{
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [Binding]
    public class DeclarativeSteps
    {
        private IWebDriver driver;

        [Given(@"I am on the movie character form")]
        public void GivenIAmOnTheMovieCharacterForm()
        {
            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl("http://localhost:8920/Person/Create");
        }

        [When(@"I submit a valid form")]
        public void WhenISubmitAValidForm()
        {
            var element1 = this.driver.FindElement(By.Id("FirstName"));
            element1.SendKeys("Sherlock");
            var element2 = this.driver.FindElement(By.Id("LastName"));
            element2.SendKeys("Holmes");
            var element3 = this.driver.FindElement(By.CssSelector(".btn.btn-primary"));
            element3.Click();
        }
        
        [Then(@"I should see a confirmation")]
        public void ThenIShouldSeeAConfirmation()
        {
            var element = this.driver.FindElement(By.Id("successMessage"));

            Assert.True(element.Text.Contains("Sherlock"));
        }
    }
}
