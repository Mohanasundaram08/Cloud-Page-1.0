using System;
using System.Collections;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Automation.Test;
using OpenQA.Selenium.Firefox;
using System.Drawing.Text;

namespace Administration
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class Administration_page <TWebDriver> where TWebDriver : RemoteWebDriver, new()
    {
       
        public RemoteWebDriver driver;

        public string Delete_button = "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-180']/button";
        public string CreateNode_button = "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-231']/button";
        public string EditNode_button = "(//button[@class='button-element textsize-xlarge'])[4]";
        public string Inital_node_path = "//span[contains(text(),'AutomationTest')]";
        public string Edited_node_path = "//span[contains(text(),'AutomationTest1')]";
        public string Edited_NestedNode_path = "//span[contains(text(),'NestedNode(Edited)')]";
        public string Inital_name = "AutomationTest";
        public string Edited_name = "AutomationTest1";
        public string Confirm_Button = "//*[@id='confirmButtons']/a[1]";

//**************************************************************************************************************************
        public ArrayList Create_Node(string name, string path)
        {
            string errorText = null;
            bool asset = true;
            ArrayList Flag = new ArrayList
            {
                errorText,
                asset
            };

            try
            {
                SeleniumMethods.Click(driver, driver.FindElement(By.XPath(CreateNode_button)));
                //Node name field
                driver.FindElement(By.XPath("//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_navigationTooltip-230-popup_textbox-229']/table/tbody/tr/td/input")).Clear();
                driver.FindElement(By.XPath("//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_navigationTooltip-230-popup_textbox-229']/table/tbody/tr/td/input")).SendKeys(name);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//div[contains(text(),'Create node')]")).Click();
                Thread.Sleep(10000);
                //create Button
                driver.FindElement(By.XPath("(//button[@class='button-element textsize-large'])[4]")).Click();

                Thread.Sleep(10000);
                Assert.AreEqual(name, driver.FindElement(By.XPath(path)).Text);
                return Flag;
            }
            catch
            {
                errorText = string.Concat(errorText, "Browser= " + ((RemoteWebDriver)driver).Capabilities.GetCapability("browserName").ToString()+  name);
                asset = false;
                ArrayList ErrorFlag = new ArrayList
                {
                    errorText,
                     asset
                };
                return ErrorFlag;
            }

        }

        public ArrayList Edit_node(string name, string path, string Modifying_path)
        {
            IWebElement element = driver.FindElement(By.XPath(Modifying_path));

            string errorText = null;
            bool asset = true;
            ArrayList Flag = new ArrayList
            {
                 errorText,
                 asset
            };
            try
            {
                element.Click();
                driver.FindElement(By.XPath(EditNode_button)).Click();

                driver.FindElement(By.XPath("//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_navigationTooltip-221-popup_textbox-229']/table/tbody/tr/td/input")).Clear();
                driver.FindElement(By.XPath("//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_navigationTooltip-221-popup_textbox-229']/table/tbody/tr/td/input")).SendKeys(name);
                driver.FindElement(By.XPath("//div[contains(text(),'Edit node')]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_navigationTooltip-221-popup_button-15']/button")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath(Confirm_Button)).Click();
                Thread.Sleep(2000);
                IWebElement node = driver.FindElement(By.XPath(path));
                Assert.AreEqual(name, node.Text);
                return Flag;

            }
            catch
            {
                errorText = string.Concat(errorText, "Browser= " + ((RemoteWebDriver)driver).Capabilities.GetCapability("browserName").ToString() + name);
                asset = false;

                ArrayList ErrorFlag = new ArrayList
                {
                    errorText,
                     asset
                };
                return ErrorFlag;
            }


        }

        public ArrayList Nested_node()
        {
            driver.FindElement(By.XPath(Edited_node_path)).Click();
            string errorText = null;
            bool asset = true;
            ArrayList Flag = new ArrayList
            {
                 errorText,
                 asset
            };

            for (int i = 0; i < 2; i++)
            {
                string name = "NestedNode" + i;

                ArrayList ErrorFlag = Create_Node(name, "//span[contains(text(),'" + name + "')]");
                if ((bool)ErrorFlag[1] == false)
                {
                    return ErrorFlag;

                }
            }
            return Flag;

        }

        public ArrayList Create_Customer(string name, string path, string Creation_path)
        {                     
            string errorText = null;
            bool asset = true;
            ArrayList Flag = new ArrayList
            {
                 errorText,
                 asset
            };

            try
            {
                driver.FindElement(By.XPath(path)).Click();

                //create customer button
                driver.FindElement(By.XPath("//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-319']/button")).Click();

                IWebElement Create_customer_Field = driver.FindElement(By.XPath("(//input[@class='widget-textbox-box textsize-normal left'])[2]"));
                Create_customer_Field.Clear();
                Create_customer_Field.SendKeys(name);

                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//div[contains(text(),'Create customer')]")).Click();
                Thread.Sleep(2000);

                //create button
                driver.FindElement(By.XPath("//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_navigationTooltip-318-popup_button-22']/button")).Click();
                Thread.Sleep(10000);

                IWebElement node = driver.FindElement(By.XPath(Creation_path));
                Assert.AreEqual(name, node.Text);
                return Flag;
            }
            catch
            {                                                                
                errorText = string.Concat(errorText, "Browser= " + ((RemoteWebDriver)driver).Capabilities.GetCapability("browserName").ToString() + name);
                asset = false;
                ArrayList ErrorFlag = new ArrayList
                {
                    errorText,
                     asset
                };
                return ErrorFlag;
            }
        }

        public ArrayList Edit_Customer(string name, string path, string Modifying_path)
        {
            string errorText = null;
            bool asset = true;
            ArrayList Flag = new ArrayList
            {
                 errorText,
                 asset
            };

            try
            {
                IWebElement element = driver.FindElement(By.XPath(Modifying_path));

                Thread.Sleep(2000);

                driver.FindElement(By.XPath("(//table[@class='valuedisplay-wrapper'])[32]")).Click();

                IWebElement Customer_name_field = driver.FindElement(By.XPath("(//input[@class='widget-textbox-box textsize-normal left'])[2]"));
                Thread.Sleep(2000);
                Customer_name_field.Clear();
                Customer_name_field.SendKeys(name);

                driver.FindElement(By.XPath("//div[contains(text(),'Edit customer')]")).Click();
                Thread.Sleep(2000);
                //save button
                driver.FindElement(By.XPath("(//button[@class='button-element textsize-large'])[2]")).Click();
                Thread.Sleep(2000);
                //confirmation
                driver.FindElement(By.XPath(Confirm_Button)).Click();
                Thread.Sleep(2000);

                IWebElement node = driver.FindElement(By.XPath(path));
                Assert.AreEqual(name, node.Text);
                return Flag;
            }
            catch
            {
                errorText = string.Concat(errorText,"Browser= " + ((RemoteWebDriver)driver).Capabilities.GetCapability("browserName").ToString() +  name);
                asset = false;
                ArrayList ErrorFlag = new ArrayList
                {
                     errorText,
                     asset
                };
                return ErrorFlag;
            }
        }

        public ArrayList Delete_Customer(string name, string path)
        {
            string errorText = null;
            bool asset = true;
            ArrayList Flag = new ArrayList
            {
               errorText,
               asset
            };
            try
            {
                //clicking the element to be deleted
                driver.FindElement(By.XPath("(//td[@class='valuedisplay-text'])[14]")).Click();

                //delete Button
                driver.FindElement(By.XPath(Delete_button)).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath(Confirm_Button)).Click();
                Thread.Sleep(2000);

                return Flag;
            }
            catch
            {
                errorText = string.Concat(errorText, "Browser= " + ((RemoteWebDriver)driver).Capabilities.GetCapability("browserName").ToString() +  name);
                asset = false;
                ArrayList ErrorFlag = new ArrayList
                {
                    errorText,
                    asset
                };
                return ErrorFlag;
            }
        }

        public ArrayList Delete_node(string path)
        {
            string errorText = null;
            bool asset = true;
            ArrayList Flag = new ArrayList
            {
                 errorText,
                 asset
            };

            try
            {
                Thread.Sleep(2000);
                string name = driver.FindElement(By.XPath(path)).Text;

                driver.FindElement(By.XPath(path)).Click();

                driver.FindElement(By.XPath(EditNode_button)).Click();
                //Delete Icon
                driver.FindElement(By.XPath("(//button[@class='button-element textsize-large'])[1]")).Click();
                Thread.Sleep(2000);
                //confirmation 
                driver.FindElement(By.XPath(Confirm_Button)).Click();

                IWebElement node = driver.FindElement(By.XPath(path));
                Assert.AreEqual(name, node.Text);

                return Flag;
            }
            catch
            {
                errorText = string.Concat(errorText, "Browser= " + ((RemoteWebDriver)driver).Capabilities.GetCapability("browserName").ToString() );
                asset = false;
                ArrayList ErrorFlag = new ArrayList
                {
                     errorText,
                     asset
                };
                return ErrorFlag;
            }
        }

//*****************************************************************************************************************************      

        [Test,Order(0)]
        public void Create_ParentNode()
        {
            //Parent Node
            ArrayList value = Create_Node(Inital_name, Inital_node_path);

            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " -Parent Node Not Created ");
            }            
        }

        [Test, Order(1)]
        public void Edit_ParentNode()
        {
            //Edit Parent Node
            ArrayList value =  Edit_node(Edited_name, Edited_node_path, Inital_node_path);

            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " -Parent Node Not Edited ");
            }
        }

        [Test, Order(2)]
        public void Create_Multiple_NestedNode()
        {
            //To create Multiple Nested Node
            ArrayList value = Nested_node();

            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " -multiple nested node not created ");
            }
        }

        [Test, Order(3)]
        public void Edit_NestedNode()
        {
            //NestedNode Editing
            ArrayList value = Edit_node("NestedNode(Edited)", Edited_NestedNode_path, "//span[contains(text(),'NestedNode0')]");
            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " - Nested node not edited ");
            }
        }

        [Test, Order(4)]
        public void Create_Customer_at_parentNode()
        {           
            //Customer at parentNode
            ArrayList value = Create_Customer("Automation tester", Edited_node_path, "//div[contains(text(),'Automation tester')]");

            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " -Cannot create customer at parent node ");
            }
        }

        [Test, Order(5)]
        public void Edit_Customer_at_ParentNode()
        {    
            //Edit Parent Customer name
            ArrayList value = Edit_Customer("Automation tester(Edited)", "//div[contains(text(),'Automation tester(Edited)')]", "//div[contains(text(),'Automation tester')]");
            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " - customer at parent node not Edited");
            }
        }

        [Test, Order(6)]
        public void Delete_customer_at_ParentNode()
        {
            ArrayList value = Delete_Customer("Automation tester(Edited)", "//div[contains(text(),'Automation tester(Edited)')]");

            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " - Customer at ParentNode not deleted ");
            }
        }

        [Test, Order(7)]
        public void Create_Customer_at_NestedNode()
        {
            //Customer at NestedNode
           ArrayList value = Create_Customer("Automation Tester(Nested)", Edited_NestedNode_path, "//div[contains(text(),'Automation Tester(Nested)')]");
            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " -Customer at nested node not created");
            }
        }

        [Test, Order(8)]
        public void Edit_Customer_at_NestedNode()
        {
            //Edit Nested Customer name
            ArrayList value = Edit_Customer("Automation Tester(Nested)(Edited)", "//div[contains(text(),'Automation Tester(Nested)(Edited)')]", "//div[contains(text(),'Automation Tester(Nested)')]");
            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " - cannot edit customer at nested node ");
            }
        }

        [Test, Order(9)]
        public void Delete_customer_at_NestedNode()
        {
            ArrayList value = Delete_Customer("Automation Tester(Nested)(Edited)", "//div[contains(text(),'Automation Tester(Nested)(Edited)')]");

            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " - Customer at NestedNode not deleted ");
            }
        }

        [Test, Order(10)]
        public void Delete_NestedNode()
        {            
            //Delete Nested node
           ArrayList value = Delete_node(Edited_NestedNode_path);
            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " -Nested Node Not deleted ");
            }
        }

        [Test, Order(11)]
        public void Delete_Parent_Node()
        {
            //Delete Parent Node
           ArrayList value=  Delete_node(Edited_node_path);
            if ((bool)value[1] == false)
            {
                Console.WriteLine();
                Assert.Fail((string)value[0] + " -Parent Node Not deleted ");                
            }
        }

        [OneTimeSetUp]
        public void Main()
        {
             this.driver = new TWebDriver();           
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(SeleniumMethods.urlEsabCloud_Test);
           
            Thread.Sleep(20000);
            driver.FindElement(By.Id("logonIdentifier")).SendKeys(SeleniumMethods.TestInstanceLogin);
            driver.FindElement(By.Id("password")).SendKeys(SeleniumMethods.TestInstancePass);
            driver.FindElement(By.Id("next")).Click();
            Thread.Sleep(20000);

            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/a[4]/div[1]")).Click();//click productivity
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            
            Thread.Sleep(50000);

            driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[12]/table/tbody/tr/td/a/span")).Click();// click administration page 

        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Quit();
        }

        
    }
}

