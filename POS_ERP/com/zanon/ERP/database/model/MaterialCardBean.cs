using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.logging;
using POS_ERP.com.zanon.ERP.database.connection;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class MaterialCardBean
    {
        public int ID {get;set;}
        public int FISCAL_YEAR {get;set;}
        public int COMP_ID {get;set;}
        public int inventory_id {get;set;}
        public int MATERIAL_ID {get;set;}
        public string MATERIAL_name {get;set;}
        public float INITIAL_QNTY {get;set;}
        public float CURRENT_QNTY {get;set;}
        public float MRP_LOW {get;set;}
        public float MRP_HIGH {get;set;}
        public DateTime CREATE_DATE {get;set;}
        public DateTime lastupdate {get;set;}
        NLogLogger myLog = new NLogLogger(); 
        public List<MaterialCardBean> getMaterialsCard(string sql ,  Dictionary<string,string> parameters)
        {
            List<MaterialCardBean> material_card_dataSource = new List<MaterialCardBean>();
            try
            {
                 string material_sql = " select * from pos.tmaterial where comp_id  = @cmp_id ";
                 Dictionary<string,string> material_parameters  = new Dictionary<string,string>();
                 material_parameters.Add("@cmp_id",parameters["@cmp_id"]);
                 List<MaterialBean> materialsResult = new MaterialBean().getAllMaterial(material_sql,material_parameters);
                 DataTable materialCardResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<materialCardResult.Rows.Count;i++)
                    {
                        MaterialCardBean matr_card_Bean = new MaterialCardBean();
                        matr_card_Bean.ID =  int.Parse(materialCardResult.Rows[i]["ID"].ToString());
                        matr_card_Bean.FISCAL_YEAR =  int.Parse(materialCardResult.Rows[i]["FISCAL_YEAR"].ToString());
                        matr_card_Bean.COMP_ID =  int.Parse(materialCardResult.Rows[i]["COMP_ID"].ToString());
                        matr_card_Bean.inventory_id =  int.Parse(materialCardResult.Rows[i]["inventory_id"].ToString());
                        matr_card_Bean.MATERIAL_ID =  int.Parse(materialCardResult.Rows[i]["MATERIAL_ID"].ToString());
                        matr_card_Bean.INITIAL_QNTY =  int.Parse(materialCardResult.Rows[i]["INITIAL_QNTY"].ToString());
                        matr_card_Bean.CURRENT_QNTY =  int.Parse(materialCardResult.Rows[i]["CURRENT_QNTY"].ToString());
                        matr_card_Bean.MATERIAL_name = materialsResult.Single(x=>x.ID==matr_card_Bean.MATERIAL_ID).NAME;
                        matr_card_Bean.MRP_LOW = materialsResult.Single(x=>x.ID==matr_card_Bean.MATERIAL_ID).MRP_LOW;
                        matr_card_Bean.MRP_HIGH = materialsResult.Single(x=>x.ID==matr_card_Bean.MATERIAL_ID).MRP_HIGH;
                        matr_card_Bean.CREATE_DATE =  DateTime.Parse(materialCardResult.Rows[i]["CREATE_DATE"].ToString());
                        matr_card_Bean.lastupdate = DateTime.Parse(materialCardResult.Rows[i]["lastupdate"].ToString());
                        material_card_dataSource.Add(matr_card_Bean);
                    }
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
            return material_card_dataSource ;
        }

        public MaterialCardBean getMaterialsCardByID(int materialID,int cmpID)
        {
           MaterialCardBean material_card_dataSource = new MaterialCardBean ();
            try
            {
                 string sql = " select * from pos.tmaterial_card where MATERIAL_ID  = @MATERIAL_ID ";
                 Dictionary<string,string> parameters  = new Dictionary<string,string>();
                 parameters.Add("@MATERIAL_ID",materialID+"");
                 parameters.Add("@cmp_id",cmpID+"");
                 List<MaterialCardBean> foundMaterialCard =  getMaterialsCard(sql,parameters);
                 material_card_dataSource = foundMaterialCard[0];
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
            return material_card_dataSource ;
        }

        public bool createMaterialCard(MaterialCardBean newMatrCard)
        {
            bool created = false ;
            try
            {
                      // check if init balancefor item created before or not
                     Dictionary<string,string> parameters  = new Dictionary<string,string>();
                      string sql = " select * from pos.tmaterial_card where FISCAL_YEAR = @FISCAL_YEAR "+
                                   " and COMP_ID = @COMP_ID and inventory_id = @inventory_id and MATERIAL_ID = @MATERIAL_ID";
                        parameters.Add("@FISCAL_YEAR",newMatrCard.FISCAL_YEAR+"");
                        parameters.Add("@COMP_ID",newMatrCard.COMP_ID+"");
                        parameters.Add("@inventory_id",newMatrCard.inventory_id+"");
                        parameters.Add("@MATERIAL_ID",newMatrCard.MATERIAL_ID+"");
                      DataTable result = new ConnectionManager().select(sql,parameters);
                     if(result.Rows.Count==0)
                     {
                          parameters  = new Dictionary<string,string>();
                          sql = "INSERT INTO pos.tmaterial_card(FISCAL_YEAR,COMP_ID,inventory_id,"+
                              " MATERIAL_ID,INITIAL_QNTY,CURRENT_QNTY) values "+
                              " (@FISCAL_YEAR,@COMP_ID,@inventory_id,@MATERIAL_ID,@INITIAL_QNTY,@CURRENT_QNTY)" ;
                        parameters.Add("@FISCAL_YEAR",newMatrCard.FISCAL_YEAR+"");
                        parameters.Add("@COMP_ID",newMatrCard.COMP_ID+"");
                        parameters.Add("@inventory_id",newMatrCard.inventory_id+"");
                        parameters.Add("@MATERIAL_ID",newMatrCard.MATERIAL_ID+"");
                        parameters.Add("@INITIAL_QNTY",newMatrCard.INITIAL_QNTY+"");
                        parameters.Add("@CURRENT_QNTY",newMatrCard.CURRENT_QNTY+"");
                        int dbStatus = new ConnectionManager().insertDeleteUpdate(sql,parameters);
                        if(dbStatus==1)
                        {
                            created = true ;
                        }
                     }
                     else
                     {
                         myLog.Error("تم تسجيل الرصيد الافتتاحى ولا يمكن تسجيله مره اخرى");
                     }
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
            return created ;
        }
    }
}