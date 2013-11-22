using System;
using System.Collections.Generic;
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
            System.Collections.IList visibleTables = RouteConfig.DefaultModel.VisibleTables;
            Menu1.DataSource = visibleTables;
            Menu1.DataBind();
        }
    }
}