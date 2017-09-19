Feature: Code

@mytag
Scenario: Add a person
Given I navigate to http://localhost:8920/Person/Create
 And I enter Sherlock into the input with an ID of FirstName
 And I enter Holmes into the input with an ID of LastName
When I click the element with a CSS selector of .btn.btn-primary
Then the div with an Id of successMessage should contain the text Sherlock

