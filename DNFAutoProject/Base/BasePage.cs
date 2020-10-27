using DNFAutoFramework.Base;
using OpenQA.Selenium.Support.PageObjects;

    public abstract class BasePage : Base
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
            /*
             * 
             Page Factory is a class provided by Selenium WebDriver to support
             Page Object Design patterns

             In Page Factory, testers use @FindBy annotation. The initElements
             method is used to initialize web elements
             *
             */
        }
    }
