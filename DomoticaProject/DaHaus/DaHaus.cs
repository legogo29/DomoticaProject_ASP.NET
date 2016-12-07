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

            Lamps[0] = new Lamp(0);
            Lamps[1] = new Lamp(1);
            Lamps[2] = new Lamp(2);
            Lamps[3] = new Lamp(3);
            Lamps[4] = new Lamp(4);

            RollingShutters[0] = new RollingShutter(0);
            RollingShutters[1] = new RollingShutter(1);

            Heater = new Heater(0);
        }

        public string Request;

        private string ip;
        public string Ip
        {
            get
            {
                return ip;
            }
        }

        private int port;
        public int Port
        {
            get
            {
                return port;
            }
        }

        private string exceptionMessage;
        public string ExceptionMessage
        {
            get
            {
                return exceptionMessage;
            }
        }

        private string response;
        public string Response
        {
            get
            {
                return response;
            }
        }

        private bool requestSend;
        public bool RequestSend
        {
            get
            {
                return requestSend;
            }
        }

        private bool responseReceived;
        public bool ResponseReceived
        {
            get
            {
                return responseReceived;
            }
        }

        private bool connected;
        public bool Connected
        {
            get
            {
                connected = false;

                try
                {
                    connected = client.Connected;
                }
                catch (Exception exception)
                {
                    exceptionMessage = exception.Message;
                }

                return connected;
            }
        }

        public void Connect()
        {
            try
            {
                if (!Connected)
                    client = new TcpClient(ip, port);
            }
            catch (Exception exception)
            {
                exceptionMessage = exception.Message;
            }
        }

        public void Close()
        {
            if (Connected)
            {
                Request = "exit\r\n";
                SendRequest();
            }

            try
            {
                stream.Close();
            }
            catch (Exception exception)
            {
                exceptionMessage = exception.Message;
            }

            try
            {
                client.Close();
            }
            catch (Exception exception)
            {
                exceptionMessage = exception.Message;
            }
        }

        public void SendRequest()
        {
            byte[] sendBuffer;
            byte[] receiveBuffer = new byte[1024];

            response = "";

            if (Connected)
            {
                requestSend = false;
                responseReceived = false;

                stream = client.GetStream();
                sendBuffer = Encoding.ASCII.GetBytes(Request);

                try
                {
                    stream.Write(sendBuffer, 0, sendBuffer.Length);
                    requestSend = true;
                }
                catch (Exception exception)
                {
                    exceptionMessage = exception.Message;
                }

                try
                {
                    int amountOfBytesRead;

                    do
                    {
                        do
                        {
                            amountOfBytesRead = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
                            response += Encoding.ASCII.GetString(receiveBuffer, 0, amountOfBytesRead);
                        } while (amountOfBytesRead == receiveBuffer.Length);
                    } while (stream.DataAvailable);

                    responseReceived = true;
                }
                catch (Exception exception)
                {
                    exceptionMessage = exception.Message;
                }
            }
        }

        public void TurnOnLamp(int index)
        {
            Lamp.States state = Lamp.States.On;

            Request = String.Format("lamp {0} {1}\r\n", index, state.ToString().ToLower());
            SendRequest();

            if (RequestSend)
                Lamps[index].State = state;
        }

        public void TurnOffLamp(int index)
        {
            Lamp.States state = Lamp.States.Off;

            Request = String.Format("lamp {0} {1}\r\n", index, state);
            SendRequest();

            if (RequestSend)
                Lamps[index].State = state;
        }

        public void OpenRollingShutter(int index)
        {
            RollingShutter.States state = RollingShutter.States.Open;

            Request = String.Format("window {0} {1}\r\n", index, state);
            SendRequest();

            if (RequestSend)
                RollingShutters[index].State = state;
        }

        public void CloseRollingShutter(int index)
        {
            RollingShutter.States state = RollingShutter.States.Closed;

            Request = String.Format("window {0} {1}\r\n", index, state);
            SendRequest();

            if (RequestSend)
                RollingShutters[index].State = state;
        }

        public void ChangeHeaterDegree(float degree)
        {
            Request = String.Format("heater {0:.0}\r\n", degree);
            SendRequest();

            if (RequestSend)
                Heater.Degree = degree;
        }

        public void UpdateLamps()
        {
            Match match;

            foreach (Lamp lamp in Lamps)
            {
                Request = String.Format("lamp {0}\r\n", lamp.Index);
                SendRequest();

                match = Regex.Match(Response, @"\b(?:On|Off)\b");

                if (match.Value != "")
                {
                    switch (match.Value)
                    {
                        case "On":
                            lamp.State = Lamp.States.On;
                            break;
                        case "Off":
                            lamp.State = Lamp.States.Off;
                            break;
                    }
                }
            }
        }

        public void UpdateRollingShutters()
        {
            Match match;

            foreach (RollingShutter rollingShutter in RollingShutters)
            {
                Request = String.Format("window {0}\r\n", rollingShutter.Index);
                SendRequest();

                match = Regex.Match(Response, @"\b(?:Open|Closed|Half)\b");

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
            Request = String.Format("heater\r\n");
            SendRequest();

            Match match = Regex.Match(Response, @"[0-9]{2}(?:\,[0-9])?");

            if (match.Value != "")
                Heater.Degree = float.Parse(match.Value);
        }
    }
}