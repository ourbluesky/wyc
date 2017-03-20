using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace DSIES.Class.Control
{
    static class FileManager
    {
        static FileManager()
        {
            WorkPath = System.Environment.CurrentDirectory;
            LoadPath();
        }

        private static Dictionary<string, Dictionary<string, string>> Path;
        private static string WorkPath;

        # region Path Setting
        // load path.json
        private static bool LoadPath()
        {
            string path = FindFile("path.json");
            if (path != null)
            {
                try
                {
                    string jsonStr = File.ReadAllText(path);
                    Path = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonStr);

                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        // Find the first matched file
        private static string FindFile(string fileName)
        {
            var paths = Directory.GetFiles(WorkPath, fileName, SearchOption.AllDirectories);
            if (paths.Length > 0)
                return paths[0];
            else
                return null;
        }

        public static string GetPath(string category, string key)
        {
            if (Path.ContainsKey(category))
                if (Path[category].ContainsKey(key))
                    return WorkPath + Path[category][key];

            return null;
        }
        # endregion

        # region GET
      
        public static Dictionary<string, string> GetUDPSetting()
        {
            string path = GetPath("setting", "udp");
            return ReadJson<Dictionary<string, string>>(path);
        }

        public static Dictionary<string, int> GetOffset()
        {
            string path = GetPath("setting", "offset");
            return ReadJson<Dictionary<string, int>>(path);
        }
        public static Dictionary<string, Dictionary<string, string>> GetAppSetting()
        {
            string path = GetPath("setting", "app");
            return ReadJson<Dictionary<string, Dictionary<string, string>>>(path);
        }
       

       

        

        public static T ReadJson<T>(string path)
        {
            T result;
            try
            {
                string jsonStr = File.ReadAllText(path, Encoding.UTF8);
                result = JsonConvert.DeserializeObject<T>(jsonStr);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
        #endregion
        #region Save
    
      

        public static bool SaveUDPSetting(Dictionary<string, string> udp)
        {
            string jsonStr = JsonConvert.SerializeObject(udp);
            string udpPath = GetPath("setting", "udp");

            return WriteFile(udpPath, jsonStr);
        }

        private static bool WriteFile(string path, string str)
        {
            try
            {
                File.WriteAllText(path, str);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        # endregion

        public static void Hit() { }
    }
}
