Feature: Test feature for market

@test_case_id
Scenario: Check goods filtration
	Given Market main page displayed
	When I select Ноутбуки subsection in Компьютеры section
	And I set prices range from 700 to 1500
	And I fill in Производитель filter with Lenovo value
	And Apply entered filter values
	Then Search results should be displayed with correct values