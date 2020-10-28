namespace DNFAutoTest
{
    //    using DNFAutoFramework.Base;
    //    using DNFAutoFramework.Config;
    //    using DNFAutoFramework.Helpers;
    //    using Microsoft.VisualStudio.TestTools.UnitTesting;
    //    using OpenQA.Selenium.Chrome;

    //    [TestClass]
    //    public class Test2 : Base
    //    {
    //        private string url = null;

    //        // grabs the XLSX filename and logs path from the app.config
    //        static readonly string fileName = ConfigReader.InitializeTest();
    //        static readonly string dir = @ConfigReader.InitializeLogs().ToString();

    //        // select which browser selenium will use
    //        // default set to chrome
    //        public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
    //        {
    //            LogHelpers.CreateLogFile(dir);
    //            ExcelHelpers.PopulateInCollection(fileName);

    //            // reads in URL from the .xslx file in ExcelData folder
    //            url = ExcelHelpers.ReadData(1, "URL");

    //            switch (browserType)
    //            {
    //                case BrowserType.Chrome:
    //                    DriverContext.Driver = new ChromeDriver();
    //                    DriverContext.Browser = new Browser(DriverContext.Driver);
    //                    break;
    //            }
    //        }
    //        [TestMethod]
    //        public void TestMethod2()
    //        {
    //        }
    //    }
}
