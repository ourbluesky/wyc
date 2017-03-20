using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;


namespace DSIES.UDP
{
    class UDPSetting
    {
        public UDPSetting()
        {
            setDefault();
        }


        private IPAddress severIP;
        private int severPort;
        private IPAddress ip;
        private int port;
        private int timeOut;
        private int bufferSize;
        public delegate void ClientChangeHandler(UDPSetting setting);
        public ClientChangeHandler ClientChangeAction;

        public IPAddress serverIP
        {
            get { return serverIP; }
            set
            {
                serverIP = value;
            }
        }

        public int serverPort
        {
            get { return serverPort; }
            set
            {
                serverPort = value;
            }
        }

        public IPAddress IP
        {
            get { return ip; }
            set
            {
                ip = value;
                ClientChange();
            }
        }

        public int Port
        {
            get { return port; }
            set
            {
                port = value;
                ClientChange();
            }
        }

        public int TimeOut
        {
            get { return timeOut; }
            set { timeOut = value; }
        }

        public int BufferSize
        {
            get { return bufferSize; }
            set { bufferSize = value; }
        }

        private void setDefault()
        {
            serverIP = IPAddress.Broadcast;
            serverPort = 9999;
            ip = GetLocalIP();
            port = 9999;
            timeOut = 3000;
        }

        private IPAddress GetLocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip;
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void ClientChange()
        {
            ClientChangeAction.Invoke(this);
        }
    }
}

