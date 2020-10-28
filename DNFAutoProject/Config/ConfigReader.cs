namespace DNFAutoFramework.Config
{
    using System.Configuration;

    public class ConfigReader
    {
        public static string InitializeTest()
        {
            return ConfigurationManager.AppSettings["XLSXFILE"].ToString();
        }

        public static string InitializeLogs()
        {
            return ConfigurationManager.AppSettings["LOGFILE"].ToString();
        }
    }
}
