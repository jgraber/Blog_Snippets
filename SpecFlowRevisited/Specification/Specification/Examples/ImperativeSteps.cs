using System;
using TechTalk.SpecFlow;

namespace Specification.Examples
{
    using NUnit.Framework;

    [Binding]
    public class ImperativeSteps
    {
        [Given(@"I am on the application start screen")]
        public void GivenIAmOnTheApplicationStartScreen()
        {
            Assert.AreEqual(3,3);
        }
        
        [Given(@"I enter a first name of Sherlock")]
        public void GivenIEnterAFirstNameOfSherlock()
        {
            Assert.IsTrue(true);
        }
        
        [Given(@"I enter a last name of Holmes")]
        public void GivenIEnterALastNameOfHolmes()
        {
            Assert.IsFalse(false);
        }
        
        [When(@"I submit my form")]
        public void WhenISubmitMyForm()
        {
            
        }
        
        [Then(@"I should see the application complete confirmation for Sherlock")]
        public void ThenIShouldSeeTheApplicationCompleteConfirmationForSherlock()
        {
           Assert.AreNotEqual(3,4);
        }
    }
}
