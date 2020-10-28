namespace DNFAutoTest.Pages
{
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
            this.runButton.Click();
        }

        // assert for Test 1
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
