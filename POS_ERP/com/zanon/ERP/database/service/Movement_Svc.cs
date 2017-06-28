using POS_ERP.com.zanon.ERP.beans;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.database.service
{
    public class Movement_Svc :baze.BazeClazz
    {
        public List<MovementsBean> getAllMovements(int cmp_id)
        {
            List<MovementsBean> movemenetsDataSource = new List<MovementsBean>();
            try
            {
              
                string sql = " select * from pos.tmv_typ where cmp_id=@cmp_id  ";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@cmp_id", cmp_id+"");

                DataTable currencyResult = dbConn.select(sql, parameters);
                for (int i = 0; i < currencyResult.Rows.Count; i++)
                {
                    MovementsBean movBean = new MovementsBean();
                    movBean.id = int.Parse(currencyResult.Rows[i]["id"].ToString());
                    movBean.code = currencyResult.Rows[i]["code"].ToString();
                    movBean.name = currencyResult.Rows[i]["name"].ToString();
                    movBean.lng_name = currencyResult.Rows[i]["lng_name"].ToString();
                    movBean.cmp_id = int.Parse(currencyResult.Rows[i]["cmp_id"].ToString());
                    movBean.positive = int.Parse(currencyResult.Rows[i]["positive"].ToString());
                    movBean.status = int.Parse(currencyResult.Rows[i]["status"].ToString());
                    movBean.ddl_gui_text = movBean.id +"";
                    movBean.ddl_gui_value = movBean.name;
                    movemenetsDataSource.Add(movBean);
                }
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
            return movemenetsDataSource;
        } 
    }
}