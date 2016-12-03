using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DomoticaProject
{
    public partial class house : System.Web.UI.Page
    {
        private Lamp[] Lamps = new Lamp[5];
        private RollingShutter[] RollingShutters = new RollingShutter[2];
        private Heater Heater = new Heater(0);

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBox1.CheckedChanged += new EventHandler(CheckBox1_CheckedChanged);

            /*
            if (!IsPostBack)
            {
                GenerateLamps();
                GenerateRollingShutters();
            }
            */
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool state = CheckBox1.Checked;

            ChangePassword 
        }

        private void GenerateLamps()
        {
            for (int i = 0; i < Lamps.Length; i++)
                Lamps[i] = new Lamp(i);
        }

        private void GenerateRollingShutters()
        {
            for (int i = 0; i < RollingShutters.Length; i++)
                RollingShutters[i] = new RollingShutter(i);
        }
    }
}