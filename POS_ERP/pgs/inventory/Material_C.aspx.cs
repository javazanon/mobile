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
using POS_ERP.com.zanon.ERP.baze;
using POS_ERP.com.zanon.ERP.database.service;
using POS_ERP.com.zanon.ERP.database.model;

namespace POS_ERP.pgs.inventory
{
    public partial class Material_C : BazePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    fillScreen();
                }
            }
            catch (Exception ee)
            {
                myLog.Error(ee);
            }

        }

        private void fillScreen()
        {
            try
            {

                List<CompanyBeans> userCompanyDataSource = _currentUser.userCompany;
                lst_company.DataSource = userCompanyDataSource;
                lst_company.DataTextField = "cmp_code";
                lst_company.DataValueField = "id";
                lst_company.DataBind();
                fillMaterialGroup();
                fillMeasures();
                txt_mrp_low.Text = "0";
                txt_mrp_high.Text = "100";
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
        }

        protected void lst_company_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                fillMaterialGroup();
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
        }

        private void fillMaterialGroup()
        {
            try
            {
                string selectedCompVal = lst_company.SelectedItem.Value;
                string sql = " select * from pos.tmatr_grp  where cmp_id = @cmp_id ";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@cmp_id", selectedCompVal);
                List<materialGroupBean> materialGroupDataSource = new List<materialGroupBean>();
                using (Material_Svc svc1 = new Material_Svc())
                {
                    materialGroupDataSource = svc1.getAllMaterialGroups(sql, parameters);
                }

                lst_matr_grp.DataSource = materialGroupDataSource;
                lst_matr_grp.DataTextField = "name";
                lst_matr_grp.DataValueField = "ID";
                lst_matr_grp.DataBind();
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
        }

        private void fillMeasures()
        {
            try
            {
                string sql = " select * from pos.tmeasure ";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                List<MeasureBean> measuresDataSource = new MeasureBean().getAllMeasures(sql, parameters);
                lst_measure.DataSource = measuresDataSource;
                lst_measure.DataTextField = "long_name";
                lst_measure.DataValueField = "ID";
                lst_measure.DataBind();
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
        }
        private TransactionResult createMaterial()
        {
            TransactionResult result = new TransactionResult();
            try
            {
                MaterialBean newMaterial = new MaterialBean();
                newMaterial.COMP_ID = int.Parse(lst_company.SelectedValue);
                newMaterial.GRP_ID = int.Parse(lst_matr_grp.SelectedValue);
                newMaterial.LONG_NAME = txt_material_longname.Text;
                newMaterial.MEASURE = int.Parse(lst_measure.SelectedValue);
                newMaterial.MRP_HIGH = int.Parse(txt_mrp_high.Text);
                newMaterial.MRP_LOW = int.Parse(txt_mrp_low.Text);
                newMaterial.NAME = txt_materialname.Text;
                using (Material_Svc svc = new Material_Svc())
                {
                    result = svc.createItem(newMaterial);
                }
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
            return result;
        }

        protected void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                TransactionResult result = createMaterial();
                if (result.status)
                {
                    myScript.displayAlert(this, "تم انشاء الصنف بنجاح");
                }
                else
                {
                    myScript.displayAlert(this, "فشلت العملية");
                }
            }
            catch (Exception ee)
            {
                myLog.Error(ee);
            }
        }
    }
}