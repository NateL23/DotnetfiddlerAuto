namespace DNFAutoTest.Pages
{
    using DNFAutoFramework.Base;
    using DNFAutoFramework.Extensions;
    using DNFAutoFramework.Helpers;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using System;

    class DNFHomepage : BasePage
    {
        // locator objects
        [FindsBy(How = How.Id, Using = "run-button")]
        IWebElement runButton { get; set; }

        [FindsBy(How = How.Id, Using = "output")]
        IWebElement outputElement { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".btn-sidebar-toggle")]
        IWebElement panelCollapseButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".unselectable")]
        IWebElement sideBar { get; set; }

        // click the run button
        public void ClickRun()
        {
            // waits at least 2s for the page to load before clicking 
            DriverContext.Driver.WaitForPageLoad(2000);
            this.runButton.Click();
        }
        public void HidePanel()
        {
            DriverContext.Driver.WaitForPageLoad(2000);
            this.panelCollapseButton.Click();
        }

        // assert for test 1
        internal bool AssertHelloWorld()
        {
            if(outputElement.Text == "Hello World")
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("Err: Hello World Output Failed"));
            }
        }
        // assert for test 2
        internal bool AssertOptionPanelHidden()
        {
            DriverContext.Driver.WaitForPageLoad(2000);
            if (sideBar.GetAttribute("style").ToString() == "left: -180px;")
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("Err: AssertElementNotPresent Failed!"));
            }
        }
    }
}
