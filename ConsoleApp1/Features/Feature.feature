Feature: Login testing

A short summary of the feature

@tag1
Scenario: Login is successful with valid value
	Given I am in Homepage
	And I select login.
	When I enter value with
	| name    | password |
	| test002 | Test1234 |
	Then login is successfule and avatar is seen


Scenario: Login is unsuccessful with invalid value
	Given I am in Homepage
	And I select login.
	When I input value with
	| name    | password |
	| test002 | 1234	 |
	Then login is unsuccessful and errormessage is seen


Scenario: Login is suceesful with remenber me checkbox
	Given I am in Homepage
	And I select login.
	When I input value and click remenber me
	| name    | password |
	| test002 | Test1234 |
	Then login is seccessful