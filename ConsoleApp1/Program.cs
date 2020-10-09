using System;
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
using SetUp;

namespace CloudPages
{
    public class Pages : Setup
    {
        
        [Test, Order(0)]
        public void Dashboard()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
            test = extent.CreateTest("Dashboard");
            Thread.Sleep(20000);

            //Sites           
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-15-bounding-box']/ptcs-label", "Sites", "Sites not found");
            //Sites Box
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_esabtreeselector-10']", "Sites Box", "Sites Box not found");

            //Machines          
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-49-bounding-box']/ptcs-label", "Machines", "Machines not found");
            //Machines Box
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_esabtreeselector-50']", "Machines Box", "Machines Box not found");

            //Time
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-52-bounding-box']/ptcs-label", "Time", "Time not found");
            //Time Box
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_esabtreeselector-145']", "Time Box", "Time Box not found");

            //Shifts
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-47-bounding-box']/ptcs-label", "Shifts", "Shifts not found");
            //Shifts Box
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_esabtreeselector-46']", "Shifts Box", "Shifts Box not found");

            //Update DashBoard Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_button-21']/button", "Update DashBoard Button", "Update DashBoard Button not found");

            //Export as image
            Element_check(test, driver, "//div[@id='root_pagemashupcontainer-69_screenshot-134']/button", "Export as image", "Export as image not found");
            //Export as PDF
            Element_check(test, driver, "//div[@id='root_pagemashupcontainer-69_screenshot-135']/button", "Export as PDF", "Export as PDF not found");

            //Exclude inactive machines
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_checkbox-56']/label/span", "Exclude inactive machines", "Exclude inactive machines not found");
            //Exclude inactive machines Box
            Element_check(test, driver, "//div[@id='root_pagemashupcontainer-69_checkbox-56']/label", "Exclude inactive machines Box", "Exclude inactive machines Box not found");

            //Help
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_button-136']/button/span[3]", "Help", "Help not found");

            //Arc Time Factor    
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_label-71']/span", "Arc Time Factor", "Arc Time Factor not found");
            //Total Arc Time (s)
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_label-73']/span", "Total Arc Time (s)", "Total Arc Time (s) not found");
            //Weld Sessions
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_label-90']/span", "Weld Sessions", "Weld Sessions not found");
            //Average Arc Time (s)
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_label-93']/span", "Average Arc Time (s)", "Average Arc Time (s) not found");
            //Total Wire Used
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_label-96']/span", "Total Wire Used", "Total Wire Used not found");

            void Chart_Categories()
            {
                test.Log(Status.Info, " Chart Categories");

                //Arc Time Factor 
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-108_label-16']/span", "Arc Time Factor", "Arc Time Factor not found");
                //Total Wire Used (g)
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-110_label-16']/span", "Total Wire Used (g)", "Total Wire Used (g) not found");
                //Net deposition rate (kg/h)
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-110_label-38']/span", "Net deposition rate (kg/h)", "Net deposition rate (kg/h) not found");
                //Events
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-121_label-16']/span", "Events", "Events not found");
                //Active Machines
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-111_label-16']/span", "Active Machines", "Active Machines not found");
            }

            Chart_Categories();
        }

        [Test, Order(1)]
        public void Reports()
        {
            test = extent.CreateTest("Report Page");
            //Reports
            Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[2]/table/tbody/tr/td/a")));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            string Productivity = "//*[@id='root_pagemashupcontainer-69_tabsv2-250']/div[1]/div[3]/div/div/div[1]/div/div";
            string Actively_Timeline = "//*[@id='root_pagemashupcontainer-69_tabsv2-250']/div[1]/div[3]/div/div/div[3]/div/div";
            string Filter = "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcsbutton-75-bounding-box']/ptcs-button";

            //Productivity
            Check(test, driver, Productivity, "Productivity", "Productivity Text not found");
            //Actively Timeline
            Check(test, driver, Actively_Timeline, "Activity timeline", "Activity timeline not found");
            //Help
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_button-382']/button/span[3]", "Help", "Help Text not found");

            void Productivity_parameters()
            {
                if (driver.FindElement(By.XPath(Productivity)).Displayed)
                {
                    test.Log(Status.Info, "Productivity page");
                    //Template
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-151-bounding-box']/ptcs-label", "Template", "Template Text not found");

                    //Time span
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-38-bounding-box']/ptcs-label", "Time span", "Time span Text not found");
                    //Time span Box
                    Element_check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabdaterange-152']/div/input", "Time span Box", "Time span Box not found");

                    //Graph Value
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-120-bounding-box']/ptcs-label", "Graph value", "Graph value Text not found");
                    //Graph Value Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-121']", "Graph Value Box", "Graph Value Box not found");

                    //Item to compare
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-123-bounding-box']/ptcs-label", "Items to compare", "Items to compare Text not found");
                    //Item to compare Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-124']", "Item to compare Box", "Item to compare Box not found");

                    //Generate Button
                    Element_check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_button-51']/button", "Generate Button", "Generate Button not found");
                    //Save as Template Button
                    Element_check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_button-118']/button/span[3]", "Save as Template Button", "Save as Template Button not found");
                    //Filter Button
                    Element_check(test, driver, Filter, "Filter Button", "Filter Button not found");

                    Filter_parameters();

                }
            }

            void Filter_parameters()
            {
                if (driver.FindElement(By.XPath(Filter)).Displayed)
                {
                    driver.FindElement(By.XPath(Filter)).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                    test.Log(Status.Info, "Productivity page - Filter Parameters");

                    //Site
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-134-bounding-box']/ptcs-label", "Site", "Site not found");
                    //site Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-135']", "site Box", "site Box not found");

                    //Shifts
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-136-bounding-box']/ptcs-label", "Shifts", "Shifts not found");
                    //Shifts Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-137']", "Shifts Box", "Shifts Box not found");

                    //Welding station
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-138-bounding-box']/ptcs-label", "Welding station", "Welding station not found");
                    //Welding station Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-139']", "Welding station Box", "Welding station Box not found");

                    //Welding process
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-140-bounding-box']/ptcs-label", "Welding process", "Welding process not found");
                    //Welding process Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-141']", "Welding process", "Welding process not found");

                    //Operators
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-142-bounding-box']/ptcs-label", "Operators", "Operators not found");
                    //Operators Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-143']", "Operators Box", "Operators Box not found");

                    //Wire type
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-336_ptcslabel-144-bounding-box']/ptcs-label", "Wire type", "Wire type not found");
                    //Wire type Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_esabtreeselector-145']", "Wire type Box", "Wire type Box not found");

                    //Clear Filter Button
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-336_button-201']/button", "Clear Filter Button", "Clear Filter Button not found");
                }
            }

            void Activity_timeline_parameters()
            {
                if (driver.FindElement(By.XPath(Actively_Timeline)).Displayed)
                {
                    test.Log(Status.Info, "Actively TimeLine page");
                    Click(driver, driver.FindElement(By.XPath(Actively_Timeline)));
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                    //sites
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_ptcslabel-15-bounding-box']/ptcs-label", "Sites", "Sites Text not found");
                    //sites Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_esabtreeselector-10']", "sites Box", "sites Box not found");

                    //machines
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_ptcslabel-49-bounding-box']/ptcs-label", "Machines", "Machines Text not found");
                    //machines Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_esabtreeselector-50']", "machines Box", "machines Box not found");

                    //Event category
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_ptcslabel-124-bounding-box']/ptcs-label", "Event category", "Event category Text not found");
                    //Event category Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_esabtreeselector-125']", "Event category Box", "Event category Box not found");

                    //date
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_ptcslabel-115-bounding-box']/ptcs-label", "Date", "Date Text not found");
                    //date Box
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_esabdaterange-137']", "date Box", "date Box not found");

                    //Include events
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_checkbox-122']/label/span", "Include events", "Include events not found");

                    //Generate Report Button
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-368_mashupcontainer-26_button-119']/button", "Generate Report Button", "Generate Report Button not found");


                }
            }

            Productivity_parameters();
            Activity_timeline_parameters();
        }

        [Test, Order(2)]
        public void WeldSession()
        {
            test = extent.CreateTest("Weld Session");

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
            Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[3]/table/tbody/tr/td/a/span")));

            void Weld_session_parameters()
            {
                test.Log(Status.Info, "WeldSession parameters");
                Check(test, driver, Title, "Weld Sessions", "Weld Sessions Text not found");
                Element_check(test, driver, Filter_button, "Filter Button", "Filter Button not found");
                Element_check(test, driver, span_box, "Span Box", "span not found");
                Check(test, driver, By_weld_station, "By welding station", "By welding station Text not found");
                Check(test, driver, By_operator, "By operator", "By operator Text not found");
                Check(test, driver, By_work_order, "By work order", "By work order Text not found");
                Check(test, driver, By_part_id, "By part ID", "By part ID Text not found");
                Check(test, driver, By_wire, "By wire", "By wire Text not found");
                Check(test, driver, By_wps, "By WPS", "By WPS Text not found");
                Check(test, driver, By_all_sessions, "All sessions", "All sessions Text not found");
                Check(test, driver, help, "Help", "Help Text not found");
            }
            void Field_parameters(string path)
            {
                if (driver.FindElement(By.XPath(path)).Displayed)
                {
                    driver.FindElement(By.XPath(path)).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    test.Log(Status.Info, "Field parameters");
                    //search_box                 
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced-search-container']/div/div[2]/input", "Search Box", "Search Box not found");
                    //name                
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced']/div[1]/table/tbody/tr[2]/td[1]/div", "Name", "Name not found");
                    //arc time
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced']/div[1]/table/tbody/tr[2]/td[3]/div", "Arc time", " Arc time not found");

                    //wire consumed
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced']/div[1]/table/tbody/tr[2]/td[4]/div", "Wire Consumed", "Wire Consumed Text not found");
                    //weld sessions
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced']/div[1]/table/tbody/tr[2]/td[5]/div", "Weld Sessions", "Weld Sessions not found");
                    //last updated
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-62_gridadvanced-2-grid-advanced']/div[1]/table/tbody/tr[2]/td[6]/div", "Last updated", "Last updated not found");
                }
            }
            void All_Session_parameters()
            {
                driver.FindElement(By.XPath(By_all_sessions)).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
                test.Log(Status.Info, "AllSession parameters");
                //weld sessions
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_label-18']/span", "Weld Sessions", " Weld Sessions Text not found");
                //weld sessions search box
                Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced-search-container']/div/div[2]/input", "weld sessions search box", "weld sessions search box not found");
                //Machine name
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[1]/div", "Machine name", "Machine name not found");
                //Machine type
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[2]/div", "Machine type", "Machine type not found");
                //Created
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[3]/div", "Created", "Created not found");
                //Arc time
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[4]/div", "Arc time", "Arc time not found");
                //Session ID
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[5]/div", "Session ID", "Session ID not found");
                //Avg A
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[6]/div", "Avg A", "Avg A not found");
                //Avg V
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[9]/div", "Avg V", "Avg V not found");
                //Avg P
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[12]/div", "Avg P", "Avg P not found");
                //Avg Wire Speed
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-79_gridadvanced-3-grid-advanced']/div[1]/table/tbody/tr[2]/td[15]/div", "Avg Wire Speed", "Avg Wire Speed not found");
            }
            void filter_parameters()
            {
                if (driver.FindElement(By.XPath(Filter_button)).Displayed)
                {
                    test.Log(Status.Info, "Filter parameters");
                    //click filter button
                    driver.FindElement(By.XPath(Filter_button)).Click();
                    //Sites
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-38-bounding-box']/ptcs-label", "Sites", "Sites not found");
                    //Shifts
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-42-bounding-box']/ptcs-label", "Shifts", "Shifts not found");
                    //Others
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_ptcslabel-48-bounding-box']/ptcs-label", "Others", "Others not found");
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
            Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[4]/table/tbody/tr/td/a/span")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            test = extent.CreateTest("Fleet Management");

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
                test.Log(Status.Info, "FleetManagement Parameters");
                //List view
                Check(test, driver, List_view, "List view", "List view not found");
                //Map View
                Check(test, driver, Map_View, "Map View", "Map View not found");
                //Events
                Check(test, driver, Events, "Events", "Events not found");
                //Activities
                Check(test, driver, Activities, "Activities", "Activities not found");
                //Software Upgrade
                Check(test, driver, Software_Upgrade, "Software Upgrade", "Software Upgrade not found");
            }

            void Events_parameters()
            {
                if (driver.FindElement(By.XPath(Events)).Displayed)
                {
                    driver.FindElement(By.XPath(Events)).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
                    test.Log(Status.Info, "Event Parameters");
                    //Machine name
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[1]/div", "Machine name", "Machine name not found");
                    //Machine type
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[2]/div", "Machine type", "Machine type not found");
                    //Location
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[3]/div", "Location", "Location not found");
                    //Event ID
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[4]/div", "Event ID", "Event ID not found");
                    //Event name
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[5]/div", "Event name", "Event name not found");
                    //Event description
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[6]/div", "Event description", "Event description not found");
                    //Session ID        
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[8]/div", "Session ID", "Session ID not found");
                    //Unit number
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[9]/div", "Unit number", "Unit number not found");
                    //Alert category
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[10]/div", "Alert category", "Alert category not found");
                    //Date/time
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-9_gridadvanced-9-grid-advanced']/div[1]/table/tbody/tr[2]/td[11]/div", "Date/time", "Date/time not found");
                }
            }

            void Activities_parameters()
            {
                if (driver.FindElement(By.XPath(Activities)).Displayed)
                {
                    driver.FindElement(By.XPath(Activities)).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
                    test.Log(Status.Info, "Event Parameters");
                    //Modified
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[1]/div", "Modified", "Modified not found");
                    //Asset name
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[2]/div", "Asset name", "Asset name not found");
                    //Type
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[3]/div", "Type", "Type not found");
                    //Status
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[4]/div", "Status", "Status not found");
                    //User
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[5]/div", "User", "User not found");
                    //Creation date
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[6]/div", "Creation date", "Creation date not found");
                    //Reminder date
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-43_gridadvanced-5-grid-advanced']/div[1]/table/tbody/tr[2]/td[7]/div", "Reminder date", "Reminder date not found");
                }
            }

            void SoftwareUpgrade_parameters()
            {
                if (driver.FindElement(By.XPath(Software_Upgrade)).Displayed)
                {
                    driver.FindElement(By.XPath(Software_Upgrade)).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
                    test.Log(Status.Info, "SoftwareUpgrade Parameters");
                    //Remote upgrade
                    Check(test, driver, Remote_upgrade, "Remote upgrade", "Remote upgrade not found");
                    //Manual upgrade
                    Check(test, driver, Manual_upgrade, "Manual upgrade", "Manual upgrade not found");
                    //Firmware Versions
                    Check(test, driver, Firmware_Versions, "Firmware Versions", "Firmware Versions not found");

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
                    test.Log(Status.Info, "RemoteUpgrade Parameters");

                    //remote updrage definition
                    Check(test, driver, "//div[@id='root_pagemashupcontainer-69_mashupcontainer-40_mashupcontainer-5_valuedisplay-15']/table/tbody/tr/td/div/div/span", "Process for remote firmware upgrade. Step 1: Pick the equipment you want to upgrade. Step 2: Press start upgrade. Step 3: await for the process to complete.", "remote updrage definition not found");
                    //Asset name         
                     Check(test, driver, "//span[@id='column_AssetName']", "Asset name", "Asset name not found");
                     //Machine type
                     Check(test, driver, "//span[@id='column_MachineType']", "Machine type", "Machine type not found");
                     //Current version
                     Check(test, driver, "//span[@id='column_CurrentVersion']", "Current version", "Current version not found");
                     //Latest version 
                    Check(test, driver, "//span[@id='column_LastVersion']", "Latest version", "Latest version not found");
                     //Start Upgrade Button  
                    Element_check(test, driver,"//*[@id='root_pagemashupcontainer-69_mashupcontainer-40_mashupcontainer-5_button-10']/button", "Start Upgrade Button", "Start Upgrade Button not found");

                }
            }

            void Manualupgrade_parameters()
            {
                if (driver.FindElement(By.XPath(Manual_upgrade)).Displayed)
                {
                    driver.FindElement(By.XPath(Manual_upgrade)).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
                    test.Log(Status.Info, "ManualUpgrade Parameters");

                    //ManualUpgrade definition
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-40_mashupcontainer-7_valuedisplay-7']/table/tbody/tr/td/div/div/div", "Here you can download the latest software upgrades for all your equipment. If you need guidance during the installation process, read the instructions for more information.", "ManualUpgrade definition not found");
                    //Machine type
                    Check(test, driver, "//span[@id='column_machineType']", "Machine type", "Machine type not found");
                    //Firmware version
                    Check(test, driver, "//span[@id='column_firmwareVersion']", "Firmware version", "Firmware version not found");
                    //Release date
                    Check(test, driver, "//span[@id='column_releaseDate']", "Release date", "Release date not found");
                    //Instructions
                    Check(test, driver, "//span[@id='column_instructions']", "Instructions", "Instructions not found");
                    //Firmware file
                    Check(test, driver, "//span[@id='column_firmwareFile']", "Firmware file", "Firmware file not found");
                    //Firmware package
                    Check(test, driver, "//span[@id='column_firmwarePackage']", "Firmware package", "Firmware package not found");
                    //File name
                    Check(test, driver, "//span[@id='column_fileName']", "File name", "File name not found");
                    //Instructions
                    Check(test, driver, "(//span[@id='column_instructions'])[2]", "Instructions", "Instructions not found");
                    //File
                    Check(test, driver, "//span[@id='column_download']", "File", "File not found");
                    //Text
                    Check(test, driver, "//div[contains(text(),'Are you having trouble downloading and upgrading? Contact our support on 1-800-3722-123 or visit ']", "Contact Support Text found", " Contact Support Text not found");
                    //Text Link
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-40_mashupcontainer-7_htmltextarea-12']/a", "Contact Support Link", "Contact Support Link not found");

                }
            }

            void FirmwareVersions_parameters()
            {
                if (driver.FindElement(By.XPath(Firmware_Versions)).Displayed)
                {
                    driver.FindElement(By.XPath(Firmware_Versions)).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
                    test.Log(Status.Info, "FirmwareVersions Parameters");

                    //FirmwareVersions definition
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-40_mashupcontainer-9_valuedisplay-11']/div/table/tbody/tr/td/div", "Here you can manage firmware versions available for the equipment", "FirmwareVersions definition not found");
                    //Firmware type
                    Check(test, driver, "//span[@id='column_FirmwareType']", "Firmware type", "Firmware type not found");
                    //Firmware version
                    Check(test, driver, "//span[@id='column_DisplayName']", "Firmware version", "Firmware version not found");
                    //Compatible firmware versions
                    Check(test, driver, "//span[@id='column_CompatibleFirmwareVersionString']", "Compatible firmware versions", "Compatible firmware versions not found");
                    //Firmware file
                    Check(test, driver, "//span[@id='column_FirmwareFile']", "Firmware file", "Firmware file not found");
                    //Firmware package
                    Check(test, driver, "//span[@id='column_FirmwarePackage']", "Firmware package", "Firmware package not found");
                    //Edit
                    Check(test, driver, "//span[@id='column_edit']", "Edit", "Edit not found");
                    //Delete
                    Check(test, driver, "//span[@id='column_delete']", "Delete", "Delete not found");
                    //Create new firmware Button
                    Element_check(test, driver, "//span[contains(text(),'Create new firmware')]", "Create new firmware Button", "Create new firmware button not found");
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
            /*   test = extent.CreateTest("Job Management");
               Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[5]/table/tbody/tr/td/a/span")));
               //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
               Thread.Sleep(200000);

               //Job management Heading
               Check(test, driver,"//*[@id='job_main']/section/div[1]/h2", "Job management", "Job management Heading not found");
               //Search Box
               Element_check(test, driver,"//*[@id='input-43']", "Search Box", "Search Box not found");
               //Jobs Heading
               Check(test, driver,"//*[@id='job_main']/section/div[2]/div/h2", "Jobs", "Jobs Heading not found");
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
            test = extent.CreateTest("Asset Management");
            Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[6]/table/tbody/tr/td/a/span")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            //Asset management Heading
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-36']/div/table/tbody/tr/td/div", "Asset management", "Asset management heading not found");
            //Asset management Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-41']/div/table/tbody/tr/td/div", "Here you can manage your company structure, sites and assets.", "Asset management Text not found");

            //Organization structure Heading
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-56']/div/table/tbody/tr/td/div", "Organization structure", "Organization structure Heading not found");
            //Organization structure Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-219']/div/table/tbody/tr/td/div", "Click on items in the tree to filter the list.", "Organization structure Text not found");

            //Assets Heading
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-304']/div/table/tbody/tr/td/div", "Assets", "Assets Heading not found");

            //Assets Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-306']/div/table/tbody/tr/td/div", "The shown assets are based on the marked level in the tree structure.", "Assets Text not found");

            //Search Box
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_textbox-316']/table/tbody/tr/td", "Search Box", "Search Box not found");
            //Search Icon
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-318']/button", "Search Icon", "Search Icon not found");

            // Create asset Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-324']/button", "Create asset Button", "Create asset Button not found");

            //ESAB node
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_tree-1']/div/table/tbody/tr[2]/td[2]", "ESAB node", "ESAB node not found");

            //Help
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-344']/button", "Help", "Help Menu not found");

            //Asset name
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-145']/div/table/tbody/tr/td/div", "Asset name", "Asset name Option not found");

            //Location/site
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-147']/div/table/tbody/tr/td/div", "Location/site", "Location/site Option not found");

            //Refersh button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-366']/button", "Refersh button", "Refersh button not found");
            //Edit site button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-222']/button", "Edit site button", "Edit site button not found");
            //Create site button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-231']/button", "Create site button", "Create site button not found");
            //Delete button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-180']/button", "Delete button", "Delete button not found");
            //Move button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-291']/button", "Move button", "Move button not found");
            //Start button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-258']/button", "Start button", "Start button not found");
            //Show Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-248']/div/table/tbody/tr/td/div", "Show", "Show Text not found");

        }

        [Test, Order(6)]
        public void UserManagement()
        {
            test = extent.CreateTest("User Management");

            Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[7]/table/tbody/tr/td/a/span")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            //User management Icon
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-40']/div/table/tbody/tr/td[2]/img", "User management Icon", "User management Icon not found");
            //User management Heading
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-36']/div/table/tbody/tr/td/div", "User management", "User management Heading not found");
            //User management Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-41']/div/table/tbody/tr/td/div", "Here you can add and edit your users.", "User management Text not found");

            //Organization structure Heading
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-56']/div/table/tbody/tr/td/div", "Organization structure", "Organization structure Heading not found");
            //Organization structure Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-57']/div/table/tbody/tr/td/div", "Click on items in the tree to filter the list.", "Organization structure Text not found");

            //Users Heading
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-285']/div/table/tbody/tr/td/div", "Users", "Users Heading not found");
            //Users Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-287']/div/table/tbody/tr/td/div", "The shown users are based on the marked level in the tree structure.", "Users Text not found");

            //Help Option
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-314']/button", "Help Option", "Help Option not found");

            //ESAB Node
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_tree-256']/div/table/tbody/tr[2]/td[2]/table/tbody/tr[1]", "ESAB Node", "ESAB Node not found");

            //Refresh Icon
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-319']/button/span[1]", "Refresh Icon", "Refresh Icon not found");

            //Search Box
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_textbox-295']/table/tbody/tr/td/input", "Search Box", "Search Box not found");
            //Search Icon
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-297']/button", "Search Icon", "Search Icon not found");

            //Create User Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-305']/button", "Create User Button", "Create User Button not found");

            //User name
            Check(test, driver, "//*[@id='column_userName']", "User name", "User name not found");
            //First Name
            Check(test, driver, "//*[@id='column_FirstName']", "First Name", "First Name not found");
            //Last Name
            Check(test, driver, "//*[@id='column_LastName']", "Last Name", "Last Name not found");
            //User Role
            Check(test, driver, "//*[@id='column_UserGroupDisplay']", "User Role", "User Role not found");
            //Location/site
            Check(test, driver, "//*[@id='column_RootNodeDisplay']", "Location/site", "Location/site not found");

            //Edit site Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-263']/button", "Edit site Button", "Edit site Button not found");
            //Create site Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-262']/button", "Create site Button", "Create site Button not found");
            //Delete Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-180']/button", "Delete Button", "Delete Button not found");
            //Move Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-274']/button", "Move Button", "Move Button not found");
            //Start Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_button-232']/button", "Start Button", "Start Button not found");
            //Show Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-38_valuedisplay-222']/div/table/tbody/tr/td/div", "Show", "Show Text not found");

        }

        [Test, Order(7)]
        public void ShiftMangement()
        {
            test = extent.CreateTest("Shift Management");

            Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[8]/table/tbody/tr/td/a/span")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            String NewShift_Button = "//*[@id='root_pagemashupcontainer-69_navigation-231']/button";

            //Shift Management Icon
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_valuedisplay-258']/div/table/tbody/tr/td[2]/img", "Shift Management Icon", "Shift Management Icon not found");
            //Shift Management Heading
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_label-153']/span", "Shift Management", "Shift Management not found");
            //Shift Management Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_label-154']/span", "With shift management you can add your shifts and working hours, to be able to calculate valuable data for your dashboards and reports.", "Shift Management Text not found");
            //Help Menu
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_button-264']/button/span[3]", "Help", "Help not found");

            //Select site
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_label-241']/span", "Select site", "Select site not found");
            //Select site Search Box
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_esabtreeselector-240']", "Select site Search Box", "Select site Search Box not found");

            //Shift name
            Check(test, driver, "//*[@id='shiftviewer-header-day-0']", "Shift name", "Shift name not found");
            //Monday
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[2]", "Monday", "Monday not found");
            //Tuesday
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[3]", "Tuesday", "Tuesday not found");
            //Wednesday
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[4]", "Wednesday", "Wednesday not found");
            //Thursday
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[5]", "Thursday", "Thursday not found");
            //Friday
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[6]", "Friday", "Friday not found");
            //Saturday
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[7]", "Saturday", "Saturday not found");
            //Sunday
            Check(test, driver, "//div[@id='root_pagemashupcontainer-69_shiftviewer-223']/div/div/div/div[8]", "Sunday", "Sunday not found");
            //NewShift Button
            Element_check(test, driver, NewShift_Button, "NewShift Button", "NewShift Button not found");

        }

        [Test, Order(8)]
        public void AlertsAndSubscriptions()
        {
            test = extent.CreateTest("Alerts And Subscriptions");

            Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[9]/table/tbody/tr/td/a/span")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            string New_Alert = "//*[@id='root_pagemashupcontainer-69_tabsv2-187']/div[1]/div[3]/div/div/div[1]/div/div";
            string New_subscription = "//*[@id='root_pagemashupcontainer-69_tabsv2-187']/div[1]/div[3]/div/div/div[2]/div/div";
            string Current_alerts_and_subscriptions = "//*[@id='root_pagemashupcontainer-69_tabsv2-187']/div[1]/div[3]/div/div/div[3]/div/div";

            void AlertsAndSubscriptions_paramters()
            {
                test.Log(Status.Info, "AlertsAndSubscriptions_paramters");
                //Alerts & subscriptions Icon
                Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_valuedisplay-228']/div/table/tbody/tr/td[2]/img", "Alerts & subscriptions Icon", "Alerts & subscriptions Icon not found");
                //Alerts & subscriptions Heading
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_label-156']/span", "Alerts & subscriptions", "Alerts & subscriptions Heading not found");
                //Alerts & subscriptions Text
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_label-157']/span", "Here you can add new alerts and subscriptions as well as handle your current ones.", "Alerts & subscriptions Text not found");
                //Help menu
                Check(test, driver, "//*[@id='root_pagemashupcontainer-69_button-243']/button/span[3]", "Help", "Help menu not found");
                //New alert
                Check(test, driver, New_Alert, "New alert", "New alert not found");
                //New subscription
                Check(test, driver, New_subscription, "New subscription", "New subscription not found");
                //Current alerts and subscriptions
                Check(test, driver, Current_alerts_and_subscriptions, "Current alerts and subscriptions", "Current alerts and subscriptions not found");
            }

            void NewAlert_parameters()
            {
                if (driver.FindElement(By.XPath(New_Alert)).Displayed)
                {
                    test.Log(Status.Info, "NewAlerts_paramters");
                    Click(driver, driver.FindElement(By.XPath(New_Alert)));
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

                    //Pick a category and severness Heading
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-7']/div/table/tbody/tr/td/div", "1. Pick a category and severness", "Pick a category and severness Heading not found");
                    //Pick a category and severness Text
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-8']/div/table/tbody/tr/td/div", "Pick one or more categories and severity levels that you are interested in receiving alerts from.", "Pick a category and severness Text not found");

                    //How would you like to get notified? Heading
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-22']/div/table/tbody/tr/td/div", "2. How would you like to get notified?", "How would you like to get notified? Heading not found");
                    //How would you like to get notified? Text
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-23']/div/table/tbody/tr/td/div", "Pick a way to get notified. you will receive an alert as soon as an event occurs.", "How would you like to get notified? Text not found");

                    //Alert categories
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-75']/div/table/tbody/tr/td/div", "Alert categories", "Alert categories not found");
                    //Alert categories Icon
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-96']/div/table/tbody/tr/td[2]/img", "Alert categories Icon", "Alert categories Icon not found");

                    //Site level 
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-76']/div/table/tbody/tr/td/div", "Site level", "Site level not found");

                    //Alert name
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-77']/div/table/tbody/tr/td/div", "Alert name", "Alert name not found");

                    //E-mail address 
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-78']/div/table/tbody/tr/td/div", "E-mail address", "E-mail address not found");

                    //Phone number
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-79']/div/table/tbody/tr/td/div", "Phone number", "Phone number not found");
                    //Phone number Icon
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_valuedisplay-74']/div/table/tbody/tr/td[2]/img", "Phone number Icon", "Phone number Icon not found");

                    //Save Button
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-235_button-35']/button", "Save Button", "Save Button not found");

                }
            }

            void New_subscription_parameters()
            {
                if (driver.FindElement(By.XPath(New_subscription)).Displayed)
                {
                    Click(driver, driver.FindElement(By.XPath(New_subscription)));
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
                    test.Log(Status.Info, "NewSubscription_paramters");

                    //Pick topic and enter in details 
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-18']/span", "1. Pick topic and enter in details", "Pick topic and enter in details not found");

                    //Report type
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-14']/span", "Report type", "Report type not found");

                    //Report template
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-15']/span", "Report template", "Report template not found");

                    //Sites included
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-16']/span", "Sites included", "Sites included not found");

                    //Shifts included
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-17']/span", "Shifts included", "Shifts included not found");

                    //Add subscription details
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-21']/span", "2. Add subscription details", "Add subscription details not found");

                    //Subscription frequency
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-24']/span", "Subscription frequency", "Subscription frequency not found");

                    //Subscription name
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-77']/span", "Subscription name", "Subscription name not found");

                    //Add contact information
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-23']/span", "3. Add contact information", "Add contact information not found");

                    //Email Addresses
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_label-73']/span", "Email Addresses", "Email Addresses not found");

                    //Save Button
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-236_button-51']/button", "Save Button", "Save Button not found");

                }
            }

            void Current_alerts_and_subscriptions_parameters()
            {
                if (driver.FindElement(By.XPath(Current_alerts_and_subscriptions)).Displayed)
                {
                    Click(driver, driver.FindElement(By.XPath(Current_alerts_and_subscriptions)));
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
                    test.Log(Status.Info, "Current_alerts_and_sunscriptions Parameters");

                    //Alerts Heading
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-237_valuedisplay-30']/div/table/tbody/tr/td/div", "Alerts", "Alerts Heading not found");
                    //Name               
                    Check(test, driver, "//div[@id='esabvueadvancedtable-a80f9b594fd1442187ffb972ed815dd0']/div/div/div/div/table/thead/tr/th/span", "Name", "Name not found");
                    //Alert category
                    Check(test, driver, "//div[@id='esabvueadvancedtable-5bb963bde6d845faa225bb88c66b8758']/div/div/div/div/table/thead/tr/th[2]/span", "Alert category", "Alert category not found");
                    //Way of contact
                    Check(test, driver, "//div[@id='esabvueadvancedtable-5bb963bde6d845faa225bb88c66b8758']/div/div/div/div/table/thead/tr/th[3]/span", "Way of contact", "Way of contact not found");
                    //Rows per page:
                    Check(test, driver, "//*[@id='esabvueadvancedtable-782ec06f12d44306826062254db9ef15']/div/div/div[1]/div[2]/div[1]", "Rows per page:", "Rows per page: not found");

                    //Subscriptions Heading
                    Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-237_valuedisplay-33']/div/table/tbody/tr/td/div", "Subscriptions", "Subscriptions Heading not found");
                    //Selected rows: 0
                    Check(test, driver, "//*[@id='esabvueadvancedtable-782ec06f12d44306826062254db9ef15']/div/div/div[1]/span", "Selected rows: 0", "Selected rows: 0 not found");
                    //Create Button
                    Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-237_button-92']/button", "Create Button", "Create Button not found");

                }
            }

            AlertsAndSubscriptions_paramters();
            NewAlert_parameters();
            New_subscription_parameters();
            // Current_alerts_and_subscriptions_parameters(); 

        }

        [Test, Order(9)]
        public void ScanningList()
        {
            test = extent.CreateTest("Scanning List");

            Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[10]/table/tbody/tr/td/a/span")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            //Scanning lists Icon
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_valuedisplay-335']/div/table/tbody/tr/td[2]/img", "Scanning lists Icon", "Scanning lists Icon not found");
            //Scanning lists Heading
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_label-336']/span", "Scanning lists", "Scanning lists Heading not found");
            //Scanning lists Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_valuedisplay-357']/div/table/tbody/tr/td/div", "The scanning lists are used by the ESAB Connect App to detect what has been scanned. The configuration is sent to the power sources and include lists of materials and operators.", "Scanning lists Text not found");
            //Help Menu
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_button-358']/button/span[3]", "Help", "Help not found");
            //Create List Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_button-348']/button", "Create List Button", "Create List Button not found");
            //Name
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-328_gridadvanced-319-grid-advanced']/div[1]/table/tbody/tr[2]/td[1]/div", "Name", "Name not found");
            //Last modified
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-328_gridadvanced-319-grid-advanced']/div[1]/table/tbody/tr[2]/td[2]/div", "Last modified", "Last modified not found");
            //Created by
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-328_gridadvanced-319-grid-advanced']/div[1]/table/tbody/tr[2]/td[3]/div", "Created by", "Created by not found");
            //Location
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-328_gridadvanced-319-grid-advanced']/div[1]/table/tbody/tr[2]/td[4]/div", "Location", "Location not found");
            //Details
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-328_gridadvanced-319-grid-advanced']/div[1]/table/tbody/tr[2]/td[5]/div", "Details", "Details not found");

        }

        [Test, Order(10)]
        public void LicenceManagement()
        {
            /* test = extent.CreateTest("Licence Management");

                 Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[11]/table/tbody/tr/td/a/span")));
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
            test = extent.CreateTest("Administration");

            Click(driver, driver.FindElement(By.XPath("//*[@id='root_menu-40']/li[12]/table/tbody/tr/td/a/span")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            //Adminstration Icon
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-40']/div/table/tbody/tr/td[2]/img", "Adminstration Icon", "Adminstration Icon not found");
            //Administration Heading
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-36']/div/table/tbody/tr/td/div", "Administration", "Administration Heading not found");
            //Organization structure Heading
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-56']/div/table/tbody/tr/td/div", "Organization structure", "Organization structure Heading not found");
            //Organization structure Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-219']/div/table/tbody/tr/td/div", "Click on items in the tree to filter the list.", "Organization structure Text not found");
            //Customers Heading
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-299']/div/table/tbody/tr/td/div", "Customers", "Customers Heading not found");
            //Customers Text
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-301']/div/table/tbody/tr/td/div", "The shown assets are based on the marked level in the tree structure.", "Customers Text not found");
            //Help Menu
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-324']/button/span[3]", "Help", "Help Menu not found");
            //Search Box
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_textbox-311']/table/tbody/tr/td/input", "Search Box", "Search Box not found");
            //Search Icon
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-313']/button", "Search Icon", "Search Icon not found");
            //Create Customer Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-319']/button", "Create Customer Button", "Create Customer Button not found");
            //ESAB Node
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_tree-1']/div/table/tbody/tr[2]/td[2]/table/tbody/tr[1]", "ESAB Node", "ESAB Node not found");
            //Refresh Icon
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-362']/button", "Refresh Icon", "Refresh Icon not found");
            //Create Node Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-231']/button", "Create Node Button", "Create Node Button not found");
            //Delete Button
            Element_check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_button-180']/button", "Delete Button", "Delete Button not found");
            //Customer name
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-145']/div/table/tbody/tr/td/div", "Customer name", "Customer name not found");
            //Location/site
            Check(test, driver, "//*[@id='root_pagemashupcontainer-69_mashupcontainer-73_valuedisplay-147']/div/table/tbody/tr/td/div", "Location/site", "Location/site not found");

        }

        //Check(test, driver, , "", "not found");
        //Element_check(test, driver,,""," not found");
       
    }
}
