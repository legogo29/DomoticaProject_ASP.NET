﻿using System;
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
            Api.Logger log = new Api.Logger();
            log.log("Visited house.aspx");

            daHaus.Connect();

            if (daHaus.Connected)
            {
                connectionStatus.Text = "Connection";
                connectionStatus.CssClass = "connected";
            }
            else
            {
                connectionStatus.Text = "No Connection";
                connectionStatus.CssClass = "disconnected";
            }
        }


        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            daHaus.RetrieveLamps();
            daHaus.RetrieveWindows();
            daHaus.RetrieveHeater();
            daHaus.Close();
            PrepareHtmlInputs();
        }


        protected void PrepareHtmlInputs()
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
                switch (daHaus.Windows[i].State)
                {
                    case Window.States.Open:
                        windows[i].Checked = false;
                        break;

                    case Window.States.Half:
                        //Doe niks.
                        break;

                    case Window.States.Closed:
                        windows[i].Checked = true;
                        break;
                }
            }

            if (daHaus.Heater.Degree != 0)
                txt_heater.Text = daHaus.Heater.Degree.ToString(".0");
        }

        protected void LampCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Match match = Regex.Match(checkBox.ID, @"\d");
            int index = int.Parse(match.Value);

            if (checkBox.Checked)
            {
                daHaus.TurnOnLamp(index);
            }
            else
            {
                daHaus.TurnOffLamp(index);
            }
        }

        protected void WindowCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Match match = Regex.Match(checkBox.ID, @"\d");
            int index = int.Parse(match.Value);

            if (checkBox.Checked)
            {
                daHaus.CloseWindow(index);
            }
            else
            {
                daHaus.OpenWindow(index);
            }
        }

        protected void btn_sendHeater_Click(object sender, EventArgs e)
        {
            string input = txt_heater.Text.Replace('.', ',');

            float degree;

            if (float.TryParse(input, out degree))
            {
                daHaus.ChangeHeaterDegree(degree);
            }
        }
    }
}