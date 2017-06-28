using POS_ERP.com.zanon.ERP.beans;
using POS_ERP.com.zanon.ERP.config;
using POS_ERP.com.zanon.ERP.database.connection;
using POS_ERP.com.zanon.ERP.CustomException;
using POS_ERP.com.zanon.ERP.logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.baze
{
    public class BazeClazz : IDisposable
    {
        public NLogLogger myLog = new NLogLogger();
        public ConnectionManager dbConn = new ConnectionManager();
        public UserProfile CurrentUser
        {
            get 
            {
                
                object usr = HttpContext.Current.Session[SessionKeys.userProfile];
                return (UserProfile)usr;
            }
            set 
            { 
                if( HttpContext.Current.Session[SessionKeys.userProfile]!=null)
                {
                     HttpContext.Current.Session[SessionKeys.userProfile] = value;
                }
            }
        }

        public void Dispose()
        {
            try
            {
                dbConn.currentConnection.Close();
                dbConn.currentConnection.Dispose();
            }
            catch (Exception ex)
            {
 
            }
        }
    }
}