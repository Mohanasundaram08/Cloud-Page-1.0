using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections;
using System.Threading;

namespace Automation.Test
{
    public class SeleniumMethods
    {

        //********************************
        // Define Browsers & Properties***
        //********************************       
        public static string[] browsers = { "chrome", "firefox" };

        public static void InitializeChromeDriver(out RemoteWebDriver driver)
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--incognito");
            //options.AddArgument("start-maximized");
            //options.AddArgument("headless");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public static void InitializeFirefoxDriver(out RemoteWebDriver driver)
        {
            FirefoxOptions optionsf = new FirefoxOptions();
            optionsf.AddArgument("-private");
            //optionsf.AddArgument("-headless");
            driver = new FirefoxDriver(optionsf);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }


        //********************
        // Define Variables***
        //********************
        public IWebDriver driver;

        public static string urlEsabCloud = "https://dev.esabcloud.com/"; //website
        public static string urlEsabCloudTest = "https://dev.esabcloud.com/"; //website
        public static string esabCloudWebTitle = "Esab Cloud";
        //public static string urlEsabCloud = "https://dev.esabcloud.com/"; //website
        public static string urlEsabCloud_Test = "https://testweldcloud.b2clogin.com/testweldcloud.onmicrosoft.com/oauth2/v2.0/authorize?p=B2C_1_Thingworx_Sign_in_v2&client_id=9bfc2943-dca2-4489-be5e-929b61a224da&nonce=defaultNonce&response_mode=query&redirect_uri=https%3A%2F%2Ftest.esabcloud.com%2Fmodules&scope=openid&response_type=id_token";
        //Login Roles/Credentials
        public static string customerLogin = "esdigt@gmail.com"; // Customer Admin test
        public static string customerPass = "Welding2020!"; //test

        //public static string globalLogin = "esdigt@gmail.com"; //customer
        //public static string globalPass = "Esab@12345"; //test
        public static string globalLogin = "dhiego.silva@esab.de"; //test
        //public static string globalPass = "7m19!^(!OA!%^L"; //test
        public static string globalPass = "Welding2020!"; //test

        public static string TestInstanceLogin = "vijaykumar.c@esab.co.in"; //test
        public static string TestInstancePass = "Vijay2020!"; //test

        public static string userLogin = "dhiego.silva@hotmail.com"; //user login
        public static string userPass = "Welding2020!";
        //*************************************


        //********************
        //Categories Main Page
        //********************
        public static string productivity = "WeldCloud Productivity";
        public static string motion = "WeldCloud Motion";
        public static string notes = "WeldCloud Notes";
        public static string cutCloud = "CutCloud";
        //*************************************


        //**********************************
        //Common Shared Methods*************
        //**********************************
        public static void EnterText(IWebDriver driver, string element, string value)
        {
            if (value == "Id")
                driver.FindElement(By.Id(element)).SendKeys(value);
            if (value == "Name")
                driver.FindElement(By.Name(element)).SendKeys(value);
        }

        public static void Login(RemoteWebDriver driver, string username, string password)
        {
            driver.FindElement(By.Id("logonIdentifier"));
            driver.FindElement(By.Id("logonIdentifier")).Clear();
            driver.FindElement(By.Id("logonIdentifier")).SendKeys(username);
            driver.FindElement(By.Id("password"));
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(password + Keys.Enter);
        }

        public static void Nav2Dashboard(RemoteWebDriver driver)
        {
            //driver.FindElement(By.XPath("//h2[contains(.,'Productivity')]")).Click();

            driver.FindElement(By.XPath("//div[@id='modules']/section/div[3]/div/div/div/img"));
            driver.FindElement(By.XPath("//div[@id='modules']/section/div[3]/div/div/div/img")).Click();//Old productivity
         /*   string newTabInstance = driver.WindowHandles[^1].ToString();
            driver.SwitchTo().Window(newTabInstance); */
        }
        //*************************************


        //*************************************
        // Define After Test Clean Procedure***
        //*************************************
        public static void CleanProcesses()
        {
            foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName == "chromedriver")
                {
                    myProc.Kill();
                }
                if (myProc.ProcessName == "geckodriver")
                {
                    myProc.Kill();
                }
            }
        }
        //*************************************

      

        public static void Click(RemoteWebDriver driver, IWebElement name)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(name);
            action.Perform();
            name.Click();

        }

        public static void Check(RemoteWebDriver driver, string Location, string TextValue, string ErrorMessage)
        {
            string errorText = null;
            bool asset = true;

            try
            {
                IWebElement element = driver.FindElement(By.XPath(Location));
                Actions action = new Actions(driver);
                action.MoveToElement(element);
                action.Perform();
                Assert.AreEqual(TextValue, element.Text);

            }
            catch
            {
                errorText = string.Concat(errorText, "Browser= " + driver.Capabilities.GetCapability("browserName").ToString() + ErrorMessage);
                asset = false;
            }
            if (asset == false)
            {
                Assert.Fail(errorText);
            }
        }

        public static void Element_check(RemoteWebDriver driver, string Location, string TextValue, string ErrorMessage)
        {
            string errorText = null;
            bool asset = true;

            try
            {
                IWebElement element = driver.FindElement(By.XPath(Location));
                Actions action = new Actions(driver);
                action.MoveToElement(element);
                action.Perform();

            }
            catch
            {
                errorText = string.Concat(errorText, "Browser= " + driver.Capabilities.GetCapability("browserName").ToString() + ErrorMessage);
                asset = false;
            }
            if (asset == false)
            {
                Assert.Fail(errorText);
            };

        }




    }
}
