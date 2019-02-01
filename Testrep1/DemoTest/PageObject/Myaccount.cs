using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoTest.PageObject
{
    class Myaccount
    {
        private IWebDriver driver;


        [FindsBy(How = How.Id, Using = "account")]
        public IWebElement Account { get; set; }

        [FindsBy(How = How.Name, Using = "fname")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Name, Using = "lname")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Submit']")]
        public IWebElement Btn_Submit { get; set; }

        public Myaccount(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void changeAccountDetails()
        {
            Account.Click();
            FirstName.Clear();
            FirstName.SendKeys("SA");
            LastName.Clear();
            LastName.SendKeys("SuperAdmin");
            Btn_Submit.Click();
        }

    }
}
