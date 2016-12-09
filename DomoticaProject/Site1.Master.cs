using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DomoticaProject
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userCookie"] != null)
            {
                lbl_signedInAs.Text = "Signed in as: " + Request.Cookies["userCookie"].Value;
                sidebar.InnerHtml += "<a href=\"logout.aspx\" class=\"list-group-item\">Logout</a>";

            }
        }
    }
}