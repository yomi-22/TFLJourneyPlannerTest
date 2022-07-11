using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace TFL.Pages
{
    [Binding]
    public class JourneyPlannerPage
    {
        protected IWebDriver WebDriver;
        protected readonly WebDriverWait Wait;
        public JourneyPlannerPage(IWebDriver driver)
        {
            Guard.ArgumentNotNull(driver, nameof(driver));

            WebDriver = driver;
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
        }



        IWebElement PlanAJourneyTab => Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("ul[class='collapsible-menu clearfix'] li[class='plan-journey'] a")));
        IWebElement PlanAJourneyHeaderText => Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("span.hero-headline")));
        IWebElement FromLocation => Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("span.twitter-typeahead #InputFrom")));
        IWebElement ToLocation => Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("span.twitter-typeahead #InputTo")));
        IWebElement PlanMyJourneyBtn => Wait.Until(ExpectedConditions.ElementToBeClickable(PlanMyJourneyBtnElement));
        IWebElement JourneyResultHeaderText => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("span.jp-results-headline")));
        IWebElement FromLocationError => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#InputFrom-error")));
        IWebElement ToLocationError => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#InputTo-error")));
        IWebElement MapViewJourneyResultSummaryPage => Wait.Until(ExpectedConditions.ElementIsVisible(MapViewJourneyResultSummaryPageElement));
        IWebElement ViewDetailsJourneyResultSummaryPage => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[id='option-1-content'] a[class='secondary-button show-detailed-results view-hide-details']")));
        IWebElement FromLabelJourneyResultSummaryPage => Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='From:']")));
        IWebElement ToLabelJourneyResultSummaryPage => Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='To:']")));
        IWebElement FromLocationJourneyResultSummaryPage => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.from-to-wrapper > div:nth-child(1) > span > strong")));
        IWebElement ToLocationJourneyResultSummaryPage => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.from-to-wrapper > div:nth-child(2) > span.notranslate > strong")));
        IWebElement LeavingLabelJourneySummaryPage => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[normalize-space()='Leaving:']")));
        IWebElement EditButtonJourneySummaryPage => Wait.Until(ExpectedConditions.ElementToBeClickable(EditButtonJourneySummaryPageElement));
        IWebElement AddFavouriteButtonJourneySummaryPage => Wait.Until(ExpectedConditions.ElementToBeClickable(AddFavouriteButtonJourneySummaryPageElement));
        IWebElement FastestByPublicTransport => Wait.Until(ExpectedConditions.ElementIsVisible(FastestByPublicTransportElement));
        IWebElement LeavingJourneyTimeSummaryPage => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.journey-result-summary > div:nth-child(2) > strong")));
        IWebElement InvalidLocationErrorMessageSummaryPage => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li.field-validation-error")));
        IWebElement RecentWidgetBtnOnHomePage => Wait.Until(ExpectedConditions.ElementToBeClickable(RecentWidgetElementOnHomePageElement));

        private By PlanMyJourneyBtnElement => By.CssSelector("#plan-journey-button");
        private By EditButtonJourneySummaryPageElement => By.CssSelector("a[class='edit-journey'] span");
        private By AddFavouriteButtonJourneySummaryPageElement => By.CssSelector("span.align-text");
        private By MapViewJourneyResultSummaryPageElement => By.CssSelector("div[id='option-1-content'] a[class='secondary-button show-detailed-results map-view view-on-a-map']");
        private By ViewDetailsJourneyResultSummaryPageElement => By.CssSelector("div[id='option-1-content'] a[class='secondary-button show-detailed-results view-hide-details']");
        private By FastestByPublicTransportElement => By.CssSelector(".jp-result-transport.publictransport.clearfix");

        private By RecentWidgetElementOnHomePageElement => By.CssSelector("a[href = '#jp-recent']");
        private By ListOfPlannedJourneysElementOnHomePage => By.CssSelector("#jp-recent-content-jp-");



        private IList<IWebElement> GetListsOfRecentPlannedJourneys()
        {
            return WebDriver.FindElements(ListOfPlannedJourneysElementOnHomePage);
        }

        public IEnumerable<string> GetListsOfRecentPlannedJourneysLocations()
        {
            return GetListsOfRecentPlannedJourneys().Select(x => x.Text).ToList();
        }

        public void EnterJourneyDetails(string fromLocation, string toLocation)
        {
            FromLocation.Clear();
            ToLocation.Clear();

            FromLocation.SendKeys(fromLocation);
            ToLocation.SendKeys(toLocation);
        }

        public void ClickOnPlanAJourneyTab()
        {
            PlanAJourneyTab.Click();
        }

        public string GetRecentWidgetBtnOnHomePageText()
        {
            return RecentWidgetBtnOnHomePage.Text;
        }

        public bool IsRecentWidgetBtnDisplayedOnHomePage()
        {
            return WebDriver.FindElement(RecentWidgetElementOnHomePageElement).Enabled;
        }

        public void ClickOnPlanMyJourneyBtn()
        {
            PlanMyJourneyBtn.Click();
        }

        public bool IsPlanMyJourneyBtnDisplayed()
        {
            return WebDriver.FindElement(PlanMyJourneyBtnElement).Enabled;
        }

        public string GetPlanAJourneyTabTitle()
        {
            return PlanAJourneyTab.Text;
        }

        public string GetEmptyFromLocationErrorMessage()
        {
            return FromLocationError.Text;
        }
        public string GetEmptyToLocationErrorMessage()
        {
            return ToLocationError.Text;
        }

        public string GetPlanAJourneyHeaderTextMessage()
        {
            return PlanAJourneyHeaderText.Text;
        }

        public string GetPlanMyJourneyButtonText()
        {
            return PlanMyJourneyBtn.Text;
        }

        public string GetJourneyResultHeaderText()
        {
            return JourneyResultHeaderText.Text;
        }

        public string GetFromLabelJourneySummaryPageText()
        {
            return FromLabelJourneyResultSummaryPage.Text;
        }

        public string ToFromLabelJourneySummaryPageText()
        {
            return ToLabelJourneyResultSummaryPage.Text;
        }

        public string GetFromLocationJourneyResultSummaryPageText()
        {
            return FromLocationJourneyResultSummaryPage.Text;
        }

        public string ToFromLocationJourneyResultSummaryPageText()
        {
            return ToLocationJourneyResultSummaryPage.Text;
        }

        public bool IsEditButtonJourneySummaryPageBtnDisplayed()
        {
            return WebDriver.FindElement(EditButtonJourneySummaryPageElement).Enabled;
        }

        public string GetEditButtonJourneySummaryPageText()
        {
            return EditButtonJourneySummaryPage.Text;
        }

        public void ClickOnEditButtonOnSummaryPageText()
        {
            EditButtonJourneySummaryPage.Click();
        }

        public bool IsAddFavouriteButtonJourneySummaryPageBtnDisplayed()
        {
            return WebDriver.FindElement(AddFavouriteButtonJourneySummaryPageElement).Enabled;
        }

        public string GetAddFavouriteButtonJourneySummaryPageText()
        {
            return AddFavouriteButtonJourneySummaryPage.Text;
        }

        public string GetLeavingLabelJourneySummaryPageText()
        {
            return LeavingLabelJourneySummaryPage.Text;
        }

        public string GetLeavingJourneyTimeSummaryPageText()
        {
            return LeavingJourneyTimeSummaryPage.Text;
        }

        public string GetFastestJourneyByPublicTransportText()
        {
            return FastestByPublicTransport.Text;
        }

        public bool IsMapViewJourneyResultSummaryPageBtnDisplayed()
        {
            return WebDriver.FindElement(MapViewJourneyResultSummaryPageElement).Enabled;
        }

        public string GetMapViewJourneyResultSummaryPageText()
        {
            return MapViewJourneyResultSummaryPage.Text;
        }

        public bool IsMapViewTextJourneyResultSummaryPageDisplayed()
        {
            return WebDriver.FindElement(MapViewJourneyResultSummaryPageElement).Enabled;
        }

        public bool IsViewDetailsJourneyResultSummaryPageBtnDisplayed()
        {
            return WebDriver.FindElement(ViewDetailsJourneyResultSummaryPageElement).Enabled;
        }

        public bool IsViewDetailsTextJourneyResultSummaryPageDisplayed()
        {
            return WebDriver.FindElement(ViewDetailsJourneyResultSummaryPageElement).Enabled;
        }

        public string GetViewDetailsJourneyResultSummaryPage()
        {
            return ViewDetailsJourneyResultSummaryPage.Text;
        }

        public string GetInvalidLocationErrorMessageOnSummaryPage()
        {
            return InvalidLocationErrorMessageSummaryPage.Text;
        }
    }
}