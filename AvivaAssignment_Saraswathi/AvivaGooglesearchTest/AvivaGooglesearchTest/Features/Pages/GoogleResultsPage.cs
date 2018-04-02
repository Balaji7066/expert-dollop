
using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace AvivaGooglesearchTest.Pages
{
    class GoogleResultsPage :Base
    {
        [FindsBy(How =How.Name,Using ="q")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.Name, Using = "btnk")]
        public IWebElement Searchbutton { get; set; }

        [FindsBy(How =How.XPath,Using =".//h3/a")]
        public IList<IWebElement> totallinks { get; set; }

        public static IWebDriver driver;
        int totallinkscount;

        public GoogleResultsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


   
    public void SearchGoogleHomePage(String keyword)
    {
            SearchBox.SendKeys(keyword);
    }

    public void clickSearchButton()
        {
            SearchBox.Submit();

        }

        public void resultsPage(int linknumber)
        {
            totallinkscount = totallinks.Count;
            Console.WriteLine("Print number of links" + totallinkscount);
            Console.WriteLine("Fifth Link text is" + totallinks.ElementAt(linknumber).Text);
       }

        public void verifyLinks(int count)
        {
            Assert.AreEqual(count, totallinkscount);
        }

        public void negativeScenario()
        {
            IWebElement p = driver.FindElement(By.XPath("//p[contains(@style,'padding-top:')]"));
            Console.WriteLine("p value is :" + p.Text);
            Assert.AreNotEqual("Aviva", p.Text);
        }


       

          

}
}
