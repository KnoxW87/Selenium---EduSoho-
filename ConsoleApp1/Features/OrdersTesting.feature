Feature: OrdersTesting

A short summary of the feature

@tag1
Scenario: Doing a default search for the Course order
	Given I am on the HomePage
	And I Login with
	| name  | password     |
	| admin | 5EstafeyEtre |
	And I go to AdminPage
	And I am on the CoursePage
	When I click Search Button
	Then I see <20> results.

Scenario: Doing a default search for the Class order
	Given I am on the HomePage
	And I Login with
	| name  | password     |
	| admin | 5EstafeyEtre |
	And I go to AdminPage
	And I am on the ClassPage
	When I click Search Button
	Then I see <5> results.

Scenario Outline: Doing search for the Course order with different filters
	Given I am on the HomePage
	And I Login with
	| name  | password     |
	| admin | 5EstafeyEtre |
	And I go to AdminPage
	And I am on the CoursePage
	When I do course order search with filter <filter> and <value>
	Then I see <result> course orders
	Examples: 
	| filter  | value            | result |
	| date    | 2017-12-14 22:51 | 20     |
	| status  | 已付款              | 20     |
	| payment | 支付宝              | 0      |
	| keyword | 课程名称             | 20      |

Scenario Outline: Doing search for the Class order with different filters
	Given I am on the HomePage
	And I Login with
	| name  | password     |
	| admin | 5EstafeyEtre |
	And I go to AdminPage
	And I am on the ClassPage
	When I do class order search with filter <filter> and <value>
	Then I see <result> class orders
	Examples: 
	| filter  | value            | result |
	| date    | 2017-12-14 22:51 | 5     |
	| status  | 已付款              | 5     |
	| payment | 支付宝              | 0      |
	| keyword | 班级编号             | 5      |