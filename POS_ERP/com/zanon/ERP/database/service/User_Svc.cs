using POS_ERP.com.zanon.ERP.baze;
using POS_ERP.com.zanon.ERP.database.connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.database.service
{
    public class User_Svc : BazeClazz
    {
        public bool checkLogin(string userID, string password)
        {
            bool isValidUser =  false ;
            try
            {
              
                string sql = "select * from pos.tusers where user_id=@user_id and password=@password and active = 1 ";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@user_id", userID);
                parameters.Add("@password", password);
                DataTable result = new ConnectionManager().select(sql, parameters);
            }
            catch (Exception ex)
            {
              
            }
            return isValidUser;
        }
    }
}