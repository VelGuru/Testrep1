using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest.Helpers
{
    class WebDriverFactory
    {
        private static readonly IDictionary<string,IWebDriver> Drivers= new Dictionary<string,IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized");
                return driver;
            }
            set
            {
                driver = value;
            }
        }

        public static void InitDriver(string browserName)
        {
            switch(browserName.ToLower())
            {
                case "firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                        driver.Manage().Window.Maximize();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                        Drivers.Add("firefox", Driver);
                    }
                    break;
                case "chrome":
                    if (driver == null)
                    {
                        driver = new ChromeDriver();
                        driver.Manage().Window.Maximize();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                        Drivers.Add("chrome", Driver);
                    }
                    break;
                case "ie":
                    if (driver == null)
                    {
                        driver = new InternetExplorerDriver();
                        driver.Manage().Window.Maximize();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                        Drivers.Add("ie", Driver);
                    }
                    break;
            }
        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseDriver()
    {
       foreach(var key in Drivers.Keys)
       {
           Drivers[key].Close();
           Drivers[key].Quit();
       }
    }
    }
}
