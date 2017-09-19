namespace Specification.CodeStyle
{
    using System;

    using TechTalk.SpecFlow;

    [Binding]
    public class CodeSteps
    {
        [Given(@"I navigate to (.*)")]
        public void GivenINavigateToHttpLocalhostPersonCreate(string url)
        {
            Console.WriteLine(url);
        }
        
        [Given(@"I enter (.*) into the input with an ID of (.*)")]
        public void GivenIEnterSherlockIntoTheInputWithAnIDOfFirstName(string name, string field)
        {
            Console.WriteLine(name);
            Console.WriteLine(field);
        }
        
        
        [When(@"I click the element with a CSS selector of (.*)")]
        public void WhenIClickTheElementWithACSSSelectorOf_Btn_Btn_Primary(string selector)
        {
            Console.WriteLine(selector);
        }
        
        [Then(@"the div with a ID of (.*) should contain the text (.*)")]
        public void ThenTheDivWithAIDOfAlertAlert_SuccessShouldContainTheTextSherlock(string p0, string p1)
        {
            Console.WriteLine(p0);
            Console.WriteLine(p1);
        }
    }
}
