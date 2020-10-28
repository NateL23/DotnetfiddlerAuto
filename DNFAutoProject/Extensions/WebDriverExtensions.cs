using DNFAutoFramework.Base;
using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace DNFAutoFramework.Extensions
{
    public static class WebDriverExtensions
    {
        // uses javascript code to get the state of the page document and wait until ready
        public static void WaitForPageLoad(this IWebDriver driver, int timeout)
        {
            driver.WaitForCondition(dri =>
            {
                string state = dri.ExecuteJS("return document.readyState").ToString();
                return state == "complete";
            }, timeout);
        }
        // wait for a condition to be met
        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            bool execute(T arg)
            {
                try
                {
                    return condition(arg);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            var stopwatch = Stopwatch.StartNew();
            // set wait time for condition to be met
            while(stopwatch.ElapsedMilliseconds < timeOut)
                {
                    if (execute(obj))
                    {
                        break;
                    }
                }
        }
        // sometimes javascript can be useful
        internal static object ExecuteJS(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }
    }
}
