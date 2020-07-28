using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest.PageObject
{
    class Git
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "logout")]
        public IWebElement Logout { get; set; }


        public Git(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void logoutPHP()
        {
            Logout.Click();
        }

    }
}
