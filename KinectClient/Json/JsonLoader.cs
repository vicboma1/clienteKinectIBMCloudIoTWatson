using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Microsoft.Samples.Kinect.BodyBasics.Json
{

    public class JsonLoader
    {
        public static string PATH_INITIALIZE = System.AppDomain.CurrentDomain.BaseDirectory + "Dependencies/Settings.json";

        public JsonLoader()
        {

        }


        public static T ToProperties<T>(String path)
        {
            T res = default(T);
            var exist = File.Exists(path);
            if (!exist)
                return res;

            using (var r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                res = JsonConvert.DeserializeObject<T>(json);
            }

            return res;
        }
    }
}
