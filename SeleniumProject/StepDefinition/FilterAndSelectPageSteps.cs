using FluentAssertions;
using SeleniumProject.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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

        [Then(@"Filter options are correct")]
        public void ThenFilterOptionsAreCorrect(Table table)
        {

            var filterOptions = ReturnDynamicTableValuesAsListString(table);
            var ListOfFiltersFromPage = FilterAndSelectPage.GetListOfStarRatingOptions();
            ListOfFiltersFromPage.Should().Contain(filterOptions);
        }

        private List<string> ReturnDynamicTableValuesAsListString(Table table)
        {
            var filterOptions = table.CreateDynamicSet();
            List<string> filterOptionsList = new List<string>();
            foreach (var item in filterOptions)
            {
                var filterOptionText = item.FilterOption;
                filterOptionsList.Add(filterOptionText);
            }
            return filterOptionsList;
        }

    }
}
