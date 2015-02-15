using Malhar.Cardolator.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malhar.Cardolator.ViewModels
{
    public class CardolateVM : VolunteerListVM
    {
        /// <summary>
        /// Number of cardolates purchased
        /// </summary>
        private int purchaseNumber = 0;
        public int PurchaseNumber
        {
            get
            {
                return purchaseNumber;
            }
            set
            {
                purchaseNumber = value;
                base.RaisePropertyChanged("PurchaseNumber");
                base.RaisePropertyChanged("Free");
                base.RaisePropertyChanged("Amount");
                base.RaisePropertyChanged("Total");
            }
        }

        /// <summary>
        /// Free cardolates
        /// </summary>
        public int Free
        {
            get
            {
                return (PurchaseNumber+TotalCardolatesPurchased%5)/5;
            }
        }

        /// <summary>
        /// Total number of cardolates
        /// </summary>
        public int Total
        {
            get
            {
                return PurchaseNumber + Free;
            }
        }

        /// <summary>
        /// Amount Payable
        /// </summary>
        public String Amount
        {
            get
            {
                return "Rs. " + (PurchaseNumber * 10).ToString() + " /-";
            }
        }

        /// <summary>
        /// The number of cardolates the person have received
        /// </summary>
        private int received;
        public int Received
        {
            get
            {
                return received;
            }
            set
            {
                received = value;
                base.RaisePropertyChanged("Received");
            }
        }

        private string key;
        public string VolunteerKey{
            get
            {
                return key;
            }
            set
            {
                key = value;
                RaisePropertyChanged("TotalCardolatesPurchased");
                RaisePropertyChanged("History");
                RaisePropertyChanged("FreeCardolatesTaken");
            }
        }

        public int TotalCardolatesPurchased {
            get {
                return AppState.PurchaseManager.TotalPurchased(VolunteerKey);
            }
        }

        public int FreeCardolatesTaken
        {
            get
            {
                return TotalCardolatesPurchased / 5;
            }
        }

        public List<Purchase> History { get {
            var x = AppState.PurchaseManager.Get(VolunteerKey);
            if (x == null)
                return null;
            return x.Purchases;
        } }

        public void PurchaseMade()
        {
            RaisePropertyChanged("History");
        }

        public override void Refresh()
        {
            base.Refresh();
        }
    }
}
