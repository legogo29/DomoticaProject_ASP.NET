using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (!IsPostBack)
            {
                daHaus.Connect();
                daHaus.UpdateHouse();
                daHaus.Close();

                PrepareCheckboxes();
            }
        }

        protected void PrepareCheckboxes()
        {
            CheckBox[] lamps = { lamp0, lamp1, lamp2, lamp3, lamp4 };

            for (int i = 0; i < 5; i++)
            {
                if (daHaus.Lamps[i].State == Lamp.States.On)
                    lamps[i].Checked = true;
                else
                    lamps[i].Checked = false;
            }

            switch (daHaus.Windows[0].State)
            {
                case Window.States.Open:
                    window0.Checked = false;
                    break;

                case Window.States.Half:
                    //Niks
                    break;

                case Window.States.Closed:
                    window0.Checked = true;
                    break;
            }

            switch (daHaus.Windows[1].State)
            {
                case Window.States.Open:
                    window1.Checked = false;
                    break;

                case Window.States.Half:
                    //Niks
                    break;

                case Window.States.Closed:
                    window1.Checked = true;
                    break;
            }

            txt_heater.Text = daHaus.Heater.Degree.ToString(".0");
        }

        protected void LampCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Match match = Regex.Match(checkBox.ID, @"\d");
            int index = int.Parse(match.Value);

            daHaus.Connect();

            if (checkBox.Checked)
            {
                daHaus.TurnOnLamp(index);
            }
            else
            {
                daHaus.TurnOffLamp(index);
            }

            daHaus.Close();
        }

        protected void WindowCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Match match = Regex.Match(checkBox.ID, @"\d");
            int index = int.Parse(match.Value);

            daHaus.Connect();

            if (checkBox.Checked)
            {
                daHaus.CloseWindow(index);
            }
            else
            {
                daHaus.OpenWindow(index);
            }

            daHaus.Close();
        }

        protected void btn_sendHeater_Click(object sender, EventArgs e)
        {
            string input = txt_heater.Text.Replace('.', ',');
            float degree = daHaus.Heater.Degree;

            if (!String.IsNullOrWhiteSpace(input))
                degree = float.Parse(input);

            daHaus.Connect();
            daHaus.ChangeHeaterDegree(degree);
            daHaus.Close();
        }
    }
}