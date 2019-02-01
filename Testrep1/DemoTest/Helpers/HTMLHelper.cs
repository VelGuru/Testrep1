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
using System.Configuration;

namespace DemoTest.Helpers
{
    public abstract class HTMLHelper
    {
         protected ExtentReports _extent;
         protected ExtentTest _test;
         public  IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeClass()
        {
            var reportpath = ConfigurationManager.AppSettings["ReportPath"] + @"\ExtendReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportpath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("HostName","PhpAdmin");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("Broswer", "Chrome");
        }

        [SetUp]
        public void Starup()
        {
            WebDriverFactory.InitDriver(ConfigurationManager.AppSettings["browser"]);
            driver = WebDriverFactory.Driver;
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["Url"]);
        }

       

        [TearDown]
        public void Warpdown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logStatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    _test.Log(Status.Fail, "Fail");
                    break;
                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    break;
                default:
                    logStatus = Status.Pass;
                    break;
            }
            _test.Log(logStatus, "Test Ended with " + logStatus + stacktrace);
            _extent.Flush();
            WebDriverFactory.CloseDriver();
           
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            _extent.Flush();
        }
    }
}
