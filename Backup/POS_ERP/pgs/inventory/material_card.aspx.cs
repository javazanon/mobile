using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POS_ERP.com.zanon.ERP.config;
using POS_ERP.com.zanon.ERP.beans;

namespace POS_ERP.pgs.inventory
{
    public partial class material_card : System.Web.UI.Page
    {
        public bool foundItemCard = false ;
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
                else
                {
                    fillMtarialCards();
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
                fillInventory();
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
        private void  fillInventory()
            {
                try
                {
                    string selectedCompVal = lst_company.SelectedItem.Value;
                    List<InventoryBean> inventoryDataSource = new InventoryBean().getAllInventoryUnderCompany(selectedCompVal);
                    lst_storage.DataSource = inventoryDataSource ;
                    lst_storage.DataTextField="strg_name";
                    lst_storage.DataValueField="id";
                    lst_storage.DataBind();
                }
                catch(Exception ex)
                {
                }
            }

        private void fillMtarialCards()
        {
            try
            {
                grid_item_cards.DataSource =new List<MaterialCardBean>();
                grid_item_cards.DataBind();
                string selectedCompVal = lst_company.SelectedItem.Value;
                string selectedInventoryVal = lst_storage.SelectedItem.Value;
                string selectedGroupVal = lst_MATERIAL_GRP.SelectedItem.Value;
                string sql = "select * from pos.tmaterial_card where comp_id = @cmp_id and inventory_id = @inventory_id "+
                                " and material_id in (select id from pos.tmaterial where grp_id = @grp_id)" ;
                Dictionary<string,string> parameters  = new Dictionary<string,string>();
                parameters.Add("@cmp_id",selectedCompVal);
                parameters.Add("@inventory_id",selectedInventoryVal);
                parameters.Add("@grp_id",selectedGroupVal);
                grid_item_cards.DataSource =  new MaterialCardBean().getMaterialsCard(sql,parameters);
                grid_item_cards.DataBind();
            }
            catch(Exception ex)
            {

            }
        }
    }
}