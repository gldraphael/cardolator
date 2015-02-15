using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Malhar.Cardolator.DA
{
    public class XmlUtility
    {
        public static bool Serialize<T>(T value, String filename)
        {
            if (value == null)
            {
                return false;
            }
            try
            {
                XmlSerializer _xmlserializer = new XmlSerializer(typeof(T));
                Stream stream = new FileStream(filename, FileMode.Create);
                _xmlserializer.Serialize(stream, value);
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return false;
            }
        }

        public static T Deserialize<T>(String filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return default(T);
            }
            try
            {
                XmlSerializer _xmlSerializer = new XmlSerializer(typeof(T));
                Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                var result = (T)_xmlSerializer.Deserialize(System.Xml.XmlReader.Create(stream));
                stream.Close();
                return result;
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
