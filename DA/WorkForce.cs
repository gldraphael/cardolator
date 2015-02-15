using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Malhar.Cardolator.Entity;
using System.Xml.Serialization;

namespace Malhar.Cardolator.DA
{
    [Serializable]
    [XmlRoot("WorkForce")]
    public class WorkForce
    {
        [XmlIgnore]
        public string FileName { get; set; }

        //[XmlElement("Volunteers")]
        [XmlArray("Volunteers")]
        public List<Volunteer> Volunteers = new List<Volunteer>();

        private WorkForce() { }

        public static WorkForce Create(string filename)
        {
            WorkForce w = new WorkForce();
            w.FileName = filename;
            w.Save();
            return w;
        }

        public bool Save()
        {
            return XmlUtility.Serialize<WorkForce>(this, FileName);
        }

        public static WorkForce Load(string filename)
        {
            var x = XmlUtility.Deserialize<WorkForce>(filename);
            x.FileName = filename;
            return x;
        }
    }
}
