using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using System.Web;

namespace POS_ERP.com.zanon.ERP.logging
{
    public class NLogLogger:ILogger {
        bool allowRedirect=true;
        private Logger _logger;
        public NLogLogger() 
        {
            try
            {
                _logger = LogManager.GetCurrentClassLogger();
            }
            catch(Exception ex)
            {
            }            
        }
        private void redirectToError(string msg)
        {
            Error(msg);
        }
        private void redirectToError(Exception ex)
        {
            Error(ex);
        }
        public void Info(string message) {
            try
            {
                if(allowRedirect)
                {
                    redirectToError(message);
                }
                else
                {
                    _logger.Info(message);
                }
            }
            catch (Exception)
            {
                
               
            }
        }

        public void Warn(string message) {
            try
            {
               if(allowRedirect)
                {
                    redirectToError(message);
                }
                else
                {
                 _logger.Warn(message);
                }
            }
            catch (Exception)
            {
                
               
            }
        }

        public void Debug(string message) {
            try
            {
               if(allowRedirect)
                {
                    redirectToError(message);
                }
                else
                {
                  _logger.Debug(message);
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        public void Error(string message) {
            try
            {
                
                String logFileContent="*****************************************************************************";
                logFileContent+=message;
                logFileContent+="*****************************************************************************";
                _logger.Error(logFileContent);
            }
            catch (Exception)
            {
                
                
            }
        }
        public void Error(Exception x) {
            Error(new LogUtility().BuildExceptionMessage(x));
        }
        public void Fatal(string message) {
            try
            {
                _logger.Fatal(message);
            }
            catch (Exception)
            {
                
                
            }
        }
        public void Fatal(Exception x) {
            Fatal(new LogUtility().BuildExceptionMessage(x));
        }
    }
}
