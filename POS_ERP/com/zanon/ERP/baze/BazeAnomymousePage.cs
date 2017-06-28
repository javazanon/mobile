using POS_ERP.com.zanon.ERP.logging;
using POS_ERP.com.zanon.ERP.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace POS_ERP.com.zanon.ERP.baze
{
    public class BazeAnomymousePage :Page ,IDisposable
    {
        public NLogLogger myLog = new NLogLogger();
        public AlertScript myScript = new AlertScript();

        void IDisposable.Dispose()
        {
            try
            {

            }
            catch (Exception ee)
            {

            }
        }
    }
}