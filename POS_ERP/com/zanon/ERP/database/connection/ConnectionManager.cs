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
using System.Threading.Tasks;
using POS_ERP.com.zanon.ERP.baze;

namespace POS_ERP.com.zanon.ERP.database.connection
{
    public class ConnectionManager 
    {
        NLogLogger myLog = new NLogLogger();
        public string connStr = "";
        public MySqlConnection currentConnection;
        public string msg { get; set; }
        public ConnectionManager()
        {
            connStr = ConfigurationManager.AppSettings["pos_con"];
        }
        private MySqlConnection getConnection()
        {
            try
            {
                if (currentConnection == null)
                {
                    currentConnection = new MySqlConnection(connStr);
                }
                if (!(currentConnection.State == ConnectionState.Open))
                {
                    currentConnection.Open();
                }
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
            return currentConnection;
        }
        private void closeConnection()
        {
            try
            {
                currentConnection.Close();
                currentConnection.Dispose();
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
        }

        public DataTable select(string query, Dictionary<string, string> parameters)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand(query, getConnection());
            IList keys = parameters.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                string parameterKey = keys[i].ToString();
                string parameterValue = parameters[parameterKey];
                cmd.Parameters.Add(new MySqlParameter(parameterKey, parameterValue));
            }
            adapter.SelectCommand = cmd;
            DataTable myDataTable = new DataTable();
            try
            {
                adapter.Fill(myDataTable);
            }
            catch (Exception ex)
            {
                string msg = "Error executing sql reason :" + ex.Message;
                myLog.Error(ex);
            }
            finally
            {
                closeConnection();
            }

            return myDataTable;
        }
        public object ExecuteScalar(string query, Dictionary<string, string> parameters)
        {
            object val = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, getConnection());
                IList keys = parameters.Keys.ToList();
                for (int i = 0; i < keys.Count; i++)
                {
                    string parameterKey = keys[i].ToString();
                    string parameterValue = parameters[parameterKey];
                    cmd.Parameters.Add(new MySqlParameter(parameterKey, parameterValue));
                }
                val = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                string msg = "Error executing sql reason :" + ex.Message;
                myLog.Error(ex);
            }
            finally
            {
                closeConnection();
            }

            return val;
        }

        public MySqlTransaction startTransaction()
        {
            MySqlTransaction trx = null;
            try
            {
                trx = getConnection().BeginTransaction();
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
            return trx;
        }
        public async Task<DataTable> selectAsynch(string query, Dictionary<string, string> parameters)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand(query, getConnection());
            IList keys = parameters.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                string parameterKey = keys[i].ToString();
                string parameterValue = parameters[parameterKey];
                cmd.Parameters.Add(new MySqlParameter(parameterKey, parameterValue));
            }
            adapter.SelectCommand = cmd;
            DataTable myDataTable = new DataTable();
            try
            {
                adapter.Fill(myDataTable);
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
                System.Console.Out.WriteLine("Error executing sql reason :" + ex.Message);
            }
            finally
            {
                closeConnection();
            }

            return myDataTable;
        }

        public int insertDeleteUpdateTrx(string query, Dictionary<string, string> parameters, MySqlTransaction trx)
        {
            int result = -1;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, getConnection(),trx);
                IList keys = parameters.Keys.ToList();
                for (int i = 0; i < keys.Count; i++)
                {
                    string parameterKey = keys[i].ToString();
                    string parameterValue = parameters[parameterKey];
                    cmd.Parameters.Add(new MySqlParameter(parameterKey, parameterValue));
                }
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
                System.Console.Out.WriteLine("Error executing sql reason :" + ex.Message);
            }
           
            return result;
        }
        public int insertDeleteUpdate(string query, Dictionary<string, string> parameters)
        {
            int result = -1;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, getConnection());
                IList keys = parameters.Keys.ToList();
                for (int i = 0; i < keys.Count; i++)
                {
                    string parameterKey = keys[i].ToString();
                    string parameterValue = parameters[parameterKey];
                    cmd.Parameters.Add(new MySqlParameter(parameterKey, parameterValue));
                }
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
                System.Console.Out.WriteLine("Error executing sql reason :" + ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return result;
        }

        public void Dispose()
        {
            try
            {
                closeConnection();
                GC.Collect();
            }
            catch (Exception ex)
            {
                myLog.Error(ex);
            }
        }
    }
}