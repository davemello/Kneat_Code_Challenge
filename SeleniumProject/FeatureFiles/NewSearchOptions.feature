Feature: New search options for booking website
	The website http://booking.com have extended their search filters with some new options.
	Spa and wellness centre
	Star Rating
	These need to be tested to ensure correct behaviour on the site
	Default booking is in Limerick for a one night stay in 3 months for 2 adults sharing 1 room

@smoke
Scenario: Search for hotels using specified search options
	Given User navigates to booking.com website
	And Enters default search criteria
	When User selects filter <SelectFilter>
	Then verifies that <HotelName> should appear in search results depending on IsListed is true or false <IsListed>

	Examples:
		| SelectFilter            | HotelName              | IsListed |
		| 5 Star                  | The Savoy Hotel        | True     |
		| 5 Star                  | George Limerick Hotel  | False    |
		| Spa and wellness centre | Clayton Hotel Limerick | True     |
		| Spa and wellness centre | George Limerick Hotel  | False    |