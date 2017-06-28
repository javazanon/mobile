using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POS_ERP.com.zanon.ERP.config;
using POS_ERP.com.zanon.ERP.beans;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.logging;
using POS_ERP.com.zanon.ERP.util;

namespace POS_ERP.pgs.inventory
{
    public partial class Material_C : System.Web.UI.Page
    {
        NLogLogger mylog= new NLogLogger();
        protected void Page_Load(object sender, EventArgs e)
        {
            object userProfile = Session[SessionKeys.userProfile]; 
            if(userProfile==null)
            {
                // redirect to login page 
                Response.Redirect("~/home/login.aspx",true);
            }
            
            // 
            if(!IsPostBack)
            {
                fillScreen( userProfile);
            }
        }

        private void fillScreen( object userProfile)
        {
            try
            {
            UserProfile curentUser = (UserProfile)userProfile ;
            List<CompanyBeans> userCompanyDataSource = curentUser.userCompany;
            lst_company.DataSource = userCompanyDataSource ;
            lst_company.DataTextField="cmp_code";
            lst_company.DataValueField="id";
            lst_company.DataBind();
            fillMaterialGroup();
            fillMeasures();
            txt_mrp_low.Text="0";
            txt_mrp_high.Text="100";
            }
            catch(Exception ex)
            {
                mylog.Error(ex);
            }
        }

        protected void lst_company_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
              fillMaterialGroup();
            }
            catch(Exception ex)
            {
                mylog.Error(ex);
            }
        }

        private void fillMaterialGroup()
        {
            try
            {
             string selectedCompVal = lst_company.SelectedItem.Value;
            string sql = " select * from pos.tmatr_grp  where cmp_id = @cmp_id ";
            Dictionary<string,string> parameters  = new Dictionary<string,string>();
            parameters.Add("@cmp_id",selectedCompVal);
            List<materialGroupBean> GRPSDataSource = new materialGroupBean().getAllMaterialGroups(sql,parameters);

            lst_matr_grp.DataSource = GRPSDataSource ;
            lst_matr_grp.DataTextField="name";
            lst_matr_grp.DataValueField="ID";
            lst_matr_grp.DataBind();
            }
            catch(Exception ex)
            {
                mylog.Error(ex);
            }
        }

        private void fillMeasures()
        {
            try
            {
            string sql = " select * from pos.tmeasure ";
            Dictionary<string,string> parameters  = new Dictionary<string,string>();
            List<MeasureBean> measuresDataSource = new MeasureBean().getAllMeasures(sql,parameters);
            lst_measure.DataSource = measuresDataSource ;
            lst_measure.DataTextField="long_name";
            lst_measure.DataValueField="ID";
            lst_measure.DataBind();
            }
            catch(Exception ex)
            {
                mylog.Error(ex);
            }
        }
        private bool createMaterial()
        {
            bool created=false ;
            try
            {
                MaterialBean newMaterial =  new MaterialBean();
                newMaterial.COMP_ID = int.Parse(lst_company.SelectedValue);
                newMaterial.GRP_ID = int.Parse(lst_matr_grp.SelectedValue);
                newMaterial.LONG_NAME= txt_material_longname.Text ;
                newMaterial.MEASURE = int.Parse(lst_measure.SelectedValue);
                newMaterial.MRP_HIGH= int.Parse(txt_mrp_high.Text);
                newMaterial.MRP_LOW = int.Parse(txt_mrp_low.Text);
                newMaterial.NAME= txt_materialname.Text ;
                created = new MaterialBean().createItem(newMaterial);
            }
            catch(Exception ex)
            {
                mylog.Error(ex);
            }
            return created ;
        }

        protected void btn_create_Click(object sender, EventArgs e)
        {
         bool created = createMaterial();
            if(created)
            {
                  new AlertScript().displayAlert(this,"تم انشاء الصنف بنجاح");
            }
            else
            {
                 new AlertScript().displayAlert(this,"فشلت العملية");
            }
        }
    }
}