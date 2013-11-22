using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminKiosco.Web.Account
{
    public static class RoleHelper
    {

        public static bool CanEdit(string TableName)
        {
            return true;
        }

        public static bool CanDelete(string TableName)
        {
            return true;
        }
    }
}