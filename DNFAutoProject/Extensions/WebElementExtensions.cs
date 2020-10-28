using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DNFAutoFramework.Extensions
{
    public static class WebElementExtensions
    {
        public static void SelectDropdownList(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }
        
        public static void AssertElementPresent(this IWebElement element)
        {
            if(!IsElementPresent(element))
            {
                throw new Exception(string.Format("Err: Assert Element Text failed"));
            };
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
