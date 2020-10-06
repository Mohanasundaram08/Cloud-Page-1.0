using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SetUp;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace demo
{   [TestFixture]
    public class Program
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void Main ()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://dev.esabcloud.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
        }
        [Test, Order(0)]
        public void Login()
        {
            driver.FindElement(By.Id("logonIdentifier")).SendKeys("esdigt@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("Welding2020!");
            driver.FindElement(By.Id("next")).Click();
        }
        [Test, Order(1)]
        public void Check()
        {
            driver.FindElement(By.XPath("//div[@id='modules']/section/div[5]/div/div/div/img")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/div/div/div/div[2]/a/span")).Click();
            SelectElement box = new SelectElement(driver.FindElement(By.XPath("//*[@id='app']/div/div[3]/div[2]/div[2]/section/div[1]/div/div[1]/div/div/div[2]/div")));
            box.SelectByIndex(1);
        }
    }
}
