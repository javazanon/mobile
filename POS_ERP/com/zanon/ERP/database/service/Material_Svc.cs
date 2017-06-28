using POS_ERP.com.zanon.ERP.beans;
using POS_ERP.com.zanon.ERP.CustomException;
using POS_ERP.com.zanon.ERP.database.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.database.service
{
    public class Material_Svc : baze.BazeClazz
    {
        public TransactionResult createItem(MaterialBean newMaterial)
        {
            TransactionResult result = new TransactionResult();
            try
            {
                materialGroupBean matrGrp = getMaterialGroupByID(newMaterial.GRP_ID);
                int nextNumber = -1;
                using (NumberRange_Svc svc1 = new NumberRange_Svc())
                {
                    nextNumber = svc1.getNextNumberInRange(matrGrp.RANGE_ID);
                }
                
                if (nextNumber > 0)
                {
                    string sql = " INSERT INTO pos.tmaterial(ID,COMP_ID,NAME,LONG_NAME,GRP_ID,MEASURE,MRP_LOW,MRP_HIGH,active)" +
                                " values (@ID,@COMP_ID,@NAME,@LONG_NAME,@GRP_ID,@MEASURE,@MRP_LOW,@MRP_HIGH,@active)";
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("@ID", nextNumber + "");
                    parameters.Add("@COMP_ID", newMaterial.COMP_ID + "");
                    parameters.Add("@NAME", newMaterial.NAME);
                    parameters.Add("@LONG_NAME", newMaterial.LONG_NAME);
                    parameters.Add("@GRP_ID", newMaterial.GRP_ID + "");
                    parameters.Add("@MEASURE", newMaterial.MEASURE + "");
                    parameters.Add("@MRP_LOW", newMaterial.MRP_LOW + "");
                    parameters.Add("@MRP_HIGH", newMaterial.MRP_HIGH + "");
                    parameters.Add("@active", "1");
                    int dbStatus = dbConn.insertDeleteUpdate(sql, parameters);
                    if (dbStatus> 0)
                    {
                       
                        result.status=true;
                        result.val = nextNumber+"";
                        result.msg = "تم انشاء الصنف " + nextNumber + " بنجاح";
                    }
                    else
                    {
                        string msg =" فشلت عمليه انشاء صنف جديد السبب : " + dbConn.msg;
                        throw new POS_Business_Exception(msg);
                    }
                }
                else
                {
                    myLog.Error("حدث خطا فى تسلسل الارقام للاصناف فى المخزن ");
                }
            }
            catch (Exception ex)
            {
                result.status = false;
                result.val =  "";
                result.msg = ex.Message;
                myLog.Error(ex);
            }
            return result;
        }
        public List<materialGroupBean> getAllMaterialGroups(string sselectedGrpVal)
        {
            List<materialGroupBean> mat_grp_dataSource = new List<materialGroupBean>();
            try
            {
                string sql = " select * from pos.tmaterial where GRP_ID = @GRP_ID ";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@GRP_ID", sselectedGrpVal);

                DataTable currencyResult = dbConn.select(sql, parameters);
                for (int i = 0; i < currencyResult.Rows.Count; i++)
                {
                    materialGroupBean matr_grp_Bean = new materialGroupBean();
                    matr_grp_Bean.ID = int.Parse(currencyResult.Rows[i]["id"].ToString());
                    matr_grp_Bean.NAME = currencyResult.Rows[i]["name"].ToString();
                    matr_grp_Bean.LONG_NAME = currencyResult.Rows[i]["long_name"].ToString();
                    matr_grp_Bean.RANGE_ID = int.Parse(currencyResult.Rows[i]["RANGE_ID"].ToString());
                    mat_grp_dataSource.Add(matr_grp_Bean);
                }
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
            return mat_grp_dataSource;
        }
        public materialGroupBean getMaterialGroupByID(int matrGrpID)
        {
            materialGroupBean Materialgroup = new materialGroupBean();
            try
            {
                string sql = " select * from pos.tmatr_grp where ID=@ID";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                parameter.Add("@ID", matrGrpID + "");
                DataTable dtResult = dbConn.select(sql, parameter);
                if (dtResult.Rows.Count>0)
                {
                    Materialgroup.ID = int.Parse(dtResult.Rows[0]["ID"].ToString());
                    Materialgroup.NAME = dtResult.Rows[0]["NAME"].ToString();
                    Materialgroup.LONG_NAME = dtResult.Rows[0]["LONG_NAME"].ToString();
                    Materialgroup.CMP_ID = int.Parse(dtResult.Rows[0]["CMP_ID"].ToString());
                    Materialgroup.RANGE_ID = int.Parse(dtResult.Rows[0]["RANGE_ID"].ToString());
                }
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
            return Materialgroup;
        }

        public List<MaterialBean> getAllMaterial(int grp_id)
        {
            List<MaterialBean> materialDataSource = new List<MaterialBean>();
            try
            {
                string sql = "SELECT * FROM pos.tmaterial where GRP_ID=@grp_id  ";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@grp_id", grp_id + "");
                DataTable currencyResult = dbConn.select(sql, parameters);
                for (int i = 0; i < currencyResult.Rows.Count; i++)
                {
                    MaterialBean matrBean = new MaterialBean();
                    matrBean.ID = int.Parse(currencyResult.Rows[i]["ID"].ToString());
                    matrBean.NAME = currencyResult.Rows[i]["NAME"].ToString();
                    matrBean.LONG_NAME = currencyResult.Rows[i]["LONG_NAME"].ToString();
                    matrBean.MEASURE = int.Parse(currencyResult.Rows[i]["MEASURE"].ToString());
                    matrBean.MRP_LOW = int.Parse(currencyResult.Rows[i]["MRP_LOW"].ToString());
                    matrBean.MRP_HIGH = int.Parse(currencyResult.Rows[i]["MRP_HIGH"].ToString());
                    matrBean.GRP_ID = int.Parse(currencyResult.Rows[i]["GRP_ID"].ToString());
                    matrBean.ddl_gui_text = matrBean.NAME + "";
                    matrBean.ddl_gui_value = matrBean.ID + "";
                    materialDataSource.Add(matrBean);
                }
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
            return materialDataSource;
        }
        public MaterialBean getMaterialByID(int materialID)
        {
            MaterialBean matrBean = new MaterialBean();
            try
            {
                string sql = " select * from pos.tmaterial where ID = @material_id ";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@material_id", materialID + "");
                DataTable currencyResult = dbConn.select(sql, parameters);
                for (int i = 0; i < currencyResult.Rows.Count; i++)
                {
                    matrBean.ID = int.Parse(currencyResult.Rows[i]["ID"].ToString());
                    matrBean.NAME = currencyResult.Rows[i]["NAME"].ToString();
                    matrBean.LONG_NAME = currencyResult.Rows[i]["LONG_NAME"].ToString();
                    matrBean.MEASURE = int.Parse(currencyResult.Rows[i]["MEASURE"].ToString());
                    matrBean.MRP_LOW = int.Parse(currencyResult.Rows[i]["MRP_LOW"].ToString());
                    matrBean.MRP_HIGH = int.Parse(currencyResult.Rows[i]["MRP_HIGH"].ToString());
                    matrBean.GRP_ID = int.Parse(currencyResult.Rows[i]["GRP_ID"].ToString());
                    matrBean.ddl_gui_text = matrBean.NAME + "";
                    matrBean.ddl_gui_value = matrBean.ID + "";
                }
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
            return matrBean;
        } 
    }
}