namespace DNFAutoFramework.Helpers
{
    using System;
    using System.IO;
    using DNFAutoFramework.Config;

    public class LogHelpers
    {
        // global declaration
        private static string _logFileName = string.Format("DNFTestLog - {0:yyyy.mm.dd-hh.mm}", DateTime.Now);
        private static StreamWriter _streamw = null;
        
        // create a file which stores log information
        public static void CreateLogFile(string dir)
        {
            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
        }

        // write text to the log file
        public static void Write(string logMessage)
        {
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine("    {0}", logMessage);
            _streamw.Flush();
        }
    }
}
