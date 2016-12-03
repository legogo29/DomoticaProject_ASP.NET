using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace DomoticaProject
{
    public class DaHaus
    {
        private TcpClient client;
        private NetworkStream stream;

        public DaHaus(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
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
                this.request = value;
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
                this.request = "exit\r\n";
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

        public void ChangeLampState(Lamp lamp, Lamp.States state)
        {
            this.request = String.Format("lamp {0} {1}\r\n", lamp.Index, state.ToString().ToLower());
            
            this.SendRequest();

            if (!this.transmitFailed)
                lamp.ChangeState(state);
        }

        public void ChangeRollingShutterState(RollingShutter rollingShutter, RollingShutter.States state)
        {
            this.request = String.Format("window {0} {1}\r\n", rollingShutter.Index, state.ToString().ToLower());
            
            this.SendRequest();

            if (!this.transmitFailed)
                rollingShutter.ChangeState(state);
        }

        public void ChangeHeaterState(Heater heater, float heat)
        {
            this.request = String.Format("heater {0}\r\n", heat.ToString("N1"));

            this.SendRequest();

            if (!this.transmitFailed)
                heater.Heat = heat;
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
    }
}