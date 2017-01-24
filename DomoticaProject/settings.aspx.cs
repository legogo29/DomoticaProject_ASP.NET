using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DomoticaProject
{
    public partial class settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Api.Logger log = new Api.Logger();
            log.log("Visited settings.aspx");

            if (!IsPostBack)
            {
                HttpCookie styleCookie = Request.Cookies["styleCookie"];
                if (styleCookie != null)
                {
                    DDL_basestyle.SelectedIndex = int.Parse(styleCookie.Value);
                }
            }
        }

        protected void DDL_basestyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie styleCookie = new HttpCookie("styleCookie");

            styleCookie.Value = DDL_basestyle.SelectedIndex.ToString();

            styleCookie.Expires = DateTime.Now.AddYears(10);
            Response.Cookies.Add(styleCookie);

            Response.Redirect("settings.aspx");
        }
    }
}