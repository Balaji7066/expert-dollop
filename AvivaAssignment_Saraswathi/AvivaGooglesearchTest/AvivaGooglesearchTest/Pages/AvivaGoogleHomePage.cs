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
    class AvivaGoogleHomePage : Baseclass
    {
        public AvivaGoogleHomePage()
        {
            PageFactory.InitElements(Baseclass.driver, this);
        }


        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement Searchbox { get; set; }

        [FindsBy(How = How.Name, Using = "btnk")]
        public IWebElement searchbutton { get; set; }

       //Enter the keyword 'Aviva' on Google Search bar
       public void SearchGoogleHomePage(string keyword)
        {
            Searchbox.SendKeys(keyword);
        }

       //Click on Googlesearch button
        public void clickSearchButton()
        {
            Searchbox.Submit();
        }

       }
    
}
