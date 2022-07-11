Feature: JourneyPlanner
As a traveller
I would like to Plan my journey 
using TFL UI website

Scenario: User should see details of their journey when a valid locations is entered into plan a journey widget
	Given the user is on tfl home page
	And the user clicks on 'Plan a journey' tab
	And the user enters a valid from location as 'Basingstoke, UK' and to location as 'Grays Rail Station'
	When the user clicks on 'Plan my journey' button
	Then the journey results details is displayed as follows:
		| Journey results | From  | To  | Leaving  | From Location   | To Location        | Edit Journey | Add Favourite | Fastest by public transport | Map View | View Details |
		| Journey results | From: | To: | Leaving: | Basingstoke, UK | Grays Rail Station | Edit Journey | Add Favourite | Fastest by public transport | Map View | View Details |

Scenario: User should not see journey result for invalid location
	Given the user is on tfl home page
	And the user clicks on 'Plan a journey' tab
	And the user enters invalid from location as 'sdfdcc' and to location as 'kjvggf yg'
	When the user clicks on 'Plan my journey' button
	Then the user should not see result for the invalid search locations
	And the user should error message 'Sorry, we can't find a journey matching your criteria'

Scenario: User should not be allowed to plan a journey if no locations are entered into the plan a journey widget
	Given the user is on tfl home page
	And the user clicks on 'Plan a journey' tab
	And the user leaves from location field and to location field empty
	When the user clicks on 'Plan my journey' button
	Then the user should see empty From location error message as 'The From field is required.' error message
	And the user should see empty To location error message as 'The To field is required.' error message

Scenario: User should able to edit their journey on the journey results page
	Given the user is on tfl home page
	And the user clicks on 'Plan a journey' tab
	And the user enters a valid from location as 'Barking, UK' and to location as 'Grays Rail Station'
	And the user clicks on 'Plan my journey' button
	And the journey results details is displayed as follows:
		| Journey results | From  | To  | Leaving  | From Location | To Location        | Edit Journey | Add Favourite | Fastest by public transport | Map View | View Details |
		| Journey results | From: | To: | Leaving: | Barking, UK   | Grays Rail Station | Edit Journey | Add Favourite | Fastest by public transport | Map View | View Details |
	When the user clicks on edit journey button
	And the user enters a new valid from location as 'Chelmsford, UK' and to location as 'Grays Rail Station'
	And the user clicks on 'Plan my journey' button
	Then the journey results details is displayed as follows:
		| Journey results | From  | To  | Leaving  | From Location  | To Location        | Edit Journey | Add Favourite | Fastest by public transport | Map View | View Details |
		| Journey results | From: | To: | Leaving: | Chelmsford, UK | Grays Rail Station | Edit Journey | Add Favourite | Fastest by public transport | Map View | View Details |

Scenario: User should see list of recently planned journeys on recents tab widget
	Given the user is on tfl home page
	And the user clicks on 'Plan a journey' tab
	And the user enters a valid from location as 'Chelmsford, UK' and to location as 'Grays Rail Station'
	And the user clicks on 'Plan my journey' button
	And the journey results details is displayed as follows:
		| Journey results | From  | To  | Leaving  | From Location  | To Location        | Edit Journey | Add Favourite | Fastest by public transport | Map View | View Details |
		| Journey results | From: | To: | Leaving: | Chelmsford, UK | Grays Rail Station | Edit Journey | Add Favourite | Fastest by public transport | Map View | View Details |
	When the user clicks on 'Plan a journey' tab
	Then the recent planned journeys are displayed as follows:
		| From Location  | To Location        |
		| Chelmsford, UK | Grays Rail Station |