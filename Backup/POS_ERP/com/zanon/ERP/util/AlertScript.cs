using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace POS_ERP.com.zanon.ERP.util
{
    public class AlertScript
    {

        public void displayAlert(Page myPage , string ResultMessage)
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
    }
}