Feature: TMFeature

As a Turnup portal admin user
I would like to create, edit and delete time and material records.
So, that iI can manage the employee time & materials successfully.

#Run before every scenario
Background: 
	Given I logged into Turnup portal successfully
	And I nevigate to the time and material page

@regression @bvt @timeandmaterial
Scenario: Create new time and material record with valid data
	When I crete a new time and material record
	Then The record should be created successfully


Scenario Outline: edit existing time record with valid data
	When I update the '<Code>' and '<Description>' on an existing Time record
	Then the record should have the updated '<Code>' and '<Description>'

	Examples: 
	| Code             | Description |
	| Industry Connect | Laptop      |
	| TA Job Ready     | Mouse       |
	| EditedRecord     | Keyboard    |


Scenario: delete existing time record
	When I delete an existing record
	Then the record should not be present on the table