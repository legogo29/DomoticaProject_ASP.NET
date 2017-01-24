using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DomoticaProject
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Api.Logger log = new Api.Logger();
            log.log("Visited logout.aspx");
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            HttpCookie CookieCookie = new HttpCookie("login_cookie");

            CookieCookie.Value = "SignedOut";
            CookieCookie.Expires = DateTime.Now.AddHours(-1.0);
            Response.Cookies.Add(CookieCookie);

            Response.Redirect("login.aspx");
        }
    }
}