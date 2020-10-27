namespace DNFAutoTest.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    class DNFHomepage : BasePage
    {
        // locator objects
        [FindsBy(How = How.Id, Using = "run-button")]
        IWebElement runButton { get; set; }

        // [FindsBy(How = How.CssSelector, Using = "input.btn")]
        // IWebElement btnLogin { get; set; }

        
        // click the run button
        public void ClickRun()
        {
            this.runButton.Click();
        }
    }
}
