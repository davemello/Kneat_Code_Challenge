Feature: New search options for booking website
	The website http://booking.com have extended their search filters with some new options.
	Spa and wellness centre
	Star Rating
	These need to be tested to ensure correct behaviour on the site
	Default booking is in Limerick for a one night stay in 3 months for 2 adults sharing 1 room

Background: Get to filter page
	Given User navigates to booking.com website
	And Enters default search criteria

@filterOptions @all
Scenario: Star Ratings panel is visible in filter options list
	Then Star Ratings should be visible in filter panel

@filterOptions @all
Scenario: Star Ratings panel contains correct filter options
	Then Filter options are correct
		| FilterOption |
		| 3 stars       |
		| 4 stars       |
		| 5 stars       |
		| Unrated      |

Scenario: Search for hotels using specified search options
	When User selects filter <SelectFilter>
	Then <HotelName> should appear in search results depending on IsListed is true or false <IsListed>

	@smoke @searchOptionTest @all
	Examples:
		| SelectFilter | HotelName       | IsListed |
		| 5 Star       | The Savoy Hotel | True     |

	@searchOptionTest @all
	Examples:
		| SelectFilter            | HotelName              | IsListed |
		| 5 Star                  | George Limerick Hotel  | False    |
		| Spa and wellness centre | Clayton Hotel Limerick | True     |
		| Spa and wellness centre | George Limerick Hotel  | False    |
		| 4 Star                  | The Savoy Hotel        | False    |