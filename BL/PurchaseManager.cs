using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Malhar.Cardolator.DA;
using Malhar.Cardolator.Entity;

namespace Malhar.Cardolator.BL
{
    public class PurchaseManager
    {
        public PurchaseRecord PurchaseRecord { get; set; }

        // For XmlDeserialization's sake
        private PurchaseManager() { }

        public PurchaseManager(string filename)
        {
            PurchaseRecord = PurchaseRecord.Load(filename);
        }

        /// <summary>
        /// Creates a new record if the record doesn't exist and adds a purchase.
        /// Else only adds the purchase to the appropriate record.
        /// </summary>
        /// <param name="record">The record to be added</param>
        public void Add(Record record)
        {
            Record r = Get(record.Key);
            if (r == null)
                PurchaseRecord.Purchases.Add(record);
            else
                r.Purchases.Add(record.Purchases[0]);
        }

        /// <summary>
        /// Allots cards a person has received
        /// </summary>
        /// <param name="volunteerkey">The key of the volunteer who received the cards</param>
        /// <param name="received">The number of cards the person has received</param>
        public void AllotCards(string volunteerkey, int received)
        {
            Record r = Get(volunteerkey);
            if (r == null)
            {
                Record record = new Record(volunteerkey);
                record.Recieved = received;
            }
            else
                r.Recieved = received;
        }

        /// <summary>
        /// Returns a record of a volunteer
        /// </summary>
        /// <param name="key">The key of the volunteer</param>
        /// <returns>A Record if any transaction has taken place before, else null</returns>
        public Record Get(String key)
        {
            return
                (
                    from x in PurchaseRecord.Purchases
                    where x.Key == key
                    select x
                ).SingleOrDefault();
        }

        /// <summary>
        /// Returns a list of all records
        /// </summary>
        /// <returns></returns>
        public List<Record> GetPurchaseRecords()
        {
            return PurchaseRecord.Purchases;
        }

        /// <summary>
        /// Returns the number of cardolates purchased by the volunteer
        /// </summary>
        /// <param name="key">The key of the volunteer</param>
        /// <returns>Returns the number of cardolates purchased by the volunteer</returns>
        public int TotalPurchased(string key)
        {
            Record r = Get(key);
            if (r == null)
                return 0;

            return (from p in r.Purchases
                    select p.Number).Sum();
        }

        /// <summary>
        /// Returns the number of free cardolates given to the voluteer
        /// </summary>
        /// <param name="key">The key of the volunteer</param>
        /// <returns>Returns the number of free cardolates given to the voluteer</returns>
        public int TotalFree(string key)
        {
            return TotalPurchased(key) / 5;
        }

        /// <summary>
        /// Creates a new PurchaseManager object
        /// </summary>
        /// <param name="path">The path to store the purchase-record data</param>
        /// <returns>Returns a new instance of a PurchaseManager object</returns>
        public static PurchaseManager CreateNew(string path)
        {
            PurchaseManager pm = new PurchaseManager() { PurchaseRecord = PurchaseRecord.Create(path) };
            return pm;
        }

        /// <summary>
        /// Saves the purchase-record data to the file
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return this.PurchaseRecord.Save();
        }

        /// <summary>
        /// Loads a PurchaseManager from a file
        /// </summary>
        /// <param name="filename">The path to the file</param>
        /// <returns>A saved instance of the PurchaseManager object</returns>
        public static PurchaseManager Load(string filename)
        {
            return new PurchaseManager() { PurchaseRecord = PurchaseRecord.Load(filename) };
        }

        /// <summary>
        /// Merges the purchaseMangaer with the current purchase manager
        /// </summary>
        /// <param name="purchaseManager"></param>
        public void Merge(PurchaseManager purchaseManager)
        {

            foreach (var r in purchaseManager.GetPurchaseRecords())
            {
                Record tr = Get(r.Key);

                if (tr == null)
                    Add(r);

                else if (r.Purchases.Count > tr.Purchases.Count)
                {
                    for (int i = tr.Purchases.Count; i < r.Purchases.Count; i++)
                        tr.Purchases.Add(r.Purchases[i]);
                }
            }
        }

        public bool Exists(Record r)
        {
            return Get(r.Key) != null;
        }
    }
}
