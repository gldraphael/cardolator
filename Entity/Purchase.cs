using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Malhar.Cardolator.Entity
{
    public class Purchase
    {
        /// <summary>
        /// The number of cardolates purchased
        /// </summary>
        [XmlElement("Number")]
        public int Number { get; set; }

        /// <summary>
        /// The date of purchase
        /// </summary>
        [XmlElement("Date")]
        public string Date { get; set; }

        public Purchase(int number)
        {
            this.Number = number;
            this.Date = DateTime.Now.ToString("d MMM, yy");
        }

        public Purchase(int number, string Date)
        {
            this.Number = number;
            this.Date = Date;
        }

        private Purchase() { }
    }
}
