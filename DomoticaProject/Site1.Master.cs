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
            switch(Parent.Page.AppRelativeVirtualPath)
            {
                case "~/default.aspx":
                    HL_home.CssClass += " active";
                    break;
                case "~/login.aspx":
                case "~/logout.aspx":
                    HL_account.CssClass += " active";
                    break;
                case "~/house.aspx":
                    HL_house.CssClass += " active";
                    break;
                case "~/games.aspx":
                    HL_games.CssClass += " active";
                    break;
                case "~/settings.aspx":
                    HL_settings.CssClass += " active";
                    break;
                default:
                    break;
            }
            if (Request.Cookies["login_cookie"] != null)
            {
                lbl_signedInAs.Text = "Ingelogd als: " + Request.Cookies["login_cookie"].Values["display_name"];
                HL_account.NavigateUrl = "logout.aspx";
                HL_account.Text = "Logout";

            }
            HttpCookie styleCookie = Request.Cookies["styleCookie"];
            if (styleCookie != null)
            {
                switch (int.Parse(styleCookie.Value))
                {
                    case 1:
                        bootstrapStyle.Attributes["href"] = "http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css";
                        customStyle.Attributes["href"] = "style/Max.css";
                        break;
                    case 2:
                        bootstrapStyle.Attributes["href"] = "http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css";
                        customStyle.Attributes["href"] = "style/Tim.css";
                        break;
                    case 3:
                        bootstrapStyle.Attributes["href"] = "https://maxcdn.bootstrapcdn.com/bootswatch/3.3.7/paper/bootstrap.min.css";
                        customStyle.Attributes["href"] = "style/bootswatch/paper.css";
                        break;
                    case 4:
                        bootstrapStyle.Attributes["href"] = "https://maxcdn.bootstrapcdn.com/bootswatch/3.3.7/superhero/bootstrap.min.css";
                        customStyle.Attributes["href"] = "style/bootswatch/superhero.css";
                        break;
                    case 5:
                        bootstrapStyle.Attributes["href"] = "https://maxcdn.bootstrapcdn.com/bootswatch/3.3.7/darkly/bootstrap.min.css";
                        customStyle.Attributes["href"] = "style/bootswatch/darkly.css";
                        break;
                    case 6:
                        bootstrapStyle.Attributes["href"] = "https://maxcdn.bootstrapcdn.com/bootswatch/3.3.7/flatly/bootstrap.min.css";
                        customStyle.Attributes["href"] = "style/bootswatch/flatly.css";
                        break;
                    default:
                        bootstrapStyle.Attributes["href"] = "http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css";
                        customStyle.Attributes["href"] = "";
                        break;
                }
            }
        }


        protected void Btn_Settings_Click(object sender, EventArgs e)
        {

        }
    }
}