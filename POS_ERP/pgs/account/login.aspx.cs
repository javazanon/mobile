using POS_ERP.com.zanon.ERP.baze;
using POS_ERP.com.zanon.ERP.beans;
using POS_ERP.com.zanon.ERP.config;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.database.connection;
using POS_ERP.com.zanon.ERP.database.model;
using POS_ERP.com.zanon.ERP.database.service;
using POS_ERP.com.zanon.ERP.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POS_ERP.pgs.account
{
    public partial class login : BazeAnomymousePage
    {
        public string ResultMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            // check login for current user and create his profile
            try
            {
                string userID = userNameTxt.Text;
                string password = password_txt.Text;
                TransactionResult trxStatus = new TransactionResult();
                using( Authentication_SVC svc = new Authentication_SVC())
                {
                    trxStatus = svc.authonticateLogin(userID,password);
                }
               if (trxStatus.status)
                {
                    // here create profile for user and redirect him to home page for stat transaction
                    using (Authentication_SVC svc = new Authentication_SVC())
                    {
                        UserProfile myProfile = svc.FillUser(userID);
                        Session[SessionKeys.userProfile] = myProfile;
                        Response.Redirect(PageUrlKeys.homePage);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {
                    ResultMessage = trxStatus.msg;
                    myScript.displayAlert(this, ResultMessage);
                }
            }
            catch (Exception ee)
            {
                myLog.Error(ee);
            }
            
        }
    }
}