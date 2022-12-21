using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Pract10
{
    public class Converter
    {
        public static void Ser<T>(T obj, string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path + "\\" + filename, json);
        } 
        public static T Des<T>(string path)
        {
            string json = File.ReadAllText(path);
            T worker = JsonConvert.DeserializeObject<T>(json);
            return worker;
        }
    }
}
