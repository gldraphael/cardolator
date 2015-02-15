using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Malhar.Cardolator.Entity;
using System.Xml.Serialization;

namespace Malhar.Cardolator.DA
{
    [XmlRoot("PurchaseRecord")]
    public class PurchaseRecord
    {
        [XmlIgnore]
        public string FileName { get; set; }

        [XmlArray("Records")]
        public List<Record> Purchases { get; set; }

        private PurchaseRecord() { }

        private PurchaseRecord(string filename)
        {
            FileName = filename;
            Purchases = new List<Record>();
        }

        public bool Save()
        {
            return XmlUtility.Serialize<PurchaseRecord>(this, FileName);
        }

        public static PurchaseRecord Load(string filename)
        {
            var x = XmlUtility.Deserialize<PurchaseRecord>(filename);
            x.FileName = filename;
            return x;
        }

        public static PurchaseRecord Create(string filename)
        {
            PurchaseRecord pr = new PurchaseRecord() { FileName = filename };
            pr.Save();
            return pr;
        }
    }
}
