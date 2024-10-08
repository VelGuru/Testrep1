﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoTest.PageObject
{
    class Homepage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "logout")]
        public IWebElement Logout { get; set; }

        [FindsBy(How = How.Id, Using = "logous")]
        public IWebElement Logoute { get; set; }
        

        [FindsBy(How = How.Id, Using = "Homepage")]
        public IWebElement Hompages { get; set; }

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void logoutPHP()
        {
            Logoute.Click();
        }

        public void HomePage()
        {
            Hompages.Click();
        }

        public void logoutPHPs()
        {
            Logoute.Click();
        }
    }
}
