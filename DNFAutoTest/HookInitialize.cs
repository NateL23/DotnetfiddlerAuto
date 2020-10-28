using DNFAutoFramework.Base;

namespace DNFAutoTest
{
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize() : base(BrowserType.Chrome)
        {
            InitializeSettings();
            NavigateToSite();
        }
    }
}
