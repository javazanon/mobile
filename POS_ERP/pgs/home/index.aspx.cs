using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POS_ERP.com.zanon.ERP.config;

namespace POS_ERP.pgs.home
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session[SessionKeys.userProfile]==null)
            {
                Response.Redirect("~/pgs/home/login.aspx",true);
            }
        }
    }
}