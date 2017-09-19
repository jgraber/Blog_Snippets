namespace Specification.CodeStyle
{
    using System;

    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    using TechTalk.SpecFlow;

    [Binding]
    public class CodeSteps
    {
        private IWebDriver driver;

        [Given(@"I navigate to (.*)")]
        public void GivenINavigateToHttpLocalhostPersonCreate(string url)
        {
            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl(url);
        }
        
        [Given(@"I enter (.*) into the input with an ID of (.*)")]
        public void GivenIEnterSherlockIntoTheInputWithAnIDOfFirstName(string name, string field)
        {
            var element = this.driver.FindElement(By.Id(field));
            element.SendKeys(name);
        }
        
        
        [When(@"I click the element with a CSS selector of (.*)")]
        public void WhenIClickTheElementWithACSSSelectorOf_Btn_Btn_Primary(string selector)
        {
            var element = this.driver.FindElement(By.CssSelector(selector));
            element.Click();
        }
        
        [Then(@"the div with an Id of (.*) should contain the text (.*)")]
        public void ThenTheDivWithACSSSelectorOfAlert_Alert_SuccessShouldContainTheTextSherlock(string selector, string text)
        {
            var element = this.driver.FindElement(By.Id(selector));

            Assert.True(element.Text.Contains(text));
        }

    }
}
