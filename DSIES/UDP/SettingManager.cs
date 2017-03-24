using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIES.UDP
{
    class SettingManager
    {
        public SettingManager()
        {
            LoadAppSetting();
            LoadUDP();


        }

        public Dictionary<string, Dictionary<string, string>> App;
        public UDPSetting UDP;
        public Dictionary<string, int> UDPOffset;

        private Dictionary<string, Dictionary<string, string>> TextEn;
        private Dictionary<string, Dictionary<string, string>> TextZh;

        private void LoadUDP()
        {
            UDP = new UDPSetting();
            UDP.Port = Int32.Parse(App["udp"]["port"]);
            UDP.BufferSize =
                Int32.Parse(App["udp"]["port"]);

            UDPOffset = FileManager.GetOffset();
        }
        private void LoadAppSetting()
        {
            App = FileManager.GetAppSetting();
        }


        public Dictionary<string, Dictionary<string, string>> Text
        {
            get
            {
                switch (App["style"]["lang"])
                {
                    case "zh":
                        return TextZh;
                    case "en":
                        return TextEn;
                }
                return TextZh;
            }
        }

        public void SaveAppSetting()
        {
            //TODO
        }

        public void SaveStyleSetting()
        {
            //TODO
        }
    }
}
