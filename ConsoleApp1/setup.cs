﻿using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SetUp
{
    public class Setup
    {
        public IWebDriver driver;
        public ExtentReports extent = new ExtentReports();
        public ExtentTest test;

        public string Email = "vijaykumar.c @esab.co.in";
        public string PassWord = "Vijay2020!";

        //paths
        public string Reports_path = "//*[@id='root_menu-40']/li[2]/table/tbody/tr/td/a";
        public string WeldSession_path = "//*[@id='root_menu-40']/li[3]/table/tbody/tr/td/a/span";
        public string FleetManagement_path = "//*[@id='root_menu-40']/li[4]/table/tbody/tr/td/a/span";
        public string JobManagement_path = "//*[@id='root_menu-40']/li[5]/table/tbody/tr/td/a/span";
        public string AssetManagement_path = "//*[@id='root_menu-40']/li[6]/table/tbody/tr/td/a/span";
        public string UserManagement_path = "//*[@id='root_menu-40']/li[7]/table/tbody/tr/td/a/span";
        public string ShiftMangement_path = "//*[@id='root_menu-40']/li[8]/table/tbody/tr/td/a/span";
        public string AlertsAndSubscriptions_path = "//*[@id='root_menu-40']/li[9]/table/tbody/tr/td/a/span";
        public string ScanningList_path = "//*[@id='root_menu-40']/li[10]/table/tbody/tr/td/a/span";
        public string LicenceManagement_path = "//*[@id='root_menu-40']/li[11]/table/tbody/tr/td/a/span";
        public string Administration_path = "//*[@id='root_menu-40']/li[12]/table/tbody/tr/td/a/span";

        public static void Click(IWebDriver driver, IWebElement name)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(name);
            action.Perform();
            name.Click();

        }

        public static void Check(ExtentTest test, IWebDriver driver, string Location, string TextValue, string ErrorMessage)
        {
            try
            {
                IWebElement element = driver.FindElement(By.XPath(Location));
                Actions action = new Actions(driver);
                action.MoveToElement(element);
                action.Perform();
                if (TextValue == element.Text)
                {
                    test.Log(Status.Pass, TextValue + " Text is present");
                }
                else
                {
                    test.Log(Status.Fail,ErrorMessage);
                }
            }
            catch 
            {
                test.Log(Status.Fail,ErrorMessage +" - Unable to locate");
            }
        }

        public static void Element_check(ExtentTest test, IWebDriver driver, string Location, string TextValue, string ErrorMessage)
        {
            try
            {
                IWebElement element = driver.FindElement(By.XPath(Location));
                Actions action = new Actions(driver);
                action.MoveToElement(element);
                action.Perform();
                
                if (element.Displayed)
                {
                    test.Log(Status.Pass, TextValue + " is present");
                }
                else
                {
                    test.Log(Status.Fail, ErrorMessage);
                }
            }
            catch 
            {
                test.Log(Status.Fail, ErrorMessage + " - Unable to locate" );
            }
        }
      
        [OneTimeSetUp]
        public void Driver()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Rainbow\source\repos\ConsoleApp1\ConsoleApp1\repots\report.html");
            extent.AttachReporter(htmlReporter);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://testweldcloud.b2clogin.com/testweldcloud.onmicrosoft.com/oauth2/v2.0/authorize?p=B2C_1_Thingworx_Sign_in_v2&client_id=9bfc2943-dca2-4489-be5e-929b61a224da&nonce=defaultNonce&response_mode=query&redirect_uri=https%3A%2F%2Ftest.esabcloud.com%2Fmodules&scope=openid&response_type=id_token";

            void Login()
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);

                driver.FindElement(By.Id("logonIdentifier")).SendKeys("vijaykumar.c@esab.co.in");
                driver.FindElement(By.Id("password")).SendKeys("Vijay2020!");
                driver.FindElement(By.Id("next")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
            }

            void ClickProductivity()
            {
                driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/a[4]/div[1]")).Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
            }

            Login();
            ClickProductivity();
        }

        //Check(test, driver, , "", "not found");
        //Element_check(test, driver,,""," not found");

        [OneTimeTearDown]
        public void Close()
        {
            extent.Flush();
            
            driver.Quit();
        }
    }
}