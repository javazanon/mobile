using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.database.service
{
    public class NumberRange_Svc : baze.BazeClazz
    {
        public int getNextNumberInRange(int rng_id)
        {
            int nextID = -1;
            try
            {
                string sql = " select *  from pos.tnumb_rng where ID =@rng_id  ";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@rng_id", rng_id + "");

                DataTable result = dbConn.select(sql, parameters);
                if (result.Rows.Count > 0)
                {
                    int id = int.Parse(result.Rows[0]["ID"].ToString());
                    int toRange = int.Parse(result.Rows[0]["to"].ToString());
                    int current = int.Parse(result.Rows[0]["current"].ToString());
                    int tempID = current + 1;
                    if (tempID <= toRange)
                    {
                        sql = " update pos.tnumb_rng set current = @current where ID = @ID";
                        parameters = new Dictionary<string, string>();
                        parameters.Add("@ID", id + "");
                        parameters.Add("@current", tempID + "");
                        int dbStatus = dbConn.insertDeleteUpdate(sql, parameters);
                        if (dbStatus == 1)
                        {
                            nextID = tempID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
            return nextID;
        }
    }
}