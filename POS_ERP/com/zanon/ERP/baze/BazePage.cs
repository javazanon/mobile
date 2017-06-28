using POS_ERP.com.zanon.ERP.beans;
using POS_ERP.com.zanon.ERP.config;
using POS_ERP.com.zanon.ERP.logging;
using POS_ERP.com.zanon.ERP.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace POS_ERP.com.zanon.ERP.baze
{
    public class BazePage : Page
    {
       public  NLogLogger myLog = new NLogLogger();
       public AlertScript myScript = new AlertScript();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected  override void OnInit(EventArgs e)
        {
            try
            {
                object userProfile = Session[SessionKeys.userProfile];
                if (userProfile == null)
                {
                    Response.Redirect(PageUrlKeys.loginPage, true);
                }
            }
            catch (Exception ee)
            {
 
            }
        }
        public UserProfile _currentUser{
            get { 
                UserProfile myUser =(UserProfile) Session[SessionKeys.userProfile];
                return myUser ;
            }
            set
            {
                Session[SessionKeys.userProfile] =  value;
            } 
         }
    }
}