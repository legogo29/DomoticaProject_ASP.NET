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
        private DaHaus daHaus = new DaHaus("127.0.0.1", 11000);

        protected void Page_Load(object sender, EventArgs e)
        {
            daHaus.Connect();
            daHaus.RetrieveLamps();
            daHaus.RetrieveRollingShutters();
            daHaus.RetrieveHeater();
            daHaus.Close();

            this.ShowStates();
        }

        protected void ShowStates()
        {
            if (daHaus.Lamps[0].State == Lamp.States.On)
                lamp0.Checked = true;
            else
                lamp0.Checked = false;

            if (daHaus.Lamps[1].State == Lamp.States.On)
                lamp1.Checked = true;
            else
                lamp1.Checked = false;

            if (daHaus.Lamps[2].State == Lamp.States.On)
                lamp2.Checked = true;
            else
                lamp2.Checked = false;

            if (daHaus.Lamps[3].State == Lamp.States.On)
                lamp3.Checked = true;
            else
                lamp3.Checked = false;

            if (daHaus.Lamps[4].State == Lamp.States.On)
                lamp4.Checked = true;
            else
                lamp4.Checked = false;

            switch (daHaus.RollingShutters[0].State)
            {
                //Color grey
                case RollingShutter.States.Open:
                    window0.Checked = false;
                    break;
                //Color orange?
                case RollingShutter.States.Half:
                    window0.Checked = true;
                    window0span.Attributes["Class"] = "slider round bgOrange";
                    //window0span.Style.Add("background-color", "#f0ad4e");
                    break;
                //Color green
                case RollingShutter.States.Closed:
                    window0.Checked = true;
                    break;
            }

            switch (daHaus.RollingShutters[1].State)
            {
                case RollingShutter.States.Open:
                    window1.Checked = false;
                    break;
                case RollingShutter.States.Half:
                    window1.Checked = true;
                    window1span.Attributes["Class"] = "slider round bgOrange";
                    break;
                case RollingShutter.States.Closed:
                    window1.Checked = true;
                    break;
            }

            heater.InnerText = daHaus.Heater.Degree.ToString(".0");
        }
    }
}