using AvivaGooglesearchTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AvivaGooglesearchTest.Pages
{
    class ResultsPage:Baseclass
    {
        public ResultsPage()
        {
            PageFactory.InitElements(Baseclass.driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//h3/a")]
        public IList<IWebElement> totallinks { get; set; }

        int totallinkscount;

        //Prints the fifth link text of Results page of Aviva
        public void resultsPage(int linknumber)
        {
            Console.WriteLine("Link text of 5 th link is:" + totallinks.ElementAt(linknumber).Text);
        }

        //Assertion on number of links returned on searching Aviva in Google home page
        public void verifyLinks(int count)
        {
            totallinkscount = totallinks.Count;
            Console.WriteLine("Total number of links returned:" + totallinkscount);
            Console.WriteLine("Expected number of links returned :" + count);
            Assert.AreNotEqual(count, totallinkscount);
        }

        //Passing junk text and result should be page not found page
        public void negativeScenario()
        {
            IWebElement p = driver.FindElement(By.XPath("//p[contains(@style,'padding-top:')]"));
            Console.WriteLine("p value is : " + p.Text);
            Assert.AreNotEqual("Aviva", p.Text);
        }

    }

}

