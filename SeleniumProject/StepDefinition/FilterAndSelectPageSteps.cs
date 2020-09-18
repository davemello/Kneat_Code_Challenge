using FluentAssertions;
using SeleniumProject.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumProject.StepDefinition
{
    [Binding]
    public sealed class FilterAndSelectPageSteps : BaseDefinition
    {

        [When(@"User selects filter (.*)")]
        public void ThenUserSelectsFilter(string filter)
        {
            FilterAndSelectPage.UseSpecifiedFilterToSearchForHotels(filter);
        }



        [Then(@"(.*) should appear in search results depending on IsListed is true or false (.*)")]
        public void ThenHotelShouldAppearInSearchResultsDependingOnIsListedIsTrueOrFalse(string hotelName, string isListed)
        {
            bool doesHotelMatchRule = FilterAndSelectPage.CheckHotelListForName(hotelName, isListed);
            doesHotelMatchRule.Should().BeTrue();
            FilterAndSelectPage.GoBackToHomePage();
        }


        [Then(@"Star Ratings should be visible in filter panel")]
        public void ThenStarRatingsShouldBeVisibleInFilterPanel()
        {
            bool isRatingPanelPresent = FilterAndSelectPage.IsStarRatingPanelHeaderPresent();
            isRatingPanelPresent.Should().BeTrue();
            FilterAndSelectPage.GoBackToHomePage();
        }

    }
}
