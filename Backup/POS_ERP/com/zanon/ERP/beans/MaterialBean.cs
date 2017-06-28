using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.logging;
using POS_ERP.com.zanon.ERP.config;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class MaterialBean
    {
        public int ID {get;set;}
        public int COMP_ID {get;set;}
        public string NAME {get;set;}
        public string LONG_NAME {get;set;}
        public int GRP_ID {get;set;}
        public int MEASURE {get;set;}
        public float MRP_LOW {get;set;}
        public float MRP_HIGH {get;set;}
        public DateTime CREATE_DATE {get;set;}
        NLogLogger myLog = new NLogLogger();
       public List<MaterialBean> getAllMaterial(string sql ,  Dictionary<string,string> parameters)
        {
            List<MaterialBean> materialDataSource = new List<MaterialBean>();
            try
            {
              DataTable currencyResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<currencyResult.Rows.Count;i++)
                    {
                        MaterialBean matrBean = new MaterialBean();
                        matrBean.ID =  int.Parse(currencyResult.Rows[i]["ID"].ToString());
                        matrBean.NAME =  currencyResult.Rows[i]["NAME"].ToString();
                        matrBean.LONG_NAME =  currencyResult.Rows[i]["LONG_NAME"].ToString();
                        matrBean.MEASURE =  int.Parse(currencyResult.Rows[i]["MEASURE"].ToString());
                        matrBean.MRP_LOW =  int.Parse(currencyResult.Rows[i]["MRP_LOW"].ToString());
                        matrBean.MRP_HIGH =  int.Parse(currencyResult.Rows[i]["MRP_HIGH"].ToString());
                        matrBean.GRP_ID =  int.Parse(currencyResult.Rows[i]["GRP_ID"].ToString());
                        materialDataSource.Add(matrBean);
                    }
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
            return materialDataSource ;
        }
        public MaterialBean getMaterialByID(int materialID)
        {
             MaterialBean matrBean = new MaterialBean();
            try
            {
                  string sql = " select * from pos.tmaterial where ID = @material_id ";
                  Dictionary<string,string> parameters  = new Dictionary<string,string>();
                  parameters.Add("@material_id",materialID+"");
                  List<MaterialBean> materialDataSource =  getAllMaterial(sql,parameters);
                  matrBean = materialDataSource[0];
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
            return matrBean ;
        } 
        public bool createItem(MaterialBean newMaterial)
        {
            bool result =false; 
            try
            {
               materialGroupBean matrGrp = new materialGroupBean().getMaterialGroupByID(newMaterial.GRP_ID);
               int nextNumber = new NumberRangeBeans().getNextNumberInRange(matrGrp.RANGE_ID);
                    if(nextNumber>0)
                    {
                    string sql =" INSERT INTO pos.tmaterial(ID,COMP_ID,NAME,LONG_NAME,GRP_ID,MEASURE,MRP_LOW,MRP_HIGH,active)"+
                                " values (@ID,@COMP_ID,@NAME,@LONG_NAME,@GRP_ID,@MEASURE,@MRP_LOW,@MRP_HIGH,@active)";
                     Dictionary<string,string> parameters  = new Dictionary<string,string>();
                    parameters.Add("@ID",nextNumber+"");
                    parameters.Add("@COMP_ID",newMaterial.COMP_ID+"");
                    parameters.Add("@NAME",newMaterial.NAME);
                    parameters.Add("@LONG_NAME",newMaterial.LONG_NAME);
                    parameters.Add("@GRP_ID",newMaterial.GRP_ID+"");
                    parameters.Add("@MEASURE",newMaterial.MEASURE+"");
                    parameters.Add("@MRP_LOW",newMaterial.MRP_LOW+"");
                    parameters.Add("@MRP_HIGH",newMaterial.MRP_HIGH+"");
                    parameters.Add("@active","1");
                    int dbStatus = new ConnectionManager().insertDeleteUpdate(sql,parameters);
                    if(dbStatus==1)
                    {
                        result = true ;
                    }
                }
                else
                {
                    myLog.Error("حدث خطا فى تسلسل الارقام للاصناف فى المخزن ");
                }
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
             return result ;
        }
    }
}