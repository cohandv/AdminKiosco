using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminKiosco.Web
{
    public partial class Administration : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Menu1.DataSource = RouteConfig.VisibleTables;
            Menu1.DataBind();
        }
    }
}