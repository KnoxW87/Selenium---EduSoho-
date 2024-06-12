Feature: ResetPassword

A short summary of the feature

@tag1
Scenario Outline: Email is not exist or invalid
	Given I am in Resetpassword page
	When I enter an <email> address
	Then I can see <error> massage
	Examples: 
	| email           | error        |
	| 12345@gmail.com | 该邮箱地址没有注册过帐号 |
	| 12345			  | 请输入有效的电子邮件地址 |
