using TechTalk.SpecFlow;

using AvivaGooglesearchTest.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AvivaGooglesearchTest.Utilities;

namespace AvivaGooglesearchTest
{
    [Binding]
    class StepDefinitions : Baseclass
    {

        ResultsPage gpage;
        AvivaGoogleHomePage Hpage;

        [BeforeScenario]
        public  void Initialize()
        {
            InitializeBrowser("Chrome");
            gpage = new ResultsPage();
            Hpage = new AvivaGoogleHomePage();
        }

        [Given(@"launch the google home page")]

        public void LaunchGooglehomepage()
        {
            driver.Url = "http://www.google.co.uk";
        }

        [Given(@"search with the string '(.*)'")]
        public void GivenSearchWithTheString(string keyword)
        {  
           Hpage.SearchGoogleHomePage(keyword);   
        }

       [When(@"click on search button")]
        public void WhenClickOnSearchButton()
        {
            Hpage.clickSearchButton(); 
        }
        
        [Then(@"number of links returned should be (.*)")]
        public void ThenNumberOfLinksReturnedShouldBe(int count)
        {
            gpage.verifyLinks(count);
        }
        
        [Then(@"prints the (.*)th link text of results page\.")]
        public void ThenPrintsTheThLinkTextOfResultsPage_(int linknumber)
        {
           gpage.resultsPage(linknumber);
        }

        [Then(@"No results found page should be shown\.")]
        public void ThenNoResultsFoundPageShouldBeShown_()
        {
            gpage.negativeScenario();
        }

        [AfterStep]

        public void Screenshot()
        {
            TakeScreenshotAfterEachStep();
        }

        [AfterScenario]
        public void quitDriver()
        {
           driver.Quit();
        }
    }
}
