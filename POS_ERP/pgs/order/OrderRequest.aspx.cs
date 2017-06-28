using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POS_ERP.com.zanon.ERP.beans;
using POS_ERP.com.zanon.ERP.config;
using POS_ERP.com.zanon.ERP.util;
using POS_ERP.com.zanon.ERP.logging;
using Telerik.Web.UI;
using POS_ERP.com.zanon.ERP.database;
using System.Data;
using POS_ERP.com.zanon.ERP.database.connection;
using POS_ERP.com.zanon.ERP.database.service;
using POS_ERP.com.zanon.ERP.baze;

namespace POS_ERP.pgs.order
{
    public partial class OrderRequest : BazePage
    {
        NLogLogger MyLog =  new NLogLogger();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            if(!IsPostBack)
            {
                Session[SessionKeys.shoppingCart]  = new ShoppingCart();
                fillScreen(_currentUser);
            }
            }
            catch(Exception ex)
            {
                MyLog.Error(ex);
            }
        }

         protected void ShoppingCartLineItemsNeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
          {
             try
             {
                 if(Session[SessionKeys.shoppingCart]==null)
                 {
                     Session[SessionKeys.shoppingCart]=new ShoppingCart();
                 }
                ShoppingCart shoopingCart =(ShoppingCart)Session[SessionKeys.shoppingCart]  ;
                grid_ShoppingLineItems.DataSource = shoopingCart.items;
             }
             catch(Exception ex)
             {
                 MyLog.Error(ex);
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
                fillInventory();
                fillMaterialgroups();
                fillCustomerGroups();
                fillCustomers();
                fillDeliveryMethod();
                fillMaterial();
                }
             catch(Exception ex)
              {
                 MyLog.Error(ex);
             }
            }
        private void  fillMaterialgroups()
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
                    MyLog.Error(ex);
                }
            }
         private void  fillMaterial()
            {
                try
                {
                    string selectedGrpVal = lst_MATERIAL_GRP.SelectedItem.Value;
                    string sql = " select * from pos.tmaterial where GRP_ID = @GRP_ID ";
                    Dictionary<string,string> parameters  = new Dictionary<string,string>();
                    parameters.Add("@GRP_ID",selectedGrpVal);
                    List<MaterialBean> materialDataSource = new MaterialBean().getAllMaterial(sql,parameters);

                    lst_MATERIAL.DataSource = materialDataSource ;
                    lst_MATERIAL.DataTextField="NAME";
                    lst_MATERIAL.DataValueField="ID";
                    lst_MATERIAL.DataBind();
                }
                catch(Exception ex)
                {
                    MyLog.Error(ex);
                }
            }
        //

         private void  fillDeliveryMethod()
            {
                try
                {
                    string sql = " select * from pos.tdlvr_mthod ";
                    Dictionary<string,string> parameters  = new Dictionary<string,string>();
                    List<DeliveryMethodBean> deliveyDataSource = new DeliveryMethodBean().getAllDeliveryMethod(sql,parameters);
                    lst_delivery_method.DataSource = deliveyDataSource ;
                    lst_delivery_method.DataTextField="NAME";
                    lst_delivery_method.DataValueField="ID";
                    lst_delivery_method.DataBind();
                }
                catch(Exception ex)
                {
                    MyLog.Error(ex);
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
                    MyLog.Error(ex);
                }
            }

        private void  fillCustomerGroups()
            {
                try
                {
                    string selectedCompVal = lst_company.SelectedItem.Value;
                    string sql = " SELECT * from pos.tcust_grp where COMP_ID=@cmp_id";
                    Dictionary<string,string> parameters  = new Dictionary<string,string>();
                    parameters.Add("@cmp_id",selectedCompVal);
                    List<CustomerGroupBean> custGrpsDataSource = new CustomerGroupBean().getAllCustomerGroups(sql,parameters);

                    lst_cust_grp.DataSource = custGrpsDataSource ;
                    lst_cust_grp.DataTextField="NAME";
                    lst_cust_grp.DataValueField="ID";
                    lst_cust_grp.DataBind();
                }
                catch(Exception ex)
                {
                    MyLog.Error(ex);
                }
            }
        private void  fillCustomers()
            {
                try
                {
                    string selectedCompVal = lst_cust_grp.SelectedItem.Value;
                    string sql = " SELECT * from pos.tcustomer where GRP_ID=@grp_id";
                    Dictionary<string,string> parameters  = new Dictionary<string,string>();
                    parameters.Add("@grp_id",selectedCompVal);
                    List<CustomerBean> customerDataSource = new CustomerBean().getAllCustomer(sql,parameters);

                    lst_customer.DataSource = customerDataSource ;
                    lst_customer.DataTextField="NAME";
                    lst_customer.DataValueField="ID";
                    lst_customer.DataBind();
                }
                catch(Exception ex)
                {
                    MyLog.Error(ex);
                }
            }
         protected void deleteRowFromShoopingCard_Click(object sender, EventArgs e)
        {
             try
             {
                 object selectdVal  = ((GridDataItem)grid_ShoppingLineItems.SelectedItems[0]).GetDataKeyValue("Material_id") .ToString() ;
                 if(selectdVal==null)
                 {
                     // error mesage for displaying select first row 
                      string ResultMessage ="اختر احد الاصناف لحذفها اولا";
                       new AlertScript().displayAlert(this,ResultMessage);
                 }
                 else
                 {
                    string matrialID = grid_ShoppingLineItems.SelectedValue.ToString();
                    ShoppingCart currentShoppingCart =  (ShoppingCart)Session[SessionKeys.shoppingCart];
                    ShoppingLineItemBean foundLineItem =  currentShoppingCart.items.Single(x=>x.Material_id==int.Parse(matrialID));
                    currentShoppingCart.items.Remove(foundLineItem);
                    grid_ShoppingLineItems.DataSource = currentShoppingCart.items ;
                     grid_ShoppingLineItems.Rebind();
                 }
             }
             catch(Exception ex)
             {
                 MyLog.Error(ex);
             }
             
        }
        
        protected void btn_AddItem_to_shoppingcart_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if(lst_MATERIAL.SelectedItem ==null)
                    {
                        // alertr message to choose Material
                        new AlertScript().displayAlert(this,"برجاء اختر اولا الصنف المراد اضافته");
                    }
                    if(txt_qnty.Text.Trim().Length == 0 || float.Parse(txt_qnty.Text.Trim())< 0)
                    {
                        // alertr message to choose Qanty
                        new AlertScript().displayAlert(this,"برجاء اختر الكمية المطلوبة");
                    }
                    else
                    {
                        int materialID = int.Parse(lst_MATERIAL.SelectedItem.Value.ToString());
                        float amountRequired = float.Parse(txt_qnty.Text) ;
                        ShoppingCart shoopingCart =(ShoppingCart)Session[SessionKeys.shoppingCart]  ;
                        // first check if material already added to shooping cart or not
                        bool addedBefore = shoopingCart.items.Exists(x=>x.Material_id==materialID);
                        if(addedBefore)
                        {
                            new AlertScript().displayAlert(this,"لا يمكن تكرار الصنف فى نفس الفاتورة");
                            return ;
                        }
                        // first check aviable amount in stock  
                        bool stockHaveEnough = checkAvaiableStockForMateril(amountRequired);
                        if(!stockHaveEnough)
                        {
                            new AlertScript().displayAlert(this,"لايوجد مخزون متاح من الصنف");
                            return ;
                        }
                        ShoppingLineItemBean lineItem = new ShoppingLineItemBean();
                        lineItem.Material_id = materialID;
                        lineItem.Material_name = lst_MATERIAL.SelectedItem.Text;
                        MaterialBean matrBean =  new MaterialBean().getMaterialByID(lineItem.Material_id);
                        MaterialPriceBean matrPriceBean =  new MaterialPriceBean().getCurrentMaterialPrices(lineItem.Material_id);
                        lineItem.qnty=amountRequired;
                        lineItem.unit_price= matrPriceBean.PRICE ;
                        lineItem.deduction = txt_deduction.Text.Trim().Length==0 ? 0 : float.Parse(txt_deduction.Text.Trim());
                        lineItem.totla_after_deduction = (lineItem.qnty * lineItem.unit_price ) - lineItem.deduction;
                        lineItem.totla_before_deduction = (lineItem.qnty * lineItem.unit_price )  ;
                        shoopingCart.items.Add(lineItem);
                        grid_ShoppingLineItems.DataSource = shoopingCart.items ;
                        grid_ShoppingLineItems.DataBind(); 
                    }
                }
                catch(Exception ex)
                {
                    MyLog.Error(ex);
                }
               
            }
            catch(Exception ex)
            {
            }
        }
        private bool checkAvaiableStockForMateril(float desiredamount)
        {
            bool passTransaction=false ;
            try
            {
                float amountInShoppingCart = 0 ;
                int materialID = int.Parse(lst_MATERIAL.SelectedItem.Value );
                int companyID = int.Parse(lst_company.SelectedItem.Value );
                ShoppingCart shoppingCart =(ShoppingCart)Session[SessionKeys.shoppingCart]  ;
                bool foundItem =  shoppingCart.items.Exists(x=>x.Material_id==materialID);
                
                if(foundItem)
                {
                    ShoppingLineItemBean foundItemInShoppingCart =  shoppingCart.items.Single(x=>x.Material_id==materialID);
                    amountInShoppingCart = foundItemInShoppingCart.qnty;
                }
                MaterialCardBean foundMaterialCardBean = new MaterialCardBean().getMaterialsCardByID(materialID,companyID);
                float remiaingAmount = foundMaterialCardBean.CURRENT_QNTY - (desiredamount + amountInShoppingCart) ; 
                if(remiaingAmount > 0)
                {
                    passTransaction =true;
                }
            }
            catch(Exception ex)
            {
                MyLog.Error(ex);
            }
            return passTransaction ;
        }
        protected void btn_checkStock_Click(object sender, EventArgs e)
        {
            try
            {
                 int materialID = int.Parse(lst_MATERIAL.SelectedItem.Value );
                 int companyID = int.Parse(lst_company.SelectedItem.Value );
                 MaterialCardBean foundMaterialCardBean = new MaterialCardBean().getMaterialsCardByID(materialID,companyID);
                string message = "يوجد من الصنف "+foundMaterialCardBean.MATERIAL_name+"  الكمية : "+foundMaterialCardBean.CURRENT_QNTY ;
                new AlertScript().displayAlert(this,message);
            }
            catch(Exception ex)
            {

            }
        }

        protected void btnsaveBill_clicked(object sender, EventArgs e)
        {
            try
            {
                 UserProfile currentUserProfile = (UserProfile)Session[SessionKeys.userProfile]; 
                 string currentTime = DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day ;

                 ShoppingCart shoppingCart =(ShoppingCart)Session[SessionKeys.shoppingCart]  ;
                shoppingCart.shoppingGregDate = currentTime ;
                 shoppingCart.company = new CompanyBeans().getCompanyByID(int.Parse(lst_company.SelectedValue));
                 shoppingCart.customer = new CustomerBean().getCustomerByID(int.Parse(lst_customer.SelectedValue));
                       
                 string sql = " insert into pos.tsoh (COMP_ID,CUSTOMER,FISCAL,F_PERIOD,HEADER_TXT,REFERNCE,CREATED_BY,DLVR_MTHD) values "+
                              " (@COMP_ID,@CUSTOMER,@FISCAL,@F_PERIOD,@HEADER_TXT,@REFERNCE,@CREATED_BY,@DLVR_MTHD)";
                       string COMP_ID = lst_company.SelectedValue;
                       string CUSTOMER= lst_customer.SelectedValue;
                       int FISCALYearID = new FiscalBean().getIDForYear(DateTime.Now.Year);
                       int F_PERIOD= new FiscalPeriodBean().getIDForCurrentfiscalPeriod() ;
                       string HEADER_TXT= txt_header.Text;
                       string REFERNCE= txt_refernce.Text;
                       string CREATED_BY = currentUserProfile.ID;
                       string DLVR_MTHD = lst_delivery_method.SelectedValue;
                    Dictionary<string,string> parameters  = new Dictionary<string,string>();
                     parameters.Add("@COMP_ID",COMP_ID);
                     parameters.Add("@CUSTOMER",CUSTOMER);
                     parameters.Add("@FISCAL",FISCALYearID+"");
                     parameters.Add("@F_PERIOD",F_PERIOD+"");
                     parameters.Add("@HEADER_TXT",HEADER_TXT);
                     parameters.Add("@REFERNCE",REFERNCE);
                     parameters.Add("@CREATED_BY",CREATED_BY);
                     parameters.Add("@DLVR_MTHD",DLVR_MTHD);
                     int db_status = new ConnectionManager().insertDeleteUpdate(sql,parameters);
                     if(db_status==1)
                      {
                         sql = "select max(ID)  from pos.tsoh where COMP_ID =@COMP_ID and F_PERIOD = @F_PERIOD and FISCAL=@FISCAL and CREATED_BY=@CREATED_BY";
                         parameters  = new Dictionary<string,string>();
                         parameters.Add("@COMP_ID",COMP_ID);
                         parameters.Add("@FISCAL",FISCALYearID+"");
                         parameters.Add("@F_PERIOD",F_PERIOD+"");
                         parameters.Add("@CREATED_BY",CREATED_BY);
                         DataTable result = new ConnectionManager().select(sql,parameters);
                        int orderID  = int.Parse(result.Rows[0][0].ToString());
                         shoppingCart.orderID = orderID ;
                          // start insert line items for order
                         for(int i=0;i<shoppingCart.items.Count;i++)
                         {
                        
                           ShoppingLineItemBean lineItem =  shoppingCart.items[i];
                             sql = "insert into pos.tdod (SOH_ID,LINE_NO,MATERIAL,QTY,DESCR,DISCOUNT) values "+
                                   " (@SOH_ID,@LINE_NO,@MATERIAL,@QTY,@DESCR,@DISCOUNT)" ;
                             parameters  = new Dictionary<string,string>();
                             parameters.Add("@SOH_ID",orderID+"");
                             parameters.Add("@LINE_NO",(i+1)+"");
                             parameters.Add("@MATERIAL",lineItem.Material_id+"");
                             parameters.Add("@QTY",lineItem.qnty+"");
                             parameters.Add("@DESCR","");
                             parameters.Add("@DISCOUNT",lineItem.deduction+"");
                             db_status = new ConnectionManager().insertDeleteUpdate(sql,parameters);
                         }

                         // start update table of movment
                       for(int i=0;i<shoppingCart.items.Count;i++)
                         {
                           ShoppingLineItemBean lineItem =  shoppingCart.items[i];
                           sql =  " insert into pos.tmatr_mov (comp_id,fisc_priod,mov_typ,material,qnty,descr,createdBy) values "+
                                " (@comp_id,@fisc_priod,@mov_typ,@material,@qnty,@descr,@createdBy)";
                            parameters  = new Dictionary<string,string>();
                             parameters.Add("@comp_id",COMP_ID);
                             parameters.Add("@fisc_priod",F_PERIOD+"");
                             parameters.Add("@mov_typ",+MaterialMovementTypeKeys.ORDER+"");
                             parameters.Add("@qnty",lineItem.qnty+"");
                             parameters.Add("@material",lineItem.Material_id+"");
                             parameters.Add("@descr","");
                              parameters.Add("@createdBy",CREATED_BY);
                            db_status = new ConnectionManager().insertDeleteUpdate(sql,parameters);
                         }
                      
                         
                         // start update inventory for each material
                         for(int i=0;i<shoppingCart.items.Count;i++)
                         {
                           parameters  = new Dictionary<string,string>();
                           ShoppingLineItemBean lineItem =  shoppingCart.items[i];
                           MaterialCardBean foundMaterialCard = new MaterialCardBean().getMaterialsCardByID(lineItem.Material_id,int.Parse(COMP_ID));
                             //if(foundMaterialCard.ID == 0)
                             //{
                             //    // insert record for item
                             //sql =  " insert into pos.tmatr_mov (FISCAL_YEAR,COMP_ID,inventory_id,MATERIAL_ID,INITIAL_QNTY,CURRENT_QNTY,lastupdate) values "+
                             //     " (@FISCAL_YEAR,@COMP_ID,@inventory_id,@MATERIAL_ID,@INITIAL_QNTY,@CURRENT_QNTY,@lastupdate)";
                             //    parameters.Add("@FISCAL_YEAR",FISCALYearID+"");
                             //    parameters.Add("@COMP_ID",COMP_ID);
                             //    parameters.Add("@inventory_id",lst_storage.SelectedValue);
                             //    parameters.Add("@MATERIAL_ID",lineItem.Material_id+"");
                             //    parameters.Add("@INITIAL_QNTY","0");
                             //    parameters.Add("@CURRENT_QNTY",lineItem.qnty+"");
                             //    parameters.Add("@lastupdate",currentTime);
                             //}
                             //else
                             //{
                                 sql="UPDATE pos.tmaterial_card SET "+
                                        " FISCAL_YEAR = @FISCAL_YEAR,"+
                                        " COMP_ID = @COMP_ID,"+
                                        " inventory_id = @inventory_id,"+
                                        " MATERIAL_ID = @MATERIAL_ID,"+
                                        " CURRENT_QNTY =  @CURRENT_QNTY ,"+
                                        " lastupdate = @lastupdate"+
                                        " where id=@id ";
                                 parameters.Add("@id",foundMaterialCard.ID+"");
                                 parameters.Add("@COMP_ID",COMP_ID);
                                 parameters.Add("@FISCAL_YEAR",FISCALYearID+"");
                                 parameters.Add("@inventory_id",lst_storage.SelectedValue);
                                 parameters.Add("@CURRENT_QNTY",(foundMaterialCard.CURRENT_QNTY-lineItem.qnty)+"");
                                 parameters.Add("@MATERIAL_ID",lineItem.Material_id+"");
                                 parameters.Add("@lastupdate",currentTime);
                            // }
                            db_status = new ConnectionManager().insertDeleteUpdate(sql,parameters);
                         }
                          new AlertScript().displayAlert(this,"تم تسجيل الفاتورة بنجاح");
                         Response.Redirect("~/pgs/invoices/displayInvoice.aspx") ;
                      }
                     else
                     {
                          new AlertScript().displayAlert(this,"فشلت العملية");
                     }
            }
            catch(Exception ex)
            {
                 MyLog.Error(ex);
                 new AlertScript().displayAlert(this,"فشلت العملية");
            }
        }
    }
}