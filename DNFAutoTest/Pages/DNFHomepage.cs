namespace DNFAutoTest.Pages
{
    using DNFAutoFramework.Base;
    using DNFAutoFramework.Extensions;
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

        // click the run button
        public void ClickRun()
        {
            // waits at least 2s for the page to load before clicking 
            DriverContext.Driver.WaitForPageLoad(2000);
            this.runButton.Click();
        }

        // assert for test 1
        internal bool AssertHelloWorld()
        {
            if(!(outputElement.Text == "Hello World"))
            {
                throw new Exception(string.Format("Err: Hello World Output Failed"));
            }
            else
            {
                return true;
            }
        }
    }
}
