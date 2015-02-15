using Malhar.Cardolator.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malhar.Cardolator.ViewModels
{
    public class StatsVM
    {
        public List<DayTransaction> Transactions { get; set; }

        public int Purchased
        {
            get
            {
                return (from x in Transactions
                        select x.Sold).Sum();
            }
        }

        public double Amount
        {
            get
            {
                return (from x in Transactions
                        select x.Amount).Sum();
            }
        }

        public double FreeCards
        {
            get
            {
                return (from x in Transactions
                        select x.Sold / 5).Sum();
            }
        }

        public StatsVM()
        {
            Transactions = new List<DayTransaction>();

            List<Purchase> purchases = new List<Purchase>();
            foreach (var record in AppState.PurchaseManager.GetPurchaseRecords())
                foreach (Purchase p in record.Purchases)
                    purchases.Add(p);

            var items = from x in purchases
                        group x by x.Date;

            foreach (var item in items)
            {
                int count = (from x in item
                             select x.Number).Sum();
                Transactions.Add(
                        new DayTransaction
                        {
                            Sold = count,
                            Date = item.Key
                        }
                    );
            }
        }
    }

    public class DayTransaction
    {
        public string Date { get; set; }
        public int Sold { get; set; }

        public double Amount { get { return Sold * 10; } }
    }
}
