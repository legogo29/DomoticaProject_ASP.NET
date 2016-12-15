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
            if (!IsPostBack)
            {
                SlideBoxPanel2_1.Checked = Convert.ToBoolean(ValuesController.valuestate[0]);
                SlideBoxPanel2_2.Checked = Convert.ToBoolean(ValuesController.valuestate[1]);
                SlideBoxPanel2_3.Checked = Convert.ToBoolean(ValuesController.valuestate[2]);
            }
        }

        protected void SlideBoxPanel2_CheckedChanged(object sender, EventArgs e)
        {
            //Label_panel4.Text = SlideBoxPanel2_1.Checked.ToString();
            ValuesController.valuestate[0] = Convert.ToInt32(SlideBoxPanel2_1.Checked);
            ValuesController.valuestate[1] = Convert.ToInt32(SlideBoxPanel2_2.Checked);
            ValuesController.valuestate[2] = Convert.ToInt32(SlideBoxPanel2_3.Checked);
        }
    }
}