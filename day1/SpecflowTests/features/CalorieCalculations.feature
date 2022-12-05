Feature: CalorieCalculations

As a person interested in the calorific content of food items carried by Elves
I would like to ensure that the totals are calculated correctly
So that I know which Elves are carrying food items with the highest calorific content

Scenario: Elf with highest calorie total is correctly calculated
	Given a set of Elves with the following food items
		| Elf | ItemCalories |
		| 1   | 10,10,10     |
		| 2   | 50           |
		| 3   | 20,20,20     |
		| 4   | 40,60        |
		| 5   | 30,30        |
	When I look for the 1 Elves with the highest total number of calories
	Then The Elves with the highest total number of calories will be
		| 4 |
	And The total number of calories will be
		| 100 |

Scenario: Top 3 Elves with highest calorie totals are correctly calculated
	Given a set of Elves with the following food items
		| Elf | ItemCalories |
		| 1   | 10,10,10     |
		| 2   | 50           |
		| 3   | 20,20,20     |
		| 4   | 40,60        |
		| 5   | 30,40        |
	When I look for the 3 Elves with the highest total number of calories
	Then The Elves with the highest total number of calories will be
		| Index |
		| 4     |
		| 5     |
		| 3     |
	And The total number of calories will be
		| TotalCalories |
		| 100           |
		| 70            |
		| 60            |

Scenario: Exception is thrown if I try to run calculations when there are no Elves
	Given a set of Elves with the following food items
		| Elf | ItemCalories |
	Then an exception is thrown with message 'No Elves!!!'
