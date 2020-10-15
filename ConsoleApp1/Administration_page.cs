using System;
using System.Linq;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using SetUp;

namespace Administration
{
    class Administration_page : Setup
    {
        [Test]
        public void Administration_functions()
        {
            Thread.Sleep(2000);

            Click(driver, driver.FindElement(By.XPath(Administration_path)));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            test = extent.CreateTest("Administration Functionality");

            string Delete_button = "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-180']/button";
            string CreateNode_button = "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-231']/button";

            string EditNode_button = "(//button[@class='button-element textsize-xlarge'])[4]";
            string Inital_node_path = "//span[contains(text(),'AutomationTest')]";
            string Edited_node_path = "//span[contains(text(),'AutomationTest1')]";
            string Edited_NestedNode_path = "//span[contains(text(),'NestedNode(Edited)')]";
            string Inital_name = "AutomationTest";
            string Edited_name = "AutomationTest1";
            string Confirm_Button = "//*[@id='confirmButtons']/a[1]";

            void Create_Node(string name, string path)
            {
                test.Log(Status.Info, "Creating node - " + name);
                try
                {
                    Click(driver, driver.FindElement(By.XPath(CreateNode_button)));
                    //Node name field
                    driver.FindElement(By.XPath("//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_navigationTooltip-230-popup_textbox-229']/table/tbody/tr/td/input")).Clear();
                    driver.FindElement(By.XPath("//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_navigationTooltip-230-popup_textbox-229']/table/tbody/tr/td/input")).SendKeys(name);
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//div[contains(text(),'Create node')]")).Click();
                    Thread.Sleep(10000);
                    //create Button
                    driver.FindElement(By.XPath("(//button[@class='button-element textsize-large'])[4]")).Click();

                    Thread.Sleep(10000);

                    if (Creation_Check(name, path))
                    {
                        test.Log(Status.Pass, name + " - Node Created");
                    }
                    else
                    {
                        test.Log(Status.Fail, name + " - Node Not Created");
                    }
                }
                catch (Exception e)
                {
                    test.Log(Status.Fail, name + " - Node Not Created " + e);
                }

            }

            void Edit_node(string name, string path, string Modifying_path)
            {
                IWebElement element = driver.FindElement(By.XPath(Modifying_path));
                test.Log(Status.Info, "Editing Node - " + element.Text);

                if (element.Displayed)
                {
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

                        if (Creation_Check(name, path))
                        {
                            test.Log(Status.Pass, name + " - Node Edited");
                        }
                        else
                        {
                            test.Log(Status.Fail, name + " - Node Editing Failed");
                        }
                    }
                    catch (Exception e)
                    {
                        test.Log(Status.Fail, name + " - Node Editing Failed " + e);
                    }

                }
            }

            void Nested_node()
            {
                driver.FindElement(By.XPath(Edited_node_path)).Click();

                for (int i = 0; i < 2; i++)
                {
                    string name = "NestedNode" + i;

                    Create_Node(name, "//span[contains(text(),'" + name + "')]");
                }

            }

            void Create_Customer(string name, string path, string Creation_path)
            {
                try
                {
                    test.Log(Status.Info, "Creating Customer - " + name);

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

                    if (Creation_Check(name, Creation_path))
                    {
                        test.Log(Status.Pass, name + " - Customer Created");
                    }
                    else
                    {
                        test.Log(Status.Fail, name + " - Customer Not Created");
                    }
                }
                catch (Exception e)
                {
                    test.Log(Status.Fail, name + "- Customer not Created - " + e);
                }
            }

            void Edit_Customer(string name, string path, string Modifying_path)
            {
                try
                {
                    IWebElement element = driver.FindElement(By.XPath(Modifying_path));
                    test.Log(Status.Info, "Editing Customer - " + element.Text);

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

                    if (Creation_Check(name, path))
                    {
                        test.Log(Status.Pass, name + " - customer Edited");
                        Delete_Customer(path, name);
                    }
                    else
                    {
                        test.Log(Status.Fail, name + " - customer Editing Failed");
                    }
                }
                catch (Exception e)
                {
                    test.Log(Status.Fail, name + " - customer Editing Failed " + e);
                }
            }

            void Delete_Customer(string path, string name)
            {
                try
                {
                    test.Log(Status.Info, "Deleting Node" + name);
                    //clicking the element to be deleted
                    driver.FindElement(By.XPath("(//td[@class='valuedisplay-text'])[14]")).Click();

                    //delete Button
                    driver.FindElement(By.XPath(Delete_button)).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath(Confirm_Button)).Click();
                    test.Log(Status.Pass, name + " - Customer Deleted");
                }
                catch (Exception e)
                {
                    test.Log(Status.Fail, name + " - Deleting Customer Failed " + e);
                }
            }

            void Delete_node(string path)
            {
                try
                {
                    Thread.Sleep(2000);
                    string name = driver.FindElement(By.XPath(path)).Text;
                    test.Log(Status.Info, "deleting Node - " + name);

                    driver.FindElement(By.XPath(path)).Click();

                    driver.FindElement(By.XPath(EditNode_button)).Click();
                    //Delete Icon
                    driver.FindElement(By.XPath("(//button[@class='button-element textsize-large'])[1]")).Click();
                    Thread.Sleep(2000);
                    //confirmation 
                    driver.FindElement(By.XPath(Confirm_Button)).Click();
                    test.Log(Status.Pass, name + " - node Deleted");
                }
                catch (Exception e)
                {
                    test.Log(Status.Fail, "Deleting node Failed - " + e);
                }
            }

            bool Creation_Check(string name, string path)
            {
                IWebElement node = driver.FindElement(By.XPath(path));
                if (name == node.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //Parent Node
            Create_Node(Inital_name, Inital_node_path);

            //Edit Parent Node
            Edit_node(Edited_name, Edited_node_path, Inital_node_path);

            //To create Multiple Nested Node
            Nested_node();

            //NestedNode Editing
            Edit_node("NestedNode(Edited)", Edited_NestedNode_path, "//span[contains(text(),'NestedNode0')]");

            //Customer at parentNode
            Create_Customer("Automation tester", Edited_node_path, "//div[contains(text(),'Automation tester')]");

            //Edit Parent Customer name
            Edit_Customer("Automation tester(Edited)", "//div[contains(text(),'Automation tester(Edited)')]", "//div[contains(text(),'Automation tester')]");

            //Customer at NestedNode
            Create_Customer("Automation Tester(Nested)", Edited_NestedNode_path, "//div[contains(text(),'Automation Tester(Nested)')]");

            //Edit Nested Customer name
            Edit_Customer("Automation Tester(Nested)(Edited)", "//div[contains(text(),'Automation Tester(Nested)(Edited)')]", "//div[contains(text(),'Automation Tester(Nested)')]");

            //Delete Nested node
            Delete_node(Edited_NestedNode_path);

            //Delete Parent Node
            Delete_node(Edited_node_path);
        }
    }
}
