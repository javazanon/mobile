using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace POS_ERP.com.zanon.ERP.util
{
    public class AlertScript
    {
        public static int infoMsg = 1;
        public static int warnMsg = 2;
        public static int errorMsg = 3;
        //public static int infoMsg = 4;
        //public static int infoMsg = 5;
        public void displayAlert(Page myPage , string ResultMessage , int msgType)
        {
            try
            {
               // ResultMessage ="بيانات الدخول غير صحيحة برجاء المحاولة مرة اخرى";
                string script = "<script type=\"text/javascript\">alert(\'" + ResultMessage + "\');</script>"; 
                myPage.ClientScript.RegisterClientScriptBlock(myPage.GetType(), "alert", script); 
            }
            catch(Exception ex)
            {

            }
        }
        public void displayAlert(Page myPage, string ResultMessage)
        {
            try
            {
                displayAlert(myPage, ResultMessage, errorMsg);
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}