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
        protected DaHaus daHaus = new DaHaus("127.0.0.1", 11000);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                daHaus.Connect();

                if (daHaus.Connected)
                {
                    connectionStatus.Text = "Connection";
                    connectionStatus.CssClass = "connected";

                    daHaus.UpdateHouse();
                    daHaus.Close();
                    PrepareInputs();
                }
                else
                {
                    connectionStatus.Text = "No Connection";
                    connectionStatus.CssClass = "disconnected";
                }
            }
        }

        protected void PrepareInputs()
        {
            CheckBox[] lamps = { lamp0, lamp1, lamp2, lamp3, lamp4 };
            CheckBox[] windows = { window0, window1 };

            for (int i = 0; i < lamps.Length; i++)
            {
                if (daHaus.Lamps[i].State == Lamp.States.On)
                    lamps[i].Checked = true;
                else
                    lamps[i].Checked = false;
            }

            for (int i = 0; i < windows.Length; i++)
            {
                if (daHaus.Windows[i].State == Window.States.Closed)
                    windows[i].Checked = true;
                else
                    windows[i].Checked = false;
            }

            if (daHaus.Heater.Degree != 0)
                txt_heater.Text = daHaus.Heater.Degree.ToString(".0");
        }

        protected void LampCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Match match = Regex.Match(checkBox.ID, @"\d");
            int index = int.Parse(match.Value);

            daHaus.Connect();

            if(daHaus.Connected)
            {
                connectionStatus.Text = "Connection";
                connectionStatus.CssClass = "connected";

                if (checkBox.Checked)
                {
                    daHaus.TurnOnLamp(index);
                }
                else
                {
                    daHaus.TurnOffLamp(index);
                }
            }
            else
            {
                connectionStatus.Text = "No Connection";
                connectionStatus.CssClass = "disconnected";
            }

            daHaus.Close();
        }

        protected void WindowCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Match match = Regex.Match(checkBox.ID, @"\d");
            int index = int.Parse(match.Value);

            daHaus.Connect();

            if (daHaus.Connected)
            {
                connectionStatus.Text = "Connection";
                connectionStatus.CssClass = "connected";

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
            else
            {
                connectionStatus.Text = "No Connection";
                connectionStatus.CssClass = "disconnected";
            }
        }

        protected void btn_sendHeater_Click(object sender, EventArgs e)
        {
            string input = txt_heater.Text.Replace('.', ',');

            float degree;

            if (float.TryParse(input, out degree))
            {
                daHaus.Connect();

                if (daHaus.Connected)
                {
                    connectionStatus.Text = "Connection";
                    connectionStatus.CssClass = "connected";

                    daHaus.ChangeHeaterDegree(degree);
                    daHaus.Close();
                }
                else
                {
                    connectionStatus.Text = "No Connection";
                    connectionStatus.CssClass = "disconnected";
                }
            }
        }
    }
}