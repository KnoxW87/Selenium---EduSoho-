Feature: Registration

A short summary of the feature

@tag1
Scenario Outline: Registration with invalid value
	Given I am in Register page
	When I enter <email> and <nickname> and <password>
	Then Error massage <error> is displayed
	Examples: 
	| email             | nickname | password | error                  |
	| test111           | test111  | test111  | 请输入有效的电子邮件地址           |
	| test111@gmail.com | 111      | test111  | 字符长度必须大于等于4，一个中文字算2个字符 |
	| test111@gmail.com | test111  | 111      | 最少需要输入 5 个字符           |
	| test111@gmail.com | test111  | test111  | 请输入验证码                  |
