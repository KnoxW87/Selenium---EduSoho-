Feature: Users can login and enter the specified page

A short summary of the feature

@Products
Scenario: Enter the specified page
	Given I am in home page
	And I can selet login
	When I can enter information to login and jump
	| name    | password |
	| test001 | Test1234 |
	Then I can select loadmore button
	And I can selet products
