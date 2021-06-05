using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest.PageObject
{
    public class DashboardPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Login']")]
        public IWebElement btn_login { get; set; }


        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LoginTOPHP()
        {
            ExcelHelpers.PopulateInCollection("F:\\visual studio 2013\\Projects\\DemoTest\\DemoTest\\TestData\\TestData.xlsx");

            UserName.SendKeys(ExcelHelpers.ReadData(1, "UserName"));
            Password.SendKeys(ExcelHelpers.ReadData(1, "Password"));
            btn_login.Click();
        }
    }
}
