Feature: SettingPage

A short summary of the feature

@tag1
Scenario: Update setting page with valid data
	Given I am on the login page
	And login
	| name    | password |
	| test002 | Test1234 |
	And I am on the Setting page
	When I update date with
	| Name | Gender | ID                 | Phone      | Company | Job    | Title | Signature  | Profile     | PersonalWebsite  | Weibo            | Wechat   | QQ        |
	| Knox | male   | 520111199011111111 | 0211988587 | Steam   | Tester | Boss  | Hello guys | Hello again | http://baidu.com | http://weibo.com | knoxwang | 178178178 |
	Then I can see "基础信息保存成功。" message

Scenario: Update setting page with invalid data
	Given I am on the login page
	And login
	| name    | password |
	| test002 | Test1234 |
	And Click personalsetting page
	When Update data with
	| Name				   | Gender | ID   | Phone | Company | Job    | Title                         | Signature  | Profile     | PersonalWebsite  | Weibo | Wechat   | QQ   |
	| KnoxKnoxKnoxKnoxKnox | male   | 1234 | 4321  | Steam   | Tester | BossBossBossBossBossBossBoss  | Hello guys | Hello again | 1234             | 3213  | knoxwang | qwer |
	Then I see errors
	| error         |
	| 最多只能输入 18 个字符 |
	| 请正确输入您的身份证号码 |
	| 请输入正确的手机号 |
	| 最多只能输入 24 个字符 |
	| 地址不正确，须以http://或者https://开头。 |
	| 地址不正确，须以http://或者https://开头。 |
	| 请输入正确的QQ号 |
