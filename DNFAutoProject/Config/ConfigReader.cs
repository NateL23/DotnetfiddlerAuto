namespace DNFAutoFramework.Config
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Xml.XPath;

    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            XPathItem url;
            XPathItem testType;
            XPathItem isLog;
            XPathItem isReport;
            XPathItem buildName;
            XPathItem logPath;

            string strFileName = ConfigurationManager.AppSettings["CNFGFILE"].ToString();
            FileStream stream = new FileStream(strFileName, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();
            
            // get xml details and pass into XPathItem type objects
            url = navigator.SelectSingleNode("DNFAutoFramework/RunSettings/URL");
            testType = navigator.SelectSingleNode("DNFAutoFramework/RunSettings/BuildName");
            isLog = navigator.SelectSingleNode("DNFAutoFramework/RunSettings/TestType");
            isReport = navigator.SelectSingleNode("DNFAutoFramework/RunSettings/IsLog");
            buildName = navigator.SelectSingleNode("DNFAutoFramework/RunSettings/IsReport");
            logPath = navigator.SelectSingleNode("DNFAutoFramework/RunSettings/LogPath");

            // set xml details into settings properties to be used across framework
            Settings.URL = url.ToString();
            Settings.BuildName = buildName.Value.ToString();
            Settings.TestType = testType.Value.ToString();
            Settings.IsLog = isLog.Value.ToString();
            Settings.IsReport = isReport.Value.ToString();
            Settings.LogPath = logPath.Value.ToString();

        }
        public static string GetXLSXPath()
        {
            return ConfigurationManager.AppSettings["XLSXFILE"].ToString();
        }

        public static string GetConfigPath()
        {
            return ConfigurationManager.AppSettings["CNFGFILE"].ToString();
        }

    }
}
