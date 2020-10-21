using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using Automation.Test;
using OpenQA.Selenium.Firefox;

namespace CloudPages
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class Pages <TWebDriver> where TWebDriver : RemoteWebDriver, new()
    {

        private RemoteWebDriver driver;

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
        }


        [Test, Order(0)]
        public void Dashboard()
        { 

                Thread.Sleep(50000);

                //Sites           
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-15-bounding-box']/ptcs-label", "Sites", "Sites not found");
                //Sites Box
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_esabtreeselector-10']", "Sites Box", "Sites Box not found");

                //Machines          
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-49-bounding-box']/ptcs-label", "Machines", "Machines not found");
                //Machines Box
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_esabtreeselector-50']", "Machines Box", "Machines Box not found");

                //Time
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-52-bounding-box']/ptcs-label", "Time", "Time not found");
                //Time Box
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_esabtreeselector-145']", "Time Box", "Time Box not found");

                //Shifts
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-47-bounding-box']/ptcs-label", "Shifts", "Shifts not found");
                //Shifts Box
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_esabtreeselector-46']", "Shifts Box", "Shifts Box not found");

                //Update DashBoard Button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_button-21']/button", "Update DashBoard Button", "Update DashBoard Button not found");

                //Export as image
                SeleniumMethods.Element_check(driver, "//div[@id='root_pagemashupcontainer-69_screenshot-134']/button", "Export as image", "Export as image not found");
                //Export as PDF
                SeleniumMethods.Element_check(driver, "//div[@id='root_pagemashupcontainer-69_screenshot-135']/button", "Export as PDF", "Export as PDF not found");

                //Exclude inactive machines
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_checkbox-56']/label/span", "Exclude inactive machines", "Exclude inactive machines not found");
                //Exclude inactive machines Box
                SeleniumMethods.Element_check(driver, "//div[@id='root_pagemashupcontainer-69_checkbox-56']/label", "Exclude inactive machines Box", "Exclude inactive machines Box not found");

                //Help
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_button-136']/button/span[3]", "Help", "Help not found");

                //Arc Time Factor    
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_label-71']/span", "Arc Time Factor", "Arc Time Factor not found");
                //Total Arc Time (s)
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_label-73']/span", "Total Arc Time (s)", "Total Arc Time (s) not found");
                //Weld Sessions
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_label-90']/span", "Weld Sessions", "Weld Sessions not found");
                //Average Arc Time (s)
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_label-93']/span", "Average Arc Time (s)", "Average Arc Time (s) not found");
                //Total Wire Used
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_label-96']/span", "Total Wire Used", "Total Wire Used not found");

                void Chart_Categories()
                {
                    //Arc Time Factor 
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-108_label-16']/span", "Arc Time Factor", "Arc Time Factor not found");
                    //Total Wire Used (g)
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-110_label-16']/span", "Total Wire Used (g)", "Total Wire Used (g) not found");
                    //Net deposition rate (kg/h)
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-110_label-38']/span", "Net deposition rate (kg/h)", "Net deposition rate (kg/h) not found");
                    //Events
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-121_label-16']/span", "Events", "Events not found");
                    //Active Machines
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-111_label-16']/span", "Active Machines", "Active Machines not found");
                }

                Chart_Categories();

           
        }

        [Test, Order(1)]
        public void Reports()
        {

                //report page click
                SeleniumMethods.Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[2]/table/tbody/tr/td/a")));

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                string Productivity = "//*[@id='root_pagemashupcontainer-69_tabsv2-250']/div[1]/div[3]/div/div/div[1]/div/div";
                string Actively_Timeline = "//*[@id='root_pagemashupcontainer-69_tabsv2-250']/div[1]/div[3]/div/div/div[3]/div/div";
                string Filter = "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcsbutton-75-bounding-box']/ptcs-button";

                //Productivity
                SeleniumMethods.Check(driver, Productivity, "Productivity", "Productivity Text not found");
                //Actively Timeline
                SeleniumMethods.Check(driver, Actively_Timeline, "Activity timeline", "Activity timeline not found");
                //Help
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_button-382']/button/span[3]", "Help", "Help Text not found");

                void Productivity_parameters()
                {
                    if (driver.FindElement(By.XPath(Productivity)).Displayed)
                    {
                        //Template
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-151-bounding-box']/ptcs-label", "Template", "Template Text not found");

                        //Time span
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-38-bounding-box']/ptcs-label", "Time span", "Time span Text not found");
                        //Time span Box
                        SeleniumMethods.Element_check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabdaterange-152']/div/input", "Time span Box", "Time span Box not found");

                        //Graph Value
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-120-bounding-box']/ptcs-label", "Graph value", "Graph value Text not found");
                        //Graph Value Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-121']", "Graph Value Box", "Graph Value Box not found");

                        //Item to compare
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-123-bounding-box']/ptcs-label", "Items to compare", "Items to compare Text not found");
                        //Item to compare Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-124']", "Item to compare Box", "Item to compare Box not found");

                        //Generate Button
                        SeleniumMethods.Element_check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_button-51']/button", "Generate Button", "Generate Button not found");
                        //Save as Template Button
                        SeleniumMethods.Element_check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_button-118']/button/span[3]", "Save as Template Button", "Save as Template Button not found");
                        //Filter Button
                        SeleniumMethods.Element_check(driver, Filter, "Filter Button", "Filter Button not found");

                        Filter_parameters();

                    }
                }

                void Filter_parameters()
                {
                    if (driver.FindElement(By.XPath(Filter)).Displayed)
                    {
                        driver.FindElement(By.XPath(Filter)).Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                        //Site
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-134-bounding-box']/ptcs-label", "Site", "Site not found");
                        //site Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-135']", "site Box", "site Box not found");

                        //Shifts
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-136-bounding-box']/ptcs-label", "Shifts", "Shifts not found");
                        //Shifts Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-137']", "Shifts Box", "Shifts Box not found");

                        //Welding station
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-138-bounding-box']/ptcs-label", "Welding station", "Welding station not found");
                        //Welding station Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-139']", "Welding station Box", "Welding station Box not found");

                        //Welding process
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-140-bounding-box']/ptcs-label", "Welding process", "Welding process not found");
                        //Welding process Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-141']", "Welding process", "Welding process not found");

                        //Operators
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-142-bounding-box']/ptcs-label", "Operators", "Operators not found");
                        //Operators Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-143']", "Operators Box", "Operators Box not found");

                        //Wire type
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-144-bounding-box']/ptcs-label", "Wire type", "Wire type not found");
                        //Wire type Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-145']", "Wire type Box", "Wire type Box not found");

                        //Clear Filter Button
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_button-201']/button", "Clear Filter Button", "Clear Filter Button not found");
                    }
                }

                void Activity_timeline_parameters()
                {
                    if (driver.FindElement(By.XPath(Actively_Timeline)).Displayed)
                    {
                        SeleniumMethods.Click(driver, driver.FindElement(By.XPath(Actively_Timeline)));
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                        //sites
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_ptcslabel-15-bounding-box']/ptcs-label", "Sites", "Sites Text not found");
                        //sites Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_esabtreeselector-10']", "sites Box", "sites Box not found");

                        //machines
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_ptcslabel-49-bounding-box']/ptcs-label", "Machines", "Machines Text not found");
                        //machines Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_esabtreeselector-50']", "machines Box", "machines Box not found");

                        //Event category
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_ptcslabel-124-bounding-box']/ptcs-label", "Event category", "Event category Text not found");
                        //Event category Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_esabtreeselector-125']", "Event category Box", "Event category Box not found");

                        //date
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_ptcslabel-115-bounding-box']/ptcs-label", "Date", "Date Text not found");
                        //date Box
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_esabdaterange-137']", "date Box", "date Box not found");

                        //Include events
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_checkbox-122']/label/span", "Include events", "Include events not found");

                        //Generate Report Button
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_button-119']/button", "Generate Report Button", "Generate Report Button not found");


                    }
                }

                Productivity_parameters();
                Activity_timeline_parameters();
            
        }

        [Test, Order(2)]
        public void WeldSession()
        {

                string By_weld_station = "//*[@id='root_pagemashupcontainer-69_tabsv2-10']/div[1]/div[3]/div/div/div[1]/div/div";
                string By_operator = "//*[@id='root_pagemashupcontainer-69_tabsv2-10']/div[1]/div[3]/div/div/div[2]/div/div";
                string By_work_order = "//*[@id='root_pagemashupcontainer-69_tabsv2-10']/div[1]/div[3]/div/div/div[3]/div/div";
                string By_part_id = "//*[@id='root_pagemashupcontainer-69_tabsv2-10']/div[1]/div[3]/div/div/div[4]/div/div";
                string By_wire = "//*[@id='root_pagemashupcontainer-69_tabsv2-10']/div[1]/div[3]/div/div/div[5]/div/div";
                string By_wps = "//*[@id='root_pagemashupcontainer-69_tabsv2-10']/div[1]/div[3]/div/div/div[6]/div/div";
                string By_all_sessions = "//*[@id='root_pagemashupcontainer-69_tabsv2-10']/div[1]/div[3]/div/div/div[7]/div/div";
                string Title = "//*[@id='root_pagemashupcontainer-69_label-7']/span";
                string help = "//*[@id='root_pagemashupcontainer-69_button-84']/button/span[3]";
                string span_box = "//*[@id='root_pagemashupcontainer-69_esabdaterange-80']/div/input";
                string Filter_button = "//*[@id='root_pagemashupcontainer-69_ptcsbutton-75']";

                //click weld session
                SeleniumMethods.Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[3]/table/tbody/tr/td/a/span")));

                void Weld_session_parameters()
                {
                    SeleniumMethods.Check(driver, Title, "Weld Sessions", "Weld Sessions Text not found");
                    SeleniumMethods.Element_check(driver, Filter_button, "Filter Button", "Filter Button not found");
                    SeleniumMethods.Element_check(driver, span_box, "Span Box", "span not found");
                    SeleniumMethods.Check(driver, By_weld_station, "By welding station", "By welding station Text not found");
                    SeleniumMethods.Check(driver, By_operator, "By operator", "By operator Text not found");
                    SeleniumMethods.Check(driver, By_work_order, "By work order", "By work order Text not found");
                    SeleniumMethods.Check(driver, By_part_id, "By part ID", "By part ID Text not found");
                    SeleniumMethods.Check(driver, By_wire, "By wire", "By wire Text not found");
                    SeleniumMethods.Check(driver, By_wps, "By WPS", "By WPS Text not found");
                    SeleniumMethods.Check(driver, By_all_sessions, "All sessions", "All sessions Text not found");
                    SeleniumMethods.Check(driver, help, "Help", "Help Text not found");
                }
                void Field_parameters(string path)
                {
                    if (driver.FindElement(By.XPath(path)).Displayed)
                    {
                        driver.FindElement(By.XPath(path)).Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                        //search_box                 
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced-search-container']/div/div[2]/input", "Search Box", "Search Box not found");
                        //name                
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced']/div[1]/table/tbody/tr[2]/td[1]/div", "Name", "Name not found");
                        //arc time
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced']/div[1]/table/tbody/tr[2]/td[3]/div", "Arc time", " Arc time not found");

                        //wire consumed
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced']/div[1]/table/tbody/tr[2]/td[4]/div", "Wire Consumed", "Wire Consumed Text not found");
                        //weld sessions
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced']/div[1]/table/tbody/tr[2]/td[5]/div", "Weld Sessions", "Weld Sessions not found");
                        //last updated
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced']/div[1]/table/tbody/tr[2]/td[6]/div", "Last updated", "Last updated not found");
                    }
                }
                void All_Session_parameters()
                {
                    driver.FindElement(By.XPath(By_all_sessions)).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                    //weld sessions
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_label-18']/span", "Weld Sessions", " Weld Sessions Text not found");
                    //weld sessions search box
                    SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced-search-container']/div/div[2]/input", "weld sessions search box", "weld sessions search box not found");
                    //Machine name
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[1]/div", "Machine name", "Machine name not found");
                    //Machine type
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[2]/div", "Machine type", "Machine type not found");
                    //Created
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[3]/div", "Created", "Created not found");
                    //Arc time
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[4]/div", "Arc time", "Arc time not found");
                    //Session ID
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[5]/div", "Session ID", "Session ID not found");
                    //Avg A
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[6]/div", "Avg A", "Avg A not found");
                    //Avg V
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[9]/div", "Avg V", "Avg V not found");
                    //Avg P
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[12]/div", "Avg P", "Avg P not found");
                    //Avg Wire Speed
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[15]/div", "Avg Wire Speed", "Avg Wire Speed not found");
                }
                void filter_parameters()
                {
                    if (driver.FindElement(By.XPath(Filter_button)).Displayed)
                    {
                        //click filter button
                        driver.FindElement(By.XPath(Filter_button)).Click();
                        //Sites
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-38-bounding-box']/ptcs-label", "Sites", "Sites not found");
                        //Shifts
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-42-bounding-box']/ptcs-label", "Shifts", "Shifts not found");
                        //Others
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-48-bounding-box']/ptcs-label", "Others", "Others not found");
                    }

                }

                Weld_session_parameters();
                Field_parameters(By_weld_station);
                //Field_parameters(By_operator);
                //Field_parameters(By_work_order);
                //Field_parameters(By_part_id);
                //Field_parameters(By_wire);
                //Field_parameters(By_wps);
                All_Session_parameters();
                filter_parameters();
            
        }

        [Test, Order(3)]
        public void FleetManagement()
        {

                //fleet management click
                SeleniumMethods.Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[4]/table/tbody/tr/td/a/span")));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                string List_view = "//*[@id='root_pagemashupcontainer-69_tabsv2-3']/div[1]/div[3]/div/div/div[1]/div/div";
                string Map_View = "//*[@id='root_pagemashupcontainer-69_tabsv2-3']/div[1]/div[3]/div/div/div[2]/div/div";
                string Events = "//*[@id='root_pagemashupcontainer-69_tabsv2-3']/div[1]/div[3]/div/div/div[3]/div/div";
                string Activities = "//*[@id='root_pagemashupcontainer-69_tabsv2-3']/div[1]/div[3]/div/div/div[4]/div/div";
                string Software_Upgrade = "//*[@id='root_pagemashupcontainer-69_tabsv2-3']/div[1]/div[3]/div/div/div[5]/div/div";

                string Remote_upgrade = "//*[@id='root_pagemashupcontainer-69_mashupcontainer-40_tabsv2-3']/div[1]/div[3]/div/div/div[1]/div/div";
                string Manual_upgrade = "//*[@id='root_pagemashupcontainer-69_mashupcontainer-40_tabsv2-3']/div[1]/div[3]/div/div/div[2]/div/div";
                string Firmware_Versions = "//*[@id='root_pagemashupcontainer-69_mashupcontainer-40_tabsv2-3']/div[1]/div[3]/div/div/div[3]/div/div";

                void FleetManagement_Parameters()
                {
                    //List view
                    SeleniumMethods.Check(driver, List_view, "List view", "List view not found");
                    //Map View
                    SeleniumMethods.Check(driver, Map_View, "Map View", "Map View not found");
                    //Events
                    SeleniumMethods.Check(driver, Events, "Events", "Events not found");
                    //Activities
                    SeleniumMethods.Check(driver, Activities, "Activities", "Activities not found");
                    //Software Upgrade
                    SeleniumMethods.Check(driver, Software_Upgrade, "Software Upgrade", "Software Upgrade not found");
                }

                void Events_parameters()
                {
                    if (driver.FindElement(By.XPath(Events)).Displayed)
                    {
                        driver.FindElement(By.XPath(Events)).Click();

                        Thread.Sleep(2000);
                        //Machine name
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[1]/div", "Machine name", "Machine name not found");
                        //Machine type
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[2]/div", "Machine type", "Machine type not found");
                        //Location
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[3]/div", "Location", "Location not found");
                        //Event ID
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[4]/div", "Event ID", "Event ID not found");
                        //Event name
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[5]/div", "Event name", "Event name not found");
                        //Event description
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[6]/div", "Event description", "Event description not found");
                        //Session ID        
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[8]/div", "Session ID", "Session ID not found");
                        //Unit number
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[9]/div", "Unit number", "Unit number not found");
                        //Alert category
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[10]/div", "Alert category", "Alert category not found");
                        //Date/time
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[11]/div", "Date/time", "Date/time not found");
                    }
                }

                void Activities_parameters()
                {
                    if (driver.FindElement(By.XPath(Activities)).Displayed)
                    {
                        driver.FindElement(By.XPath(Activities)).Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                        //Modified
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[1]/div", "Modified", "Modified not found");
                        //Asset name
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[2]/div", "Asset name", "Asset name not found");
                        //Type
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[3]/div", "Type", "Type not found");
                        //Status
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[4]/div", "Status", "Status not found");
                        //User
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[5]/div", "User", "User not found");
                        //Creation date
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[6]/div", "Creation date", "Creation date not found");
                        //Reminder date
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[7]/div", "Reminder date", "Reminder date not found");
                    }
                }

                void SoftwareUpgrade_parameters()
                {
                    if (driver.FindElement(By.XPath(Software_Upgrade)).Displayed)
                    {
                        driver.FindElement(By.XPath(Software_Upgrade)).Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                        Thread.Sleep(2000);
                        //Remote upgrade
                        SeleniumMethods.Check(driver, Remote_upgrade, "Remote upgrade", "Remote upgrade not found");
                        //Manual upgrade
                        SeleniumMethods.Check(driver, Manual_upgrade, "Manual upgrade", "Manual upgrade not found");
                        //Firmware Versions
                        SeleniumMethods.Check(driver, Firmware_Versions, "Firmware Versions", "Firmware Versions not found");

                        //Parameters
                        Remoteupgrade_parameters();
                        Manualupgrade_parameters();
                        FirmwareVersions_parameters();

                    }

                }

                void Remoteupgrade_parameters()
                {
                    if (driver.FindElement(By.XPath(Remote_upgrade)).Displayed)
                    {
                        driver.FindElement(By.XPath(Remote_upgrade)).Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                        //remote updrage definition
                        SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-40_mashupcontainer-5_valuedisplay-15']/table/tbody/tr/td/div/div/span", "Process for remote firmware upgrade. Step 1: Pick the equipment you want to upgrade. Step 2: Press start upgrade. Step 3: await for the process to complete.", "remote updrage definition not found");
                        //Asset name         
                        SeleniumMethods.Check(driver, "//span[@id='column_AssetName']", "Asset name", "Asset name not found");
                        //Machine type
                        SeleniumMethods.Check(driver, "//span[@id='column_MachineType']", "Machine type", "Machine type not found");
                        //Current version
                        SeleniumMethods.Check(driver, "//span[@id='column_CurrentVersion']", "Current version", "Current version not found");
                        //Latest version 
                        SeleniumMethods.Check(driver, "//span[@id='column_LastVersion']", "Latest version", "Latest version not found");
                        //Start Upgrade Button  
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-40_mashupcontainer-5_button-10']/button", "Start Upgrade Button", "Start Upgrade Button not found");

                    }
                }

                void Manualupgrade_parameters()
                {
                    if (driver.FindElement(By.XPath(Manual_upgrade)).Displayed)
                    {
                        driver.FindElement(By.XPath(Manual_upgrade)).Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                        //ManualUpgrade definition
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-40_mashupcontainer-7_valuedisplay-7']/table/tbody/tr/td/div/div/div", "Here you can download the latest software upgrades for all your equipment. If you need guidance during the installation process, read the instructions for more information.", "ManualUpgrade definition not found");
                        //Machine type
                        SeleniumMethods.Check(driver, "//span[@id='column_machineType']", "Machine type", "Machine type not found");
                        //Firmware version
                        SeleniumMethods.Check(driver, "//span[@id='column_firmwareVersion']", "Firmware version", "Firmware version not found");
                        //Release date
                        SeleniumMethods.Check(driver, "//span[@id='column_releaseDate']", "Release date", "Release date not found");
                        //Instructions
                        SeleniumMethods.Check(driver, "//span[@id='column_instructions']", "Instructions", "Instructions not found");
                        //Firmware file
                        SeleniumMethods.Check(driver, "//span[@id='column_firmwareFile']", "Firmware file", "Firmware file not found");
                        //Firmware package
                        SeleniumMethods.Check(driver, "//span[@id='column_firmwarePackage']", "Firmware package", "Firmware package not found");
                        //File name
                        SeleniumMethods.Check(driver, "//span[@id='column_fileName']", "File name", "File name not found");
                        //Instructions
                        SeleniumMethods.Check(driver, "(//span[@id='column_instructions'])[2]", "Instructions", "Instructions not found");
                        //File
                        SeleniumMethods.Check(driver, "//span[@id='column_download']", "File", "File not found");
                        //Text
                        //Check(test, driver, "//div[contains(text(),'Are you having trouble downloading and upgrading? Contact our support on 1-800-3722-123 or visit ']", "Contact Support Text found", " Contact Support Text not found");
                        //Text Link
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-40_mashupcontainer-7_htmltextarea-12']/a", "Contact Support Link", "Contact Support Link not found");

                    }
                }

                void FirmwareVersions_parameters()
                {
                    if (driver.FindElement(By.XPath(Firmware_Versions)).Displayed)
                    {
                        driver.FindElement(By.XPath(Firmware_Versions)).Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                        //FirmwareVersions definition
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-40_mashupcontainer-9_valuedisplay-11']/div/table/tbody/tr/td/div", "Here you can manage firmware versions available for the equipment", "FirmwareVersions definition not found");
                        //Firmware type
                        SeleniumMethods.Check(driver, "//span[@id='column_FirmwareType']", "Firmware type", "Firmware type not found");
                        //Firmware version
                        SeleniumMethods.Check(driver, "//span[@id='column_DisplayName']", "Firmware version", "Firmware version not found");
                        //Compatible firmware versions
                        SeleniumMethods.Check(driver, "//span[@id='column_CompatibleFirmwareVersionString']", "Compatible firmware versions", "Compatible firmware versions not found");
                        //Firmware file
                        SeleniumMethods.Check(driver, "//span[@id='column_FirmwareFile']", "Firmware file", "Firmware file not found");
                        //Firmware package
                        SeleniumMethods.Check(driver, "//span[@id='column_FirmwarePackage']", "Firmware package", "Firmware package not found");
                        //Edit
                        SeleniumMethods.Check(driver, "//span[@id='column_edit']", "Edit", "Edit not found");
                        //Delete
                        SeleniumMethods.Check(driver, "//span[@id='column_delete']", "Delete", "Delete not found");
                        //Create new firmware Button
                        SeleniumMethods.Element_check(driver, "//span[contains(text(),'Create new firmware')]", "Create new firmware Button", "Create new firmware button not found");
                    }
                }

                FleetManagement_Parameters();
                Events_parameters();
                Activities_parameters();
                SoftwareUpgrade_parameters();
            
        }

        [Test, Order(4)]
        public void JobManagement()
        {

            /*     test = extent.CreateTest("Job Management");
                   Click(driver, driver.FindElement(By.XPath(JobManagement_path)));

                   string currentTab = driver.CurrentWindowHandle;
                   Thread.Sleep(100000);
                   driver.SwitchTo().Window(currentTab);

                    //Job management Heading
                    Check(test, driver,"", "Job management", "Job management Heading not found");
                    //Search Box
                    Element_check(test, driver,"//*[@id='input-43']", "Search Box", "Search Box not found");
                    //Jobs Heading
                    Check(test, driver,"//div[@id='job_main']/section/div/h2", "Jobs", "Jobs Heading not found");
                    //Machines & Stations
                    Element_check(test, driver,"//*[@id='treeview']/div[2]/div/div[1]/div", "Machines & Stations", "Machines & Stations not found");
                    //ESAB Node
                    Element_check(test, driver,"//*[@id='treeview']/div[2]/div/div[2]/div/div/div[2]", "ESAB Node", "ESAB Node not found");
                    //Refresh Icon
                    Element_check(test, driver,"//*[@id='jobs_tree']/div[3]/button", "Refresh Icon", "Refresh Icon not found");
                    //Machine Image
                    Element_check(test, driver,"//*[@id='job_main']/section/div[2]/div/div/img", "Machine Image", "Machine Image not found");
                    //Page Text
                    Check(test, driver,"//*[@id='job_main']/section/div[2]/div/div/p", "Select a machine from the tree view on the left side...", "Page Text not found"); 
                           */
        }

        [Test, Order(5)]
        public void AssetManagement()
        {

                //asset management click
                SeleniumMethods.Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[6]/table/tbody/tr/td/a/span")));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                //Asset management Heading
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-36']/div/table/tbody/tr/td/div", "Asset management", "Asset management heading not found");
                //Asset management Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-41']/div/table/tbody/tr/td/div", "Here you can manage your company structure, sites and assets.", "Asset management Text not found");

                //Organization structure Heading
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-56']/div/table/tbody/tr/td/div", "Organization structure", "Organization structure Heading not found");
                //Organization structure Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-219']/div/table/tbody/tr/td/div", "Click on items in the tree to filter the list.", "Organization structure Text not found");

                //Assets Heading
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-304']/div/table/tbody/tr/td/div", "Assets", "Assets Heading not found");

                //Assets Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-306']/div/table/tbody/tr/td/div", "The shown assets are based on the marked level in the tree structure.", "Assets Text not found");

                //Search Box
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_textbox-316']/table/tbody/tr/td", "Search Box", "Search Box not found");
                //Search Icon
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-318']/button", "Search Icon", "Search Icon not found");

                // Create asset Button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-324']/button", "Create asset Button", "Create asset Button not found");

                //ESAB node
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_tree-1']/div/table/tbody/tr[2]/td[2]", "ESAB node", "ESAB node not found");

                //Help
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-344']/button", "Help", "Help Menu not found");

                //Asset name
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-145']/div/table/tbody/tr/td/div", "Asset name", "Asset name Option not found");

                //Location/site
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-147']/div/table/tbody/tr/td/div", "Location/site", "Location/site Option not found");

                //Refersh button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-366']/button", "Refersh button", "Refersh button not found");
                //Edit site button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-222']/button", "Edit site button", "Edit site button not found");
                //Create site button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-231']/button", "Create site button", "Create site button not found");
                //Delete button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-180']/button", "Delete button", "Delete button not found");
                //Move button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-291']/button", "Move button", "Move button not found");
                //Start button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-258']/button", "Start button", "Start button not found");
                //Show Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-248']/div/table/tbody/tr/td/div", "Show", "Show Text not found");
            
        }

        [Test, Order(6)]
        public void UserManagement()
        {

                //usermanagement click
                SeleniumMethods.Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[7]/table/tbody/tr/td/a/span")));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                //User management Icon
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-40']/div/table/tbody/tr/td[2]/img", "User management Icon", "User management Icon not found");
                //User management Heading
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-36']/div/table/tbody/tr/td/div", "User management", "User management Heading not found");
                //User management Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-41']/div/table/tbody/tr/td/div", "Here you can add and edit your users.", "User management Text not found");

                //Organization structure Heading
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-56']/div/table/tbody/tr/td/div", "Organization structure", "Organization structure Heading not found");
                //Organization structure Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-57']/div/table/tbody/tr/td/div", "Click on items in the tree to filter the list.", "Organization structure Text not found");

                //Users Heading
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-285']/div/table/tbody/tr/td/div", "Users", "Users Heading not found");
                //Users Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-287']/div/table/tbody/tr/td/div", "The shown users are based on the marked level in the tree structure.", "Users Text not found");

                //Help Option
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-314']/button", "Help Option", "Help Option not found");

                //ESAB Node
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_tree-256']/div/table/tbody/tr[2]/td[2]/table/tbody/tr[1]", "ESAB Node", "ESAB Node not found");

                //Refresh Icon
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-319']/button/span[1]", "Refresh Icon", "Refresh Icon not found");

                //Search Box
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_textbox-295']/table/tbody/tr/td/input", "Search Box", "Search Box not found");
                //Search Icon
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-297']/button", "Search Icon", "Search Icon not found");

                //Create User Button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-305']/button", "Create User Button", "Create User Button not found");

                //User name
                SeleniumMethods.Check(driver, "//*[@id='column_userName']", "User name", "User name not found");
                //First Name
                SeleniumMethods.Check(driver, "//*[@id='column_FirstName']", "First Name", "First Name not found");
                //Last Name
                SeleniumMethods.Check(driver, "//*[@id='column_LastName']", "Last Name", "Last Name not found");
                //User Role
                SeleniumMethods.Check(driver, "//*[@id='column_UserGroupDisplay']", "User Role", "User Role not found");
                //Location/site
                SeleniumMethods.Check(driver, "//*[@id='column_RootNodeDisplay']", "Location/site", "Location/site not found");

                //Edit site Button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-263']/button", "Edit site Button", "Edit site Button not found");
                //Create site Button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-262']/button", "Create site Button", "Create site Button not found");
                //Delete Button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-180']/button", "Delete Button", "Delete Button not found");
                //Move Button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-274']/button", "Move Button", "Move Button not found");
                //Start Button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-232']/button", "Start Button", "Start Button not found");
                //Show Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-222']/div/table/tbody/tr/td/div", "Show", "Show Text not found");
            
        }

        [Test, Order(7)]
        public void ShiftMangement()
        {
            
                //click shift management
                SeleniumMethods.Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[8]/table/tbody/tr/td/a/span")));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                string NewShift_Button = "//*[@id='root_pagemashupcontainer-69_navigation-231']/button";

                //Shift Management Icon
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_valuedisplay-258']/div/table/tbody/tr/td[2]/img", "Shift Management Icon", "Shift Management Icon not found");
                //Shift Management Heading
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_label-153']/span", "Shift Management", "Shift Management not found");
                //Shift Management Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_label-154']/span", "With shift management you can add your shifts and working hours, to be able to calculate valuable data for your dashboards and reports.", "Shift Management Text not found");
                //Help Menu
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_button-264']/button/span[3]", "Help", "Help not found");

                //Select site
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_label-241']/span", "Select site", "Select site not found");
                //Select site Search Box
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_esabtreeselector-240']", "Select site Search Box", "Select site Search Box not found");

                //Shift name
                SeleniumMethods.Check(driver, "//*[@id='shiftviewer-header-day-0']", "Shift name", "Shift name not found");
                //Monday
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[2]", "Monday", "Monday not found");
                //Tuesday
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[3]", "Tuesday", "Tuesday not found");
                //Wednesday
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[4]", "Wednesday", "Wednesday not found");
                //Thursday
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[5]", "Thursday", "Thursday not found");
                //Friday
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[6]", "Friday", "Friday not found");
                //Saturday
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[7]", "Saturday", "Saturday not found");
                //Sunday
                SeleniumMethods.Check(driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[8]", "Sunday", "Sunday not found");
                //NewShift Button
                SeleniumMethods.Element_check(driver, NewShift_Button, "NewShift Button", "NewShift Button not found");
            
        }

        [Test, Order(8)]
        public void AlertsAndSubscriptions()
        {
                //click alerts and subscription
                SeleniumMethods.Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[9]/table/tbody/tr/td/a/span")));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                string New_Alert = "//*[@id='root_pagemashupcontainer-69_tabsv2-187']/div[1]/div[3]/div/div/div[1]/div/div";
                string New_subscription = "//*[@id='root_pagemashupcontainer-69_tabsv2-187']/div[1]/div[3]/div/div/div[2]/div/div";
                string Current_alerts_and_subscriptions = "//*[@id='root_pagemashupcontainer-69_tabsv2-187']/div[1]/div[3]/div/div/div[3]/div/div";

                void AlertsAndSubscriptions_paramters()
                {
                    //Alerts & subscriptions Icon
                    SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_valuedisplay-228']/div/table/tbody/tr/td[2]/img", "Alerts & subscriptions Icon", "Alerts & subscriptions Icon not found");
                    //Alerts & subscriptions Heading
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_label-156']/span", "Alerts & subscriptions", "Alerts & subscriptions Heading not found");
                    //Alerts & subscriptions Text
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_label-157']/span", "Here you can add new alerts and subscriptions as well as handle your current ones.", "Alerts & subscriptions Text not found");
                    //Help menu
                    SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_button-243']/button/span[3]", "Help", "Help menu not found");
                    //New alert
                    SeleniumMethods.Check(driver, New_Alert, "New alert", "New alert not found");
                    //New subscription
                    SeleniumMethods.Check(driver, New_subscription, "New subscription", "New subscription not found");
                    //Current alerts and subscriptions
                    SeleniumMethods.Check(driver, Current_alerts_and_subscriptions, "Current alerts and subscriptions", "Current alerts and subscriptions not found");
                }

                void NewAlert_parameters()
                {
                    if (driver.FindElement(By.XPath(New_Alert)).Displayed)
                    {
                        SeleniumMethods.Click(driver, driver.FindElement(By.XPath(New_Alert)));
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                        //Pick a category and severness Heading
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-7']/div/table/tbody/tr/td/div", "1. Pick a category and severness", "Pick a category and severness Heading not found");
                        //Pick a category and severness Text
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-8']/div/table/tbody/tr/td/div", "Pick one or more categories and severity levels that you are interested in receiving alerts from.", "Pick a category and severness Text not found");

                        //How would you like to get notified? Heading
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-22']/div/table/tbody/tr/td/div", "2. How would you like to get notified?", "How would you like to get notified? Heading not found");
                        //How would you like to get notified? Text
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-23']/div/table/tbody/tr/td/div", "Pick a way to get notified. you will receive an alert as soon as an event occurs.", "How would you like to get notified? Text not found");

                        //Alert categories
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-75']/div/table/tbody/tr/td/div", "Alert categories", "Alert categories not found");
                        //Alert categories Icon
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-96']/div/table/tbody/tr/td[2]/img", "Alert categories Icon", "Alert categories Icon not found");

                        //Site level 
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-76']/div/table/tbody/tr/td/div", "Site level", "Site level not found");

                        //Alert name
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-77']/div/table/tbody/tr/td/div", "Alert name", "Alert name not found");

                        //E-mail address 
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-78']/div/table/tbody/tr/td/div", "E-mail address", "E-mail address not found");

                        //Phone number
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-79']/div/table/tbody/tr/td/div", "Phone number", "Phone number not found");
                        //Phone number Icon
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-74']/div/table/tbody/tr/td[2]/img", "Phone number Icon", "Phone number Icon not found");

                        //Save Button
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_button-35']/button", "Save Button", "Save Button not found");

                    }
                }

                void New_subscription_parameters()
                {
                    if (driver.FindElement(By.XPath(New_subscription)).Displayed)
                    {
                        SeleniumMethods.Click(driver, driver.FindElement(By.XPath(New_subscription)));
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                        //Pick topic and enter in details 
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-18']/span", "1. Pick topic and enter in details", "Pick topic and enter in details not found");

                        //Report type
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-14']/span", "Report type", "Report type not found");

                        //Report template
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-15']/span", "Report template", "Report template not found");

                        //Sites included
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-16']/span", "Sites included", "Sites included not found");

                        //Shifts included
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-17']/span", "Shifts included", "Shifts included not found");

                        //Add subscription details
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-21']/span", "2. Add subscription details", "Add subscription details not found");

                        //Subscription frequency
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-24']/span", "Subscription frequency", "Subscription frequency not found");

                        //Subscription name
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-77']/span", "Subscription name", "Subscription name not found");

                        //Add contact information
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-23']/span", "3. Add contact information", "Add contact information not found");

                        //Email Addresses
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-73']/span", "Email Addresses", "Email Addresses not found");

                        //Save Button
                        SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_button-51']/button", "Save Button", "Save Button not found");

                    }
                }

                void Current_alerts_and_subscriptions_parameters()
                {
                    if (driver.FindElement(By.XPath(Current_alerts_and_subscriptions)).Displayed)
                    {
                        SeleniumMethods.Click(driver, driver.FindElement(By.XPath(Current_alerts_and_subscriptions)));
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                        //Alerts Heading
                        SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-237_valuedisplay-30']/div/table/tbody/tr/td/div", "Alerts", "Alerts Heading not found");
                        //Name               
                        SeleniumMethods.Check(driver, "//span[contains(text(),'Name')]", "Name", "Name not found");
                        //Alert category
                        SeleniumMethods.Check(driver, "//span[contains(text(),'Alert category')]", "Alert category", "Alert category not found");
                        //Way of contact
                        SeleniumMethods.Check(driver, "//span[contains(text(),'Way of contact')]", "Way of contact", "Way of contact not found");

                        //Subscriptions Heading
                        SeleniumMethods.Check(driver, "(//div[@class='novalue-container'])[30]", "Subscriptions", "Subscriptions Heading not found");
                        //Selected rows: 0
                        SeleniumMethods.Check(driver, "(//span[@class='advancedtable-selectedrowscount'])[1]", "Selected rows: 0", "Selected rows: 0 not found");
                        //Create Button
                        SeleniumMethods.Element_check(driver, "(//button[@class='button-element textsize-large'])[3]", "Create Button", "Create Button not found");

                    }
                }

                AlertsAndSubscriptions_paramters();
                NewAlert_parameters();
                New_subscription_parameters();
                Current_alerts_and_subscriptions_parameters();
            
        }

        [Test, Order(9)]
        public void ScanningList()
        {
                SeleniumMethods.Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[10]/table/tbody/tr/td/a/span")));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                //Scanning lists Icon
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_valuedisplay-335']/div/table/tbody/tr/td[2]/img", "Scanning lists Icon", "Scanning lists Icon not found");
                //Scanning lists Heading
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_label-336']/span", "Scanning lists", "Scanning lists Heading not found");
                //Scanning lists Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_valuedisplay-357']/div/table/tbody/tr/td/div", "The scanning lists are used by the ESAB Connect App to detect what has been scanned. The configuration is sent to the power sources and include lists of materials and operators.", "Scanning lists Text not found");
                //Help Menu
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_button-358']/button/span[3]", "Help", "Help not found");
                //Create List Button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_button-348']/button", "Create List Button", "Create List Button not found");
                //Name
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-328_gridadvanced-319-grid-advanced']/div[1]/table/tbody/tr[2]/td[1]/div", "Name", "Name not found");
                //Last modified
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-328_gridadvanced-319-grid-advanced']/div[1]/table/tbody/tr[2]/td[2]/div", "Last modified", "Last modified not found");
                //Created by
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-328_gridadvanced-319-grid-advanced']/div[1]/table/tbody/tr[2]/td[3]/div", "Created by", "Created by not found");
                //Location
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-328_gridadvanced-319-grid-advanced']/div[1]/table/tbody/tr[2]/td[4]/div", "Location", "Location not found");
                //Details
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-328_gridadvanced-319-grid-advanced']/div[1]/table/tbody/tr[2]/td[5]/div", "Details", "Details not found");
            
        }

        [Test, Order(10)]
        public void LicenceManagement()
        {
            /* test = extent.CreateTest("Licence Management");

                 Click(driver, driver.FindElement(By.XPath(LicenceManagement_path)));
                 driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                 //Licence Management Heading
                 Check(test, driver,"//*[@id='licence_main']/section/div[1]/h2", "Licence Management", "Licence Management Heading not found");
                 //Search Option
                 Element_check(test, driver,"//*[@id='treeview']/div[1]/div/div[1]", "Search Option", "Search Option not found");
                 //User licencing Heading
                 Check(test, driver,"//*[@id='licence_main']/section/div[2]/div/h1", "User licencing", "User licencing Heading not found");
                 //User licencing Text 1
                 Check(test, driver,"//*[@id='licence_main']/section/div[2]/div/p/text()[1]", "In this section you can manage WeldCloud, CutCloud, Notes and Motion licences for existing users.", "licencing Text 1 not found");
                 //User licencing Text 2
                 Check(test, driver,"//*[@id='licence_main']/section/div[2]/div/p/text()[2]", "You can also create new Nodes, Customers, Sites and Users.", "licencing Text 2 not found");
                 //Organization Node
                 Element_check(test, driver,"//*[@id='treeview']/div[2]/div/div[1]/div", "Organization Node","Organization Node not found");
                 //ESAB Node
                 Element_check(test, driver, "//*[@id='treeview']/div[2]/div/div[2]/div/div/div[2]", "ESAB Node", "ESAB Node not found");
                 //Refresh Icon
                 Element_check(test, driver,"//*[@id='organisation_tree']/div[3]/button", "Refresh Icon", "Refresh Icon not found"); 
                 */
        }

        [Test, Order(11)]
        public void Administration()
        {          

            SeleniumMethods.Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[12]/table/tbody/tr/td/a/span")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            string Delete_button = "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-180']/button";
            string CreateNode_button = "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-231']/button";

            void Default_parameters()
            {
                //Adminstration Icon
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-40']/div/table/tbody/tr/td[2]/img", "Adminstration Icon", "Adminstration Icon not found");
                //Administration Heading
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-36']/div/table/tbody/tr/td/div", "Administration", "Administration Heading not found");
                //Organization structure Heading
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-56']/div/table/tbody/tr/td/div", "Organization structure", "Organization structure Heading not found");
                //Organization structure Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-219']/div/table/tbody/tr/td/div", "Click on items in the tree to filter the list.", "Organization structure Text not found");
                //Customers Heading
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-299']/div/table/tbody/tr/td/div", "Customers", "Customers Heading not found");
                //Customers Text
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-301']/div/table/tbody/tr/td/div", "The shown assets are based on the marked level in the tree structure.", "Customers Text not found");
                //Help Menu
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-324']/button/span[3]", "Help", "Help Menu not found");
                //Search Box
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_textbox-311']/table/tbody/tr/td/input", "Search Box", "Search Box not found");
                //Search Icon
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-313']/button", "Search Icon", "Search Icon not found");
                //Create Customer Button
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-319']/button", "Create Customer Button", "Create Customer Button not found");
                //ESAB Node
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_tree-1']/div/table/tbody/tr[2]/td[2]/table/tbody/tr[1]", "ESAB Node", "ESAB Node not found");
                //Refresh Icon
                SeleniumMethods.Element_check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-362']/button", "Refresh Icon", "Refresh Icon not found");
                //Create Node Button
                SeleniumMethods.Element_check(driver, CreateNode_button, "Create Node Button", "Create Node Button not found");
                //Delete Button
                SeleniumMethods.Element_check(driver, Delete_button, "Delete Button", "Delete Button not found");
                //Customer name
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-145']/div/table/tbody/tr/td/div", "Customer name", "Customer name not found");
                //Location/site
                SeleniumMethods.Check(driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-147']/div/table/tbody/tr/td/div", "Location/site", "Location/site not found");
            }
            Default_parameters();
            
        }

        //Check(test, driver, , "", "not found");
        //Element_check(test, driver,,""," not found");

        [OneTimeTearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}
