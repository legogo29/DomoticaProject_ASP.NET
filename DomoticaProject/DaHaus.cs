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

        private string request;
        public string Request
        {
            get
            {
                return this.request;
            }
            set
            {
                this.request = value + "\r\n";
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
                this.Request = "exit";
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

        public void ChangeLampState(Lamp lamp, Lamp.States state)
        {
            this.request = String.Format("lamp {0} {1}", lamp.Index, state.ToString().ToLower());

            this.SendRequest();

            if (!this.transmitFailed)
                lamp.State = state;
        }

        public void ChangeRollingShutterState(RollingShutter rollingShutter, RollingShutter.States state)
        {
            this.request = String.Format("window {0} {1}", rollingShutter.Index, state.ToString().ToLower());

            this.SendRequest();

            if (!this.transmitFailed)
                rollingShutter.State = state;
        }

        public void ChangeHeaterDegree(float degree)
        {
            this.request = String.Format("heater {0:0.0}", degree);

            this.SendRequest();

            if (!this.transmitFailed)
                this.Heater.Degree = degree;
        }

        public void UpdateLamps()
        {
            foreach (Lamp lamp in this.Lamps)
            {
                this.Request = String.Format("lamp {0}", lamp.Index);
                this.SendRequest();

                if (this.Response.ToLower().Contains("on"))
                    lamp.State = Lamp.States.On;
                else
                    lamp.State = Lamp.States.Off;
            }
        }

        public void UpdateRollingShutter()
        {
            foreach (RollingShutter rollingShutter in this.RollingShutters)
            {
                this.Request = String.Format("window {0}", rollingShutter.Index);
                this.SendRequest();

                if (this.Response.ToLower().Contains("open"))
                    rollingShutter.State = RollingShutter.States.Open;
                else
                    rollingShutter.State = RollingShutter.States.Close;
            }
        }

        public void UpdateHeater()
        {
            this.Request = String.Format("heater");
            this.SendRequest();

            Match match = Regex.Match(this.Response, @"[0-9]{2}(?:\,[0-9])?");
            this.Heater.Degree = float.Parse(match.Value);
        }
    }
}