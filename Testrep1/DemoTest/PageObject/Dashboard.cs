using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest.PageObject
{
    public class Dashboard
    {
        [FindsBy(How = How.Id, Using = "Homepage")]
        public IWebElement Hompages { get; set; }
    }
}
