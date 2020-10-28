namespace DNFAutoFramework.Base
{
    using DNFAutoFramework.Config;
    using DNFAutoFramework.Helpers;
    using OpenQA.Selenium.Chrome;
    using System;

    public abstract class TestInitializeHook : Base
    {
        private string url = null;
        public readonly BrowserType Browser;
        // grabs the XLSX filename and logs path from the app.config
        static readonly string xlsxFile= ConfigReader.GetXLSXPath();

        public TestInitializeHook(BrowserType browser)
        {
            Browser = browser;
        }

        public void InitializeSettings()
        {
            ConfigReader.SetFrameworkSettings();
            LogHelpers.CreateLogFile(Settings.LogPath);
            ExcelHelpers.PopulateInCollection(xlsxFile);
            OpenBrowser(Browser);

        }
        public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        DriverContext.Driver = new ChromeDriver();
                        DriverContext.Browser = new Browser(DriverContext.Driver);
                        LogHelpers.Write("Launched Chrome Browser");
                    break;
                    default:
                        LogHelpers.Write("Invalid Browser Type");
                    break;
                }

        }
        public virtual void NavigateToSite()
        {
            // reads in URL from the .xslx file in ExcelData folder
           try
            {
                this.url = ExcelHelpers.ReadData(1, "URL");
            }
            catch(Exception e)
            {
                this.url = Settings.URL;
            }
            
            DriverContext.Browser.GoToUrl(url);
            LogHelpers.Write("Navigated to: " + url);
        }
    }
}
