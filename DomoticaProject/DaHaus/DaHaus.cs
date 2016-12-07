using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace DomoticaProject
{
    public class DaHaus
    {
        private TcpClient client;
        private NetworkStream stream;

        public Lamp[] Lamps = new Lamp[5];
        public RollingShutter[] RollingShutters = new RollingShutter[2];
        public Heater Heater;

        public DaHaus(string ip, int port)
        {
            this.ip = ip;
            this.port = port;

            this.Lamps[0] = new Lamp(0);
            this.Lamps[1] = new Lamp(1);
            this.Lamps[2] = new Lamp(2);
            this.Lamps[3] = new Lamp(3);
            this.Lamps[4] = new Lamp(4);

            this.RollingShutters[0] = new RollingShutter(0);
            this.RollingShutters[1] = new RollingShutter(1);

            this.Heater = new Heater(0);
        }

        public string Request;

        private string ip;
        public string Ip
        {
            get
            {
                return this.ip;
            }
        }

        private int port;
        public int Port
        {
            get
            {
                return this.port;
            }
        }

        private string exceptionMessage;
        public string ExceptionMessage
        {
            get
            {
                return this.exceptionMessage;
            }
        }

        private string response;
        public string Response
        {
            get
            {
                return this.response;
            }
        }

        private bool transmitFailed;
        public bool TransmitFailed
        {
            get
            {
                return this.transmitFailed;
            }
        }

        private bool connected;
        public bool Connected
        {
            get
            {
                this.connected = false;

                try
                {
                    this.connected = this.client.Connected;
                }
                catch (Exception exception)
                {
                    this.exceptionMessage = exception.Message;
                }

                return this.connected;
            }
        }

        public void Connect()
        {
            try
            {
                if (!this.Connected)
                    this.client = new TcpClient(this.ip, this.port);
            }
            catch (Exception exception)
            {
                this.exceptionMessage = exception.Message;
            }
        }

        public void Close()
        {
            if (this.Connected)
            {
                this.Request = "exit\r\n";
                this.SendRequest();
            }

            try
            {
                this.stream.Close();
            }
            catch (Exception exception)
            {
                this.exceptionMessage = exception.Message;
            }

            try
            {
                this.client.Close();
            }
            catch (Exception exception)
            {
                this.exceptionMessage = exception.Message;
            }
        }

        public void SendRequest()
        {
            byte[] sendBuffer;
            byte[] receiveBuffer = new byte[1024];

            this.response = "";

            if (this.Connected)
            {
                this.stream = this.client.GetStream();

                sendBuffer = Encoding.ASCII.GetBytes(this.Request);
                this.stream.Write(sendBuffer, 0, sendBuffer.Length);

                this.transmitFailed = false;

                try
                {
                    int amountOfBytesRead;

                    do
                    {
                        do
                        {
                            amountOfBytesRead = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
                            this.response += Encoding.ASCII.GetString(receiveBuffer, 0, amountOfBytesRead);
                        } while (amountOfBytesRead == receiveBuffer.Length);
                    } while (this.stream.DataAvailable);
                }
                catch (Exception exception)
                {
                    this.exceptionMessage = exception.Message;
                    this.transmitFailed = true;
                }
            }
        }

        public void TurnOnLamp(int index)
        {
            Lamp.States state = Lamp.States.On;

            this.Request = String.Format("lamp {0} {1}\r\n", index, state);
            this.SendRequest();

            if (!this.transmitFailed)
                this.Lamps[index].State = state;
        }

        public void TurnOffLamp(int index)
        {
            Lamp.States state = Lamp.States.Off;

            this.Request = String.Format("lamp {0} {1}\r\n", index, state);
            this.SendRequest();

            if (!this.transmitFailed)
                this.Lamps[index].State = state;
        }

        public void OpenRollingShutter(int index)
        {
            RollingShutter.States state = RollingShutter.States.Open;

            this.Request = String.Format("window {0} {1}\r\n", index, state);
            this.SendRequest();

            if (!this.transmitFailed)
                this.RollingShutters[index].State = state;
        }

        public void CloseRollingShutter(int index)
        {
            RollingShutter.States state = RollingShutter.States.Closed;

            this.Request = String.Format("window {0} {1}\r\n", index, state);
            this.SendRequest();

            if (!this.transmitFailed)
                this.RollingShutters[index].State = state;
        }

        public void ChangeHeaterDegree(float degree)
        {
            this.Request = String.Format("heater {0:.0}\r\n", degree);
            this.SendRequest();

            if (!this.transmitFailed)
                this.Heater.Degree = degree;
        }

        public void UpdateLamps()
        {
            Match match;

            foreach (Lamp lamp in this.Lamps)
            {
                this.Request = String.Format("lamp {0}\r\n", lamp.Index);
                this.SendRequest();

                match = Regex.Match(this.Response, @"\b(?:On|Off)\b");
            }
        }

        public void UpdateRollingShutters()
        {
            Match match;

            foreach (RollingShutter rollingShutter in this.RollingShutters)
            {
                this.Request = String.Format("window {0}\r\n", rollingShutter.Index);
                this.SendRequest();

                match = Regex.Match(this.Response, @"\b(?:Open|Closed|Half)\b");

                if (match.Value != "")
                {
                    switch (match.Value)
                    {
                        case "Open":
                            rollingShutter.State = RollingShutter.States.Open;
                            break;
                        case "Closed":
                            rollingShutter.State = RollingShutter.States.Closed;
                            break;
                        case "Half":
                            rollingShutter.State = RollingShutter.States.Half;
                            break;
                    }
                }
            }
        }

        public void UpdateHeater()
        {
            this.Request = String.Format("heater\r\n");
            this.SendRequest();

            Match match = Regex.Match(this.Response, @"[0-9]{2}(?:\,[0-9])?");

            if (match.Value != "")
                this.Heater.Degree = float.Parse(match.Value);
        }
    }
}