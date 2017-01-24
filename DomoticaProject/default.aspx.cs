using DomoticaProject.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DomoticaProject
{
    public partial class _default : System.Web.UI.Page
    {
        ValuesController ValuesController = new ValuesController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Api.Logger log = new Api.Logger();
            log.log("Visited default.aspx");

            if (Request.Cookies["login_cookie"] != null)
            {
                Label_displayName.Text = "Uw display name is " + Request.Cookies["login_cookie"].Values["display_name"];
                Label_email.Text = "Uw email is " + Request.Cookies["login_cookie"].Values["email"];

            }
        }
    }
}