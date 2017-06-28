 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POS_ERP.com.zanon.ERP.config;
using POS_ERP.com.zanon.ERP.beans;
using POS_ERP.com.zanon.ERP.logging;
using POS_ERP.com.zanon.ERP.util;
using POS_ERP.com.zanon.ERP.database.service;
using POS_ERP.com.zanon.ERP.baze;

namespace POS_ERP.pgs.inventory
{
    public partial class matr_mov : BazePage
    {
        protected void Page_Load(object sender, EventArgs e)
            {
                if(!IsPostBack)
                {
                    fillScreen(_currentUser);
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
                fillInventory();
                fillgroups();
                fillMaterial();
                fillMovements();
            }
         private void  fillInventory()
            {
                try
                {
                    string selectedCompVal = lst_company.SelectedItem.Value;
                    List<InventoryBean> inventoryDataSource = new InventoryBean().getAllInventoryUnderCompany(selectedCompVal);
                    lst_inventory.DataSource = inventoryDataSource ;
                    lst_inventory.DataTextField="strg_name";
                    lst_inventory.DataValueField="id";
                    lst_inventory.DataBind();
                }
                catch(Exception ex)
                {
                    myLog.Error(ex);
                }
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
                    List<materialGroupBean> materialGroupDataSource = new List<materialGroupBean>();
                    using (Material_Svc svc1 = new Material_Svc())
                    {
                        materialGroupDataSource = svc1.getAllMaterialGroups(sql, parameters);
                    }

                    lst_MATERIAL_GRP.DataSource = materialGroupDataSource ;
                    lst_MATERIAL_GRP.DataTextField="NAME";
                    lst_MATERIAL_GRP.DataValueField="ID";
                    lst_MATERIAL_GRP.DataBind();
                }
                catch(Exception ex)
                {
                    myLog.Error(ex);
                }
            }
            private void fillMaterial()
            {
                try
                {
                    List<MaterialBean> materialDataSource = new List<MaterialBean>();
                    using (Material_Svc svc = new Material_Svc())
                    {
                        int grpID = int.Parse(lst_MATERIAL_GRP.SelectedItem.Value);
                        materialDataSource = svc.getAllMaterial(grpID);
                    }
                    lst_material.DataSource = materialDataSource ;
                    lst_material.DataTextField="name";
                    lst_material.DataValueField="ID";
                    lst_material.DataBind();
                }
                catch(Exception ex)
                {
                     myLog.Error(ex);
                }
            }

            private void fillMovements()
            {
                int compID = int.Parse(lst_company.SelectedValue);
                List<MovementsBean> movemenetsDataSource = new List<MovementsBean>();
                using (Movement_Svc svc1 = new Movement_Svc())
                {
                    movemenetsDataSource =  svc1.getAllMovements(compID);
                }

                lst_movmenet.DataSource = movemenetsDataSource ;
                lst_movmenet.DataTextField = MovementsBean.ddl_gui_TextLable; 
                lst_movmenet.DataValueField = MovementsBean.ddl_gui_valueLable;
                lst_movmenet.DataBind();
            }
            private bool createMaterialMovement()
            {
                bool dbOP = false ;
                try
                {
                    if(int.Parse(lst_movmenet.SelectedValue)==MaterialMovementTypeKeys.INITIAL_BALANCE)
                    {
                        MaterialCardBean initbalanace =  new MaterialCardBean();
                        initbalanace.COMP_ID =int.Parse(lst_company.SelectedValue);
                        initbalanace.FISCAL_YEAR = new FiscalBean().getIDForYear(DateTime.Now.Year);
                        initbalanace.inventory_id =int.Parse(lst_inventory.SelectedValue);
                        initbalanace.MATERIAL_ID =int.Parse(lst_material.SelectedValue);
                        initbalanace.INITIAL_QNTY =int.Parse(txt_qty.Text);
                        initbalanace.CURRENT_QNTY=int.Parse(txt_qty.Text);
                        initbalanace.INITIAL_QNTY =int.Parse(txt_qty.Text);
                       dbOP = new MaterialCardBean().createMaterialCard(initbalanace);
                    }
                }
                catch(Exception ex)
                {
                    myLog.Error(ex);
                }
                return dbOP ;
            }

            protected void btn_create_Click1(object sender, EventArgs e)
            {
               bool status =  createMaterialMovement();
                if(status)
                {
                     new AlertScript().displayAlert(this,"تم التسجيل الحركة بنجاح");
                }
                else
                {
                        new AlertScript().displayAlert(this,"فشلت العملية");
                }
            }
    }
}