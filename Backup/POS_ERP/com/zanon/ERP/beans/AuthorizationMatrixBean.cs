using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.beans
{
    [Serializable]
    public class AuthorizationMatrixBean
    {
        public int companyID;
        public int actionID;
        public int objectID;
        public int roleID;
    }
}