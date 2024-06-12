Feature: Upload profile photo

A short summary of the feature

@tag1
Scenario: Upload profile photo is successful
	Given I am in the Homepage
	And I click loginPage
	When I enter the username and password
	| name    | password |
	| test002 | Test1234 |
	Then I entry the settingPage
	And Upload the profile photo
