namespace DNFAutoFramework.Base
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class Base
    {
        public BasePage CurrentPage { get; set; }
        private IWebDriver _driver { get; set; }

        // create generic BasePage instance
        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                _driver = DriverContext.Driver
            };

            PageFactory.InitElements(DriverContext.Driver, pageInstance);
            return pageInstance;
        }
        // return current page using 'As<>'
        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
