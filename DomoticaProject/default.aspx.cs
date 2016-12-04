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
        ValuesController Valuescontroller = new ValuesController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label_panel4.Text = SlideBoxPanel2.Checked.ToString();
        }

        protected void SlideBoxPanel2_CheckedChanged(object sender, EventArgs e)
        {
            Label_panel4.Text = SlideBoxPanel2.Checked.ToString();
            ValuesController.valuestate = SlideBoxPanel2.Checked;
        }
    }
}