using POS_ERP.com.zanon.ERP.beans;
using POS_ERP.com.zanon.ERP.database.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.database.service
{
    public class Authentication_SVC : baze.BazeClazz
    {
        public TransactionResult authonticateLogin(string userID, string password)
        {
            TransactionResult trxStatus = new TransactionResult();
            try
            {
                string sql = "select count(*) from pos.tusers where user_id=@user_id and active = 1 ";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@user_id", userID);
                parameters.Add("@password", password);
                object val = dbConn.ExecuteScalar(sql, parameters);
                if (val != null && int.Parse(val.ToString()) > 0)
                {
                    sql = "select count(*) from pos.tusr_pwd where userid in (select id from pos.tusers where user_id=@user_id ) and pwd = @pwd and active =1 ";
                    parameters = new Dictionary<string, string>();
                    parameters.Add("@user_id", userID);
                    parameters.Add("@pwd", password);
                     val = dbConn.ExecuteScalar(sql, parameters);
                     if (val != null && int.Parse(val.ToString()) > 0)
                     {
                         trxStatus.status = true;
                     }
                     else
                     {
                         trxStatus.status = false;
                         trxStatus.msg = "كلمة المرور غير صحيحه";
                     }
                }
                else
                {
                    trxStatus.status = false;
                    trxStatus.msg = "رقم المستخدم غير موجوداو غير مفعل فى النظام";
                }
            }
            catch (Exception ee)
            {
                myLog.Error(ee);
            }
            return trxStatus;
        }
        public UserProfile  FillUser(string userID)
        {
            UserProfile myProfile = new UserProfile();
            try
            {
                string sql = "select * from pos.tusers where user_id=@user_id ";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@user_id", userID);
                
                DataTable dt = dbConn.select(sql, parameters);

                myProfile.ID = dt.Rows[0]["ID"].ToString();
                myProfile.userID = dt.Rows[0]["USER_ID"].ToString();
                myProfile.Name = dt.Rows[0]["NAME"].ToString();

                sql = "select * from pos.tcompany where id in (select distinct(comp_id) " +
                    " from pos.troles where id in (select role_id from pos.trole_usr where user_id=@id))";
                parameters = new Dictionary<string, string>();
                parameters.Add("@id", myProfile.ID);
                List<CompanyBeans> company_result = new CompanyBeans().getAllCompany(sql, parameters);
                myProfile.userCompany.AddRange(company_result);

                sql = " SELECT A.ROLE_ID,OBJECT_ID,ACTION_ID , B.ID AS 'COMP_ID' FROM POS.TROLE_ACTION AS A " +
                      "  JOIN POS.TCOMPANY B ON A.ROLE_ID = B.ID " +
                      " WHERE ROLE_ID IN (SELECT ID FROM POS.TROLE_USR WHERE USER_ID = @ID)";
                parameters = new Dictionary<string, string>();
                parameters.Add("@ID", myProfile.ID);
                DataTable privilageResult = dbConn.select(sql, parameters);
                for (int i = 0; i < privilageResult.Rows.Count; i++)
                {
                    string actionID = privilageResult.Rows[i]["ACTION_ID"].ToString();
                    string objectID = privilageResult.Rows[i]["OBJECT_ID"].ToString();
                    string roleID = privilageResult.Rows[i]["ROLE_ID"].ToString();
                    string CompanyID = privilageResult.Rows[i]["COMP_ID"].ToString();
                    AuthorizationMatrixBean authBean = new AuthorizationMatrixBean();
                    authBean.actionID = int.Parse(actionID);
                    authBean.objectID = int.Parse(objectID);
                    authBean.roleID = int.Parse(roleID);
                    authBean.companyID = int.Parse(CompanyID);
                    myProfile.authirzationMatrix.Add(authBean);
                }
            }
            catch (Exception ee)
            {
                myLog.Error(ee);
            }
            return myProfile;
        }
    }
}