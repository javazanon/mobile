using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POS_ERP.com.zanon.ERP.database;
using MySql.Data.MySqlClient;
using System.Data;
using POS_ERP.com.zanon.ERP.config;
using POS_ERP.com.zanon.ERP.beans;
using POS_ERP.com.zanon.ERP.util;

namespace POS_ERP.pgs.home
{
    public partial class login : System.Web.UI.Page
    {
        public string ResultMessage="";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            // check login for current user and create his profile
            string userID = userNameTxt.Text;
            string password = password_txt.Text;
            string sql="select * from pos.tusers where user_id=@user_id and password=@password and active = 1 ";
            Dictionary<string,string> parameters  = new Dictionary<string,string>();
            parameters.Add("@user_id",userID);
            parameters.Add("@password",password);
            DataTable result = new ConnectionManager().select(sql,parameters);
            if(result!=null && result.Rows.Count > 0)
            {
                // here create profile for user and redirect him to home page for stat transaction
                UserProfile myProfile = new UserProfile();
                
                myProfile.ID=result.Rows[0]["ID"].ToString();
                myProfile.userID=result.Rows[0]["USER_ID"].ToString();
                myProfile.Name=result.Rows[0]["NAME"].ToString();

                sql="select * from pos.tcompany where id in (select distinct(comp_id) "+
                    " from pos.troles where id in (select role_id from pos.trole_usr where user_id=@id))";
                parameters  = new Dictionary<string,string>();
                parameters.Add("@id",myProfile.ID);
                List<CompanyBeans> company_result = new CompanyBeans().getAllCompany(sql,parameters);
                myProfile.userCompany.AddRange(company_result);

                sql = " SELECT A.ROLE_ID,OBJECT_ID,ACTION_ID , B.ID AS 'COMP_ID' FROM POS.TROLE_ACTION AS A "+
                      "  JOIN POS.TCOMPANY B ON A.ROLE_ID = B.ID "+
                      " WHERE ROLE_ID IN (SELECT ID FROM POS.TROLE_USR WHERE USER_ID = @ID)";
                parameters  = new Dictionary<string,string>();
                parameters.Add("@ID",myProfile.ID);
                DataTable privilageResult = new ConnectionManager().select(sql,parameters);
                for(int i=0;i<privilageResult.Rows.Count;i++)
                {
                    string actionID = privilageResult.Rows[i]["ACTION_ID"].ToString();
                    string objectID = privilageResult.Rows[i]["OBJECT_ID"].ToString();
                    string roleID = privilageResult.Rows[i]["ROLE_ID"].ToString();
                    string CompanyID = privilageResult.Rows[i]["COMP_ID"].ToString();
                    AuthorizationMatrixBean authBean = new AuthorizationMatrixBean();
                    authBean.actionID=int.Parse(actionID);
                    authBean.objectID=int.Parse(objectID);
                    authBean.roleID=int.Parse(roleID);
                    authBean.companyID=int.Parse(CompanyID);
                    myProfile.authirzationMatrix.Add(authBean);
                }
                Session[SessionKeys.userProfile]=myProfile ;
                Response.Redirect("~/pgs/home/index.aspx",true);
            }
            else
            {
                ResultMessage ="بيانات الدخول غير صحيحة برجاء المحاولة مرة اخرى";
                new AlertScript().displayAlert(this,ResultMessage);
            }
        }
    }
}