using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using POS_ERP.com.zanon.ERP.logging;
using System.Collections;
namespace POS_ERP.com.zanon.ERP.database
{
    public class ConnectionManager
    {
        NLogLogger myLog = new NLogLogger();
        public string connStr = "";
        public MySql.Data.MySqlClient.MySqlConnection currentConnection;
        public ConnectionManager()
        {
            connStr = ConfigurationManager.AppSettings["pos_con"];
        }
        private MySqlConnection getConnection()
        {
            try
            {
             currentConnection = new MySqlConnection(connStr);
             currentConnection.Open();
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
             return currentConnection ;
        }
        private MySqlConnection closeConnection()
        {
            try
            {
                currentConnection.Close();
                currentConnection.Dispose();
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
             return currentConnection ;
        }

         public DataTable select(string query, Dictionary<string,string> parameters )
          {
               MySqlDataAdapter adapter = new MySqlDataAdapter();
               MySqlCommand cmd =   new MySqlCommand(query, getConnection());
               IList keys =  parameters.Keys.ToList();
               for(int i=0;i<keys.Count;i++)
                 {
                     string parameterKey = keys[i].ToString();
                     string parameterValue = parameters[parameterKey];
                     cmd.Parameters.Add(new MySqlParameter(parameterKey,parameterValue));
                 }
              adapter.SelectCommand = cmd ;
               DataTable myDataTable = new DataTable();
               try
               {
                adapter.Fill(myDataTable);
               }
               catch(Exception ex)
               {
                   myLog.Error(ex);
                   System.Console.Out.WriteLine("Error executing sql reason :"+ex.Message);
               }
               finally
               {
                   closeConnection();
               }
 
               return myDataTable;
          } 
        public int insertDeleteUpdate(string query, Dictionary<string,string> parameters )
          {
              int result = -1;
            try
            {
               MySqlCommand cmd =   new MySqlCommand(query, getConnection());
               IList keys =  parameters.Keys.ToList();
               for(int i=0;i<keys.Count;i++)
                 {
                     string parameterKey = keys[i].ToString();
                     string parameterValue = parameters[parameterKey];
                     cmd.Parameters.Add(new MySqlParameter(parameterKey,parameterValue));
                 }
             result = cmd.ExecuteNonQuery();
            } 
               catch(Exception ex)
               {
                   myLog.Error(ex);
                   System.Console.Out.WriteLine("Error executing sql reason :"+ex.Message);
               }
               finally
               {
                   closeConnection();
               }
 
               return result;
          } 
    }
}