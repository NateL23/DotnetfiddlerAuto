namespace DNFAutoTest
{
    using DNFAutoFramework.Base;
    using DNFAutoFramework.Helpers;
    using DNFAutoTest.Pages;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class Test2 : HookInitialize
    {
        [TestMethod]
        public void NameBasedTest()
        {
            LogHelpers.Write("Test 2: Name Based Test - Running..");
            // initialize the homepage, click "<" button to hide options panel
            this.CurrentPage = this.GetInstance<DNFHomepage>();
            this.CurrentPage.As<DNFHomepage>().HidePanel();
            // assert options panel is hidden
            try
            {
                this.CurrentPage.As<DNFHomepage>().AssertOptionPanelHidden();
                LogHelpers.Write("Test 2: Name Based Test - Passed!");
            }
            catch (Exception e)
            {
                LogHelpers.Write("Test 2: Name Based Test - FAILED!");
                LogHelpers.Write(e.ToString());
            }
            DriverContext.Driver.Close();
            LogHelpers.Write("Closed The Chrome Browser");
        }
    }
}
