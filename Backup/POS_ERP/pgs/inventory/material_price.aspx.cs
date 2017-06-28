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

namespace POS_ERP.pgs.inventory
{
    public partial class material_price : System.Web.UI.Page
    {
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
                UserProfile curentUser = (UserProfile)userProfile ;
                List<CompanyBeans> userCompanyDataSource = curentUser.userCompany;
                lst_company.DataSource = userCompanyDataSource ;
                lst_company.DataTextField="cmp_code";
                lst_company.DataValueField="id";
                lst_company.DataBind();
                fillgroups();
                fillMaterial();
                fillCurrenices();
                datepicker_from.MinDate=DateTime.Now;
                datepicker_to.MaxDate=DateTime.Now.Add(new TimeSpan(1200,0,0,0));
                datepicker_from.SelectedDate=DateTime.Now ;
                datepicker_to.SelectedDate=DateTime.Now.Add(new TimeSpan(1200,0,0,0));
            }

            protected void lst_company_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
            {
                fillgroups();
            }
             protected void lst_MATERIAL_GRP_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
            {
                fillMaterial();
            }
            private void  fillgroups()
            {
                try
                {
                    string selectedCompVal = lst_company.SelectedItem.Value;
                    string sql = " select * from pos.tmatr_grp where CMP_ID = @cmp_id ";
                    Dictionary<string,string> parameters  = new Dictionary<string,string>();
                    parameters.Add("@cmp_id",selectedCompVal);
                    List<materialGroupBean> materialGroupDataSource = new materialGroupBean().getAllMaterialGroups(sql,parameters);

                    lst_MATERIAL_GRP.DataSource = materialGroupDataSource ;
                    lst_MATERIAL_GRP.DataTextField="NAME";
                    lst_MATERIAL_GRP.DataValueField="ID";
                    lst_MATERIAL_GRP.DataBind();
                }
                catch(Exception ex)
                {
                }
            }
            private void fillMaterial()
            {
                try
                {
                    string selectedGrpVal = lst_MATERIAL_GRP.SelectedItem.Value;
                    string sql = " select * from pos.tmaterial where grp_id = @grp_id ";
                    Dictionary<string,string> parameters  = new Dictionary<string,string>();
                    parameters.Add("@grp_id",selectedGrpVal);
                    List<MaterialBean> materialDataSource = new MaterialBean().getAllMaterial(sql,parameters);

                    lst_material.DataSource = materialDataSource ;
                    lst_material.DataTextField="name";
                    lst_material.DataValueField="ID";
                    lst_material.DataBind();
                }
                catch(Exception ex)
                {
                }
            }

            private void fillCurrenices()
            {
                string sql = " select * from pos.TCURRENCY  ";
                Dictionary<string,string> parameters  = new Dictionary<string,string>();
               List<CurrencyBean> currencyDataSource =  new CurrencyBean().getAllCurrency(sql,parameters);
                lst_currency.DataSource = currencyDataSource ;
                lst_currency.DataTextField="NAME";
                lst_currency.DataValueField="ID";
                lst_currency.DataBind();
            }
            private void createMaterialPrice()
            {

            }

            protected void btn_create_Click(object sender, EventArgs e)
            {
                createMaterialPrice();
            }

       
    }
  }
