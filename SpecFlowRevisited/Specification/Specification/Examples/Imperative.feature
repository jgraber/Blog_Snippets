Feature: Imperative

@mytag
Scenario: Imperative Example
Given I am on the application start screen
	And I enter a first name of Sherlock
	And I enter a last name of Holmes
When I submit my form
Then I should see the application complete confirmation for Sherlock