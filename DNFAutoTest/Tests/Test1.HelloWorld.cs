namespace DNFAutoTest
{
    using DNFAutoFramework.Base;
    using DNFAutoFramework.Helpers;
    using DNFAutoTest.Pages;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test1 : HookInitialize
    {
        [TestMethod]
        public void RunHelloWorld()
        {
            LogHelpers.Write("Test 1: Hello World - Running..");
            // initialize the homepage, click run button
            this.CurrentPage = this.GetInstance<DNFHomepage>();
            this.CurrentPage.As<DNFHomepage>().ClickRun();
            
            // assert output text (expected: Hello World)
            if(this.CurrentPage.As<DNFHomepage>().AssertHelloWorld())
            {
                LogHelpers.Write("Test 1: Hello World - Passed!");
            }
            else
            {
                LogHelpers.Write("Test 1: Hello World - FAILED!");
            }

            DriverContext.Driver.Close();
            LogHelpers.Write("Closed The Chrome Browser");
        }
    }
}
