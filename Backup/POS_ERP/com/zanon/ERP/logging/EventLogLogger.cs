using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace POS_ERP.com.zanon.ERP.logging {
    public class EventLogLogger:ILogger {
        
        #region ILogger Members

        public void Info(string message) {
            WriteToEventLog(message, EventLogEntryType.Information);
        }

        public void Warn(string message) {
            WriteToEventLog(message, EventLogEntryType.Warning);
        }

        public void Debug(string message) {
            //no need to send this to the EventLog - output it 
            //to the DEBUG window
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Error(string message) {
            WriteToEventLog(message, EventLogEntryType.Error);
        }

        public void Error(Exception x) {
            Error(new LogUtility().BuildExceptionMessage(x));
        }

        public void Fatal(string message) {
            WriteToEventLog(message, EventLogEntryType.Error);
        }
        public void Fatal(Exception x) {
            WriteToEventLog(new LogUtility().BuildExceptionMessage(x), EventLogEntryType.Error);
        }


        void WriteToEventLog(string message, EventLogEntryType logType) {

            try
            {
                EventLog eventLog = new EventLog();

                //use the app log - you can customize this as you need
                string storeName = System.Configuration
                    .ConfigurationManager.AppSettings["StoreName"].ToString();
                eventLog.Source = storeName;

                eventLog.WriteEntry(message, logType);
            }
            catch (Exception)
            {                                
            }
        }
        #endregion
    }
}
