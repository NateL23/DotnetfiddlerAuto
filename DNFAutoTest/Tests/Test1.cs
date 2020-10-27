namespace DNFAutoTest
{
    using DNFAutoFramework.Base;
    using DNFAutoFramework.Helpers;
    using DNFAutoTest.Pages;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Chrome;

    [TestClass]
    public class Test1 : Base
    {
        private readonly string url = "https://dotnetfiddle.net/";

        // select which browser selenium will use
        // default set to chrome
        public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            LogHelpers.CreateLogFile();
            switch (browserType)
            {
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }
        [TestMethod]
        public void ClickRun()
        {
            // Open the Browser
            this.OpenBrowser();
            LogHelpers.Write("Running Test 1...");
            DriverContext.Browser.GoToUrl(this.url);
            
            this.CurrentPage = this.GetInstance<DNFHomepage>();
            this.CurrentPage.As<DNFHomepage>().ClickRun();
            
            
            DriverContext.Driver.Close();
            LogHelpers.Write("Closed the Chrome browser");
            LogHelpers.Write("SUCCESS");
            LogHelpers.Write("!!!!!!!!!!~~~~~END OF LOGFILE~~~~~!!!!!!!!!!");
        }
    }
}
