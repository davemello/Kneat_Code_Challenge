using SeleniumProject.CustomAssertions;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using SeleniumProject.Text;
using TechTalk.SpecFlow;
using SeleniumProject.BaseClasses;
using AventStack.ExtentReports.Gherkin.Model;
using FluentAssertions;

namespace SeleniumProject.StepDefinition
{
    [Binding]
    public sealed class SearchPageSteps : BaseDefinition
    {

        [Given(@"User navigates to booking.com website")]
        public void GivenUserNavigatesToWebSite()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            CustomAssert.AssertThatTextIsCorrect(RequiredText.TitleOfLandingPage, WindowHelper.GetTitle());
            HomePage.CheckForCookiePrefNotification();
        }


        [Given(@"Enters default search criteria")]
        public void UserEntersDefaultSearchCriteria()
        {
            HomePage.EnterSearchDetails();
        }

        [When(@"User selects filter (.*)")]
        public void ThenUserSelectsFilter(string filter)
        {
            FilterAndSelectPage.UseSpecifiedFilterToSearchForHotels(filter);
        }



        [Then(@"verifies that (.*) should appear in search results depending on IsListed is true or false (.*)")]
        public void ThenVerifyThatShouldAppearInSearchResultsDependingOnIsListedIsTrueOrFalse(string hotelName, string isListed)
        {
            bool doesHotelMatchRule = FilterAndSelectPage.CheckHotelListForName(hotelName, isListed);
            doesHotelMatchRule.Should().BeTrue();
            FilterAndSelectPage.GoBackToHomePage();
        }

    }
}
