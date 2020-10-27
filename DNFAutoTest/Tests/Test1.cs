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
        string fileName = "../../ExcelData/Credentials.xlsx";
        private string url = null;
        
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
            
            this.CurrentPage = this.GetInstance<DNFHomepage>();
            this.CurrentPage.As<DNFHomepage>().ClickRun();
            
            DriverContext.Driver.Close();
            LogHelpers.Write("Closed The Chrome Browser");
            LogHelpers.Write("SUCCESS");
            LogHelpers.Write("!!!!!!!!!!~~~~~END OF LOGFILE~~~~~!!!!!!!!!!");
        }
    }
}
