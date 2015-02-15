using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malhar.Cardolator.Entity
{
    public class Record : IEquatable<Volunteer>
    {
        /// <summary>
        /// The purchases made by the user
        /// </summary>
        public List<Purchase> Purchases { get; set; }
        public int Recieved { get; set; }

        public string Key { get; set; }

        private Record() { }

        public Record(string key)
        {
            this.Key = key;
            this.Purchases = new List<Purchase>();
        }

        public bool Equals(Volunteer obj)
        {
            return (obj.Key == this.Key);
        }

        public override bool Equals(object obj)
        {
            Volunteer v = obj as Volunteer;
            if (v == null)
                return false;
            else return v.Key == Key;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
