using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.beans
{
    [Serializable]
    public class UserProfile
    {
        public string loginDate;
        public string ID;
        public string userID;
        public string Name;
        public string IDNUMBER;
        public string PHONE;
        public string ADDRESS;
        public string fullName;
        public List<AuthorizationMatrixBean> authirzationMatrix =  new List<AuthorizationMatrixBean>();
        public List<CompanyBeans> userCompany =  new List<CompanyBeans>();
    }
}