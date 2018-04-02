using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvivaGooglesearchTest.Utilities
{
    class Baseclass
    {
        public static IWebDriver driver;

        public static void InitializeBrowser(String browsername)
        {
            //chrome
            if (browsername.Equals("Chrome"))
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            //IE
            if (browsername.Equals("IE"))
            {
                driver = new InternetExplorerDriver();
                driver.Manage().Window.Maximize();
            }
            //Firefox
            if (browsername.Equals("Firefox"))
            {
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
            }
            
        }

        public void TakeScreenshotAfterEachStep()
        {

            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            if (takesScreenshot != null)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);
                Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
            }
        }
    }
}
