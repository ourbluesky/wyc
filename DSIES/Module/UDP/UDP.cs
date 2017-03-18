using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace DSIES.UDP
{


    public delegate void ReceiveTimeOutAction();
    public delegate void SendTimeOutAction();

    class UDP
    {

        private UDPSetting setting;
        private UdpClient client;
        private IPEndPoint clientEndPoint;  // 本机一律视为客户端
        private IPEndPoint serverEndPoint;  // 接收目标或发送目标一律视为服务端
        public UDP(UDPSetting setting)
        {
            this.setting = setting;
        }



        public ReceiveTimeOutAction ReceiveTimeOutHandler = null;
        public SendTimeOutAction SendTimeOutHandler = null;


        public void Open()
        {
            InitUDP(setting);
        }

        private void InitUDP(UDPSetting setting)
        {
            InitClient(setting);
            InitServer(setting);
        }

        private void InitClient(UDPSetting setting)
        {
            if (client != null)
                Close();
            client = new UdpClient(setting.Port);
            client.Client.ReceiveTimeout = setting.TimeOut;
            client.Client.SendTimeout = setting.TimeOut;
            clientEndPoint = new IPEndPoint(setting.IP, setting.Port);
            if (setting.BufferSize > 0)
                client.Client.ReceiveBufferSize = setting.BufferSize;
        }

        private void InitServer(UDPSetting setting)
        {
            serverEndPoint = new IPEndPoint(setting.serverIP, setting.serverPort);
        }

        public bool Send(byte[] message)
        {
            try
            {
                int count = client.Send(message,
                    message.Length, serverEndPoint);

                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                if (SendTimeOutHandler != null)
                    SendTimeOutHandler();
                return false;
            }
        }

        public byte[] Receive()
        {
            byte[] message = null;
            try
            {
                message = client.Receive(ref serverEndPoint);
            }
            catch
            {
                ReceiveTimeOutHandler.Invoke();
                return null;
            }

            setting.serverIP = serverEndPoint.Address;
            setting.serverPort = serverEndPoint.Port;

            return message;
        }

        public void Close()
        {
            client.Close();
        }
    }
}