namespace DNFAutoTest
{
    using DNFAutoFramework.Base;
    using DNFAutoFramework.Config;
    using DNFAutoFramework.Helpers;
    using DNFAutoTest.Pages;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Chrome;

    [TestClass]
    public class Test1 : Base
    {
        private string url = null;
        
        // grabs the XLSX filename from the app.config
        static string fileName = ConfigReader.InitializeTest();
        
        // select which browser selenium will use
        // default set to chrome
        public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            LogHelpers.CreateLogFile();
            ExcelHelpers.PopulateInCollection(fileName);
            
            // reads in URL from the .xslx file in ExcelData folder
            url = ExcelHelpers.ReadData(1, "URL");

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
            this.OpenBrowser();
            LogHelpers.Write("Running Hello World Test...");
            DriverContext.Browser.GoToUrl(this.url);
            
            // initialize the homepage, click run button
            this.CurrentPage = this.GetInstance<DNFHomepage>();
            this.CurrentPage.As<DNFHomepage>().ClickRun();
            
            // assert output text (expected: Hello World)
            if(this.CurrentPage.As<DNFHomepage>().AssertHelloWorld())
            {
                LogHelpers.Write("Test 1: Hello World - Passed!");
            }

            DriverContext.Driver.Close();
            LogHelpers.Write("Closed The Chrome Browser");
            LogHelpers.Write("SUCCESS");
            LogHelpers.Write("!!!!!!!!!!~~~~~END OF LOGFILE~~~~~!!!!!!!!!!");
        }
    }
}
