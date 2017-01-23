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
        public Window[] Windows = new Window[2];
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

            Windows[0] = new Window(0);
            Windows[1] = new Window(1);

            Heater = new Heater(0);
        }

        private string ip;
        private int port;    
        private string request;
        private string response;
        private string exceptionMessage;  
        private bool responseReceived;
        private bool requestSend;   
                      
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
                request = "exit\r\n";
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
                sendBuffer = Encoding.ASCII.GetBytes(request);

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
            request = String.Format("lamp {0} on\r\n", index);
            SendRequest();

            if (requestSend)
                Lamps[index].State = Lamp.States.On;
        }

        public void TurnOffLamp(int index)
        {
            request = String.Format("lamp {0} off\r\n", index);
            SendRequest();

            if (requestSend)
                Lamps[index].State = Lamp.States.Off;
        }

        public void OpenWindow(int index)
        {
            request = String.Format("window {0} open\r\n", index);
            SendRequest();

            if (requestSend)
                Windows[index].State = Window.States.Open;
        }

        public void CloseWindow(int index)
        {
            request = String.Format("window {0} close\r\n", index);
            SendRequest();

            if (requestSend)
                Windows[index].State = Window.States.Closed;
        }

        public void ChangeHeaterDegree(float degree)
        {
            request = String.Format("heater {0:.0}\r\n", degree);
            SendRequest();

            if (requestSend)
                Heater.Degree = degree;
        }

        public void RetrieveLamps()
        {
            Match match;

            foreach (Lamp lamp in Lamps)
            {
                request = String.Format("lamp {0}\r\n", lamp.Index);
                SendRequest();

                match = Regex.Match(response, @"\b(?:On|Off)\b");

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
                        default:
                            break;
                    }
                }
            }
        }

        public void RetrieveWindows()
        {
            Match match;

            foreach (Window window in Windows)
            {
                request = String.Format("window {0}\r\n", window.Index);
                SendRequest();

                match = Regex.Match(response, @"\b(?:Open|Closed|Half)\b");

                if (match.Value != "")
                {
                    switch (match.Value)
                    {
                        case "Open":
                            window.State = Window.States.Open;
                            break;
                        case "Closed":
                            window.State = Window.States.Closed;
                            break;
                        case "Half":
                            window.State = Window.States.Half;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void RetrieveHeater()
        {
            request = String.Format("heater\r\n");
            SendRequest();

            Match match = Regex.Match(response, @"[0-9]{2}(?:\,[0-9])?");

            if (match.Value != "")
                Heater.Degree = float.Parse(match.Value);
        }      
    }
}