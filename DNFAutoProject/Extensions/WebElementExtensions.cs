using DNFAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DNFAutoFramework.Extensions
{
    public static class WebElementExtensions
    {
        // return the option matching the value parameter from dropdown element
        public static void SelectDropdownList(IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }
        // return the currently selected dropdown option
        public static string GetSelectedDropdown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }
        // return all dropdown options
        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }
        // action - Shover the mouse over an element 
        public static void Hover(this IWebElement element)
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Perform();
        }


        // assert element is present on the webpage
        public static void AssertElementPresent(this IWebElement element)
        {
            if(!IsElementPresent(element))
            {
                throw new Exception(string.Format("Err: Assert Element Text failed"));
            };
        }
        // return true if element is displayedon the webpage
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
