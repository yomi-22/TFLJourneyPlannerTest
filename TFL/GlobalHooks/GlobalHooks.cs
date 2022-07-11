using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TFL.Pages;

namespace TFL.GlobalHooks
{
    class GlobalHooks
    {
        IWebDriver WebDriver;

          public JourneyPlannerPage JourneyPlannerPage { get; set; }


        [BeforeScenario()]
        public void setup()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            JourneyPlannerPage JourneyPlannerPage = new JourneyPlannerPage(WebDriver);
        }

        [AfterScenario()]
        public void tearDown()
        {
            WebDriver.Quit();
        }
    }
}
