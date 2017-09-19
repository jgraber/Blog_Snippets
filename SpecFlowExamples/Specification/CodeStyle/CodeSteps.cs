namespace Specification.CodeStyle
{
    using TechTalk.SpecFlow;

    [Binding]
    public class CodeSteps
    {
        [Given(@"I navigate to (.*)")]
        public void GivenINavigateToHttpLocalhostPersonCreate(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter (.*) into the input with an ID of (.*)")]
        public void GivenIEnterSherlockIntoTheInputWithAnIDOfFirstName(string name, string field)
        {
            ScenarioContext.Current.Pending();
        }
        
        
        [When(@"I click the element with a CSS selector of (.*)")]
        public void WhenIClickTheElementWithACSSSelectorOf_Btn_Btn_Primary(string selector)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the div with a ID of (.*) should contain the text (.*)")]
        public void ThenTheDivWithAIDOfAlertAlert_SuccessShouldContainTheTextSherlock(string selector, string text)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
