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
            //Label_panel4.Text = ValuesController.temprature.ToString();

            Api.Logger log = new Api.Logger();
            log.log("Visited default.aspx");
        }
    }
}