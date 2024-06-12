Feature: Story9-1

A short summary of the feature

@tag1
Scenario Outline: Doing info search on info management page with multiple filter
	Given I am on the home page
	And I login
	| name  | password     |
	| admin | 5EstafeyEtre |
	And I am on the info management page
	When I search with filter <category> and <keywords> and <property> and <status>
	Then I see <result>
	Examples: 
	| category | keywords | property | status | result |
	| EduSoho  |          |          | 未发布    | 6      |
	| EduSoho  | test     |          |          | 9      |
	| EduSoho  | test     | 推荐       | 未发布    | 1      |

Scenario Outline: Changing the status of an article
	Given I am on the home page
	And I login
	| name  | password     |
	| admin | 5EstafeyEtre |
	And I am on the info management page
	When I change the status <status>
	Then I can see <result>
	Examples: 
	| status | result |
	| 未发布    | 已发布    |
	| 已发布    | 未发布    |

Scenario Outline: Adding New Category
	Given I am on the home page
	And I login
	| name  | password     |
	| admin | 5EstafeyEtre |
	And I am on the info management page
	And Go to the CategoryManegement page
	When  I add new category with <categoryName> and <categoryCode> and <categoryTitle> and <categoryKeyword> and <categoryDesc>
	Then New category <categoryName> can be added
	Examples: 
	| categoryName | categoryCode | categoryTitle | categoryKeyword | categoryDesc |
	| www888777    | w87w87       | 123456789     | 987654321       | 123123123    |

Scenario Outline: Edit category,change the category name
	Given I am on the home page
	And I login
	| name  | password     |
	| admin | 5EstafeyEtre |
	And I am on the info management page
	And Go to the CategoryManegement page
	When I change the Category name <NewName>	
	Then Category name <NewName> is change
	Examples: 
	| NewName   |
	| qqq123456 |