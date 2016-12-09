﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DomoticaProject
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            HttpCookie CookieCookie = new HttpCookie("userCookie");

            CookieCookie.Value = UserName.Text;
            CookieCookie.Expires = DateTime.Now.AddHours(1.0);
            Response.Cookies.Add(CookieCookie);

            Response.Redirect("default.aspx");
        }
    }
}