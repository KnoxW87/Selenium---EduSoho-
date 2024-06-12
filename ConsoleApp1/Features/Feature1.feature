Feature: Logout testing

A short summary of the feature

@tag1
Scenario: Login is sucessful first and logout is sucessful
	Given I am in the homepage
	And Go to the loginpage
	When I input valid value with
	| name    | password |
	| test002 | Test1234 |
	Then Login is sucessful and click logout button
	And Logout is sucessful
