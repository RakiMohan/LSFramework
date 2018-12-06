using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using OpenQA.Selenium;
namespace CommonFiles
{
    public class LogHandler
    {
        private static LogHandler instance;
        
        public static LogHandler Instance
        {
            get
            {
                if (instance == null && Boolean.Parse(ConfigurationManager.AppSettings["Logger"].ToString()))
                    instance = Activator.CreateInstance<LogHandler>();

                return instance;
            }
            
        }
        protected StreamWriter log { get; set; }

       
        
        public void _CreateLogger()
        {

            if (instance != null)
            {
                FileStream fileStream = null;
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo;

                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = path.Substring(0, path.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath; // project path of your solution
                DateTime date1 = DateTime.Now;
                string Log_Name = ConfigurationManager.AppSettings["Client"].ToString() +"-"+ DateTime.Now.ToString("ddMMMyyyyHHmmss") + "." + "txt";
                string logFilePath = projectPath + "Log\\" + Log_Name ;
                logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                log = new StreamWriter(fileStream);
                log.AutoFlush = true;
                log.WriteLine("Log File created successfully.");
            }
            
        }
        public void LogStep( string slog)
        {
            if (log != null)
            {
                //log.Write("\n\r");
                //log.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                //log.Write("  :");
                //log.Write("{0}", slog);
                //log.Write("\n-------------------------------");
                log.Write("write \n");
                log.WriteLine("Write line");
                
            }
                
            
        }
        public void LogStep(LogLevel logLevel,string slog)
        {
            if (log != null)
                log.WriteLine("<"+logLevel +"> " +slog);

        }
        public void _CloseLogger()
        {
            if (log != null)
            {
                log.Close();
                log.Dispose();
            }
        }
    }
}
