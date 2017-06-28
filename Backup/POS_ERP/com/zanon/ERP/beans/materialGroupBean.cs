using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.logging;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class materialGroupBean
    {
        public int ID {get;set;}
        public int CMP_ID {get;set;}
        public string NAME {get;set;}
        public string LONG_NAME {get;set;}
        public int RANGE_ID {get;set;}
        NLogLogger myLog = new NLogLogger();
        public List<materialGroupBean> getAllMaterialGroups(string sql ,  Dictionary<string,string> parameters)
        {
            List<materialGroupBean> mat_grp_dataSource = new List<materialGroupBean>();
            try
            {
              DataTable currencyResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<currencyResult.Rows.Count;i++)
                    {
                        materialGroupBean matr_grp_Bean = new materialGroupBean();
                        matr_grp_Bean.ID =  int.Parse(currencyResult.Rows[i]["id"].ToString());
                        matr_grp_Bean.NAME =  currencyResult.Rows[i]["name"].ToString();
                        matr_grp_Bean.LONG_NAME =  currencyResult.Rows[i]["long_name"].ToString();
                        matr_grp_Bean.RANGE_ID = int.Parse(currencyResult.Rows[i]["RANGE_ID"].ToString());
                        mat_grp_dataSource.Add(matr_grp_Bean);
                    }
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
            return mat_grp_dataSource ;
        }
      public materialGroupBean getMaterialGroupByID(int id)
        {
            materialGroupBean Materialgroup = new materialGroupBean();
            try
            {
                string sql = " select * from pos.tmatr_grp where ID=@ID" ;
                Dictionary<string,string> parameter = new   Dictionary<string,string>(); 
                parameter.Add("@ID",id+"");
                List<materialGroupBean> result = getAllMaterialGroups(sql,parameter);
                Materialgroup = result[0];
            }
            catch(Exception ex)
            {
               myLog.Error(ex);
            }
            return Materialgroup ;
        }
    }
}