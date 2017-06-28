using POS_ERP.com.zanon.ERP.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POS_ERP.pgs.account
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             try
            {
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                Response.Redirect(PageUrlKeys.loginPage);
            }
            catch (Exception ee)
            {
 
            }
        }
    }
}