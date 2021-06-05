using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using DemoTest.PageObject;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using DemoTest.Helpers;

namespace DemoTest.Testcases
{
    class LoginID : HTMLHelper
    {

        [Test]
        public void Login()
        {

            String folderPath = ConfigurationManager.AppSettings["ScreenshotPath"];
            

            var login = new Login(driver);
            login.LoginTOPHP();
            _test.Info("Entering the URL of PHPtraveler");
            //screenshots.SaveAsFile(folderPath + @"pic.png", ScreenshotImageFormat.Png);
            var myprofile = new Myaccount(driver);
            myprofile.changeAccountDetails();
            _test.Info("Changing the User name");
            var homepage = new Homepage(driver);
            homepage.logoutPHP();
            _test.Info("Logging Out");

           
        }

        [Test]
        public void Logout()
        {

            String folderPath = ConfigurationManager.AppSettings["ScreenshotPath"];


            var login = new Login(driver);
            login.LoginTOPHP();
            _test.Info("Entering the URL of PHPtraveler");
            //screenshots.SaveAsFile(folderPath + @"pic.png", ScreenshotImageFormat.Png);
            var myprofile = new Myaccount(driver);
            myprofile.changeAccountDetails();
            _test.Info("Changing the User name");
            var homepage = new Homepage(driver);
            homepage.logoutPHP();
            _test.Info("Logging Out");


        }
    }
}