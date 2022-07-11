using FluentAssertions;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TFL.Pages;

namespace TFL.Steps
{

    [Binding]
    public sealed class JourneyPlannerSteps
    {
        private IWebDriver WebDriver;

        public JourneyPlannerPage JourneyPlannerPage { get; private set; }

        public JourneyPlannerSteps(IWebDriver driver)
        {
            Guard.ArgumentNotNull(driver, nameof(driver));

            WebDriver = driver;
        }

        [BeforeScenario()]
        public void Setup()
        {
            JourneyPlannerPage = new JourneyPlannerPage(WebDriver);
        }

        [Given(@"the user is on tfl home page")]
        public void GivenTheUserIsOnTflHomePage()
        {
            WebDriver.Navigate().GoToUrl("https://tfl.gov.uk/");
        }

        [When(@"the user clicks on '(.*)' tab")]
        [Given(@"the user clicks on '(.*)' tab")]
        public void GivenTheUserClicksOnTab(string journeyPlanner)
        {
            JourneyPlannerPage.GetPlanAJourneyTabTitle().Should().Be(journeyPlanner);
            JourneyPlannerPage.ClickOnPlanAJourneyTab();
            JourneyPlannerPage.GetPlanAJourneyHeaderTextMessage().Should().Be(journeyPlanner);
        }

        [When(@"the user enters a new valid from location as '(.*)' and to location as '(.*)'")]
        [Given(@"the user enters invalid from location as '(.*)' and to location as '(.*)'")]
        [Given(@"the user leaves from location field and to location field empty")]
        [Given(@"the user enters a valid from location as '(.*)' and to location as '(.*)'")]
        public void GivenTheUserEntersAValidFromLocationAsAndToLocationAs(string fromLocation, string toLocation)
        {
            JourneyPlannerPage.EnterJourneyDetails(fromLocation, toLocation);
        }

        [Given(@"the user clicks on '(.*)' button")]
        [When(@"the user clicks on '(.*)' button")]
        public void WhenTheUserClicksOnButton(string planMyJourneyBtnLabel)
        {
            JourneyPlannerPage.IsPlanMyJourneyBtnDisplayed().Should().BeTrue();
            JourneyPlannerPage.GetPlanMyJourneyButtonText().Should().Be(planMyJourneyBtnLabel);
            JourneyPlannerPage.ClickOnPlanMyJourneyBtn();
        }

        [Then(@"the user should see empty From location error message as '(.*)' error message")]
        public void ThenTheUserShouldSeeEmptyFromLocationErrorMessageAsErrorMessage(string emptyFromLocationError)
        {
            JourneyPlannerPage.GetEmptyFromLocationErrorMessage().Should().Be(emptyFromLocationError);
        }

        [Then(@"the user should see empty To location error message as '(.*)' error message")]
        public void ThenTheUserShouldSeeEmptyToLocationErrorMessageAsErrorMessage(string emptyToLocationError)
        {
            JourneyPlannerPage.GetEmptyToLocationErrorMessage().Should().Be(emptyToLocationError);
        }

        [Given(@"the journey results details is displayed as follows:")]
        [Then(@"the journey results details is displayed as follows:")]
        public void ThenTheJourneyResultsDetailsIsDisplayedAsFollows(Table journeyDetails)
        {
            var journeySummary = journeyDetails.CreateInstance<JourneyResultSummary>();
            JourneyPlannerPage.GetJourneyResultHeaderText().Should().Be(journeySummary.JourneyResultsHeader);
            JourneyPlannerPage.GetFromLabelJourneySummaryPageText().Should().Be(journeySummary.From);
            JourneyPlannerPage.ToFromLabelJourneySummaryPageText().Should().Be(journeySummary.To);
            JourneyPlannerPage.GetFromLocationJourneyResultSummaryPageText().Should().Contain(journeySummary.FromLocation);
            JourneyPlannerPage.ToFromLocationJourneyResultSummaryPageText().Should().Contain(journeySummary.ToLocation);
            JourneyPlannerPage.IsEditButtonJourneySummaryPageBtnDisplayed().Should().BeTrue();
            JourneyPlannerPage.GetEditButtonJourneySummaryPageText().Should().Be(journeySummary.EditJourney);
            JourneyPlannerPage.IsAddFavouriteButtonJourneySummaryPageBtnDisplayed().Should().BeTrue();
            JourneyPlannerPage.GetAddFavouriteButtonJourneySummaryPageText().Should().Be(journeySummary.AddFavourite);
            JourneyPlannerPage.GetLeavingLabelJourneySummaryPageText().Should().Be(journeySummary.Leaving);
            DateTime dateTime = DateTime.UtcNow;

            // I did not check the time because the time user search is not displaying the current time, it displays the 
            // closest next train time and this varies each time the user search train journey

            var expectedApproximatelyTravelJourney = $"{dateTime.Day}{ dateTime.Date} {dateTime.Month}";

            var getLeavingTravelTime = journeySummary.LeavingTravelTime.ToString();
            getLeavingTravelTime = expectedApproximatelyTravelJourney;

            JourneyPlannerPage.GetLeavingJourneyTimeSummaryPageText().Should().Contain(getLeavingTravelTime);
            JourneyPlannerPage.GetFastestJourneyByPublicTransportText().Should().Be(journeySummary.FastestJourneyByPublicTransport);
            JourneyPlannerPage.IsMapViewJourneyResultSummaryPageBtnDisplayed().Should().BeTrue();
            JourneyPlannerPage.GetMapViewJourneyResultSummaryPageText().Should().Be(journeySummary.MapView);
            JourneyPlannerPage.IsViewDetailsJourneyResultSummaryPageBtnDisplayed().Should().BeTrue();
            JourneyPlannerPage.GetViewDetailsJourneyResultSummaryPage().Should().Be(journeySummary.ViewDetails);
        }

        [Then(@"the user should not see result for the invalid search locations")]
        public void ThenTheUserShouldNotSeeResultForTheInvalidSearchLocations()
        {
            JourneyPlannerPage.IsMapViewJourneyResultSummaryPageBtnDisplayed().Should().BeFalse();
            JourneyPlannerPage.IsViewDetailsJourneyResultSummaryPageBtnDisplayed().Should().BeFalse();
            JourneyPlannerPage.IsMapViewTextJourneyResultSummaryPageDisplayed().Should().BeFalse();
        }

        [Then(@"the user should see invalid location error message")]
        public void ThenTheUserShouldSeeInvalidLocationErrorMessage()
        {
            string expectedErrorMessage = "Sorry, we can't find a journey matching your criteria";
            JourneyPlannerPage.GetInvalidLocationErrorMessageOnSummaryPage().Should().Be(expectedErrorMessage);
        }

        [When(@"the user clicks on edit journey button")]
        public void WhenTheUserClicksOnEditJourneyButton()
        {
            JourneyPlannerPage.IsEditButtonJourneySummaryPageBtnDisplayed().Should().BeTrue();
            JourneyPlannerPage.ClickOnEditButtonOnSummaryPageText();
        }

        [Then(@"the recent planned journeys are displayed as follows:")]
        public void ThenTheRecentPlannedJourneysAreDisplayedAsFollows(Table recentJourneyPlanned)
        {
            var ListjourneySummary = recentJourneyPlanned.CreateInstance<JourneyResultSummary>();

            JourneyPlannerPage.IsRecentWidgetBtnDisplayedOnHomePage().Should().BeTrue();
            JourneyPlannerPage.GetRecentWidgetBtnOnHomePageText().Should().Be("Recents");
            JourneyPlannerPage.GetListsOfRecentPlannedJourneysLocations().Should().Contain(ListjourneySummary.FromLocation);
            JourneyPlannerPage.GetListsOfRecentPlannedJourneysLocations().Should().Contain(ListjourneySummary.ToLocation);
        }
    }
}

