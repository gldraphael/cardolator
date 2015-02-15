using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Malhar.Cardolator.ViewModels;
using Malhar.Cardolator.BL;
using Malhar.Cardolator.Entity;

namespace Malhar.Cardolator.UI.Pages
{
    /// <summary>
    /// Interaction logic for MakePurchase.xaml
    /// </summary>
    public partial class MakePurchase : Page
    {
        public CardolateVM ViewModel { get; set; }

        public MakePurchase()
        {
            ViewModel = new CardolateVM();
            InitializeComponent();
        }

        /// <summary>
        /// Called when the user clicks the make purchase button
        /// Saves the purchase
        /// </summary>
        private void btnMakePurchase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if purchase number is valid
                if(int.Parse(txtPurchase.Text) < 1)
                    return;

                Volunteer selected = (Volunteer)lstVolunteers.SelectedItem;
                if (selected == null)
                    MessageBox.Show("Select a someone first");

                Record r = new Record(selected.Key);
                r.Purchases.Add(new Purchase(ViewModel.PurchaseNumber));
                AppState.PurchaseManager.Add(r);
                AppState.PurchaseManager.Save();
                txtPurchase.Text = "0";

                ViewModel.PurchaseMade();
            }
            catch { }
        }

        private void btnAllotCards_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if purchase number is valid
                int recieved = int.Parse(txtReceived.Text);

                // Get the selected volunteer
                Volunteer selected = (Volunteer)lstVolunteers.SelectedItem;
                if (selected == null)
                    MessageBox.Show("Select a someone first");

                // Allot cards and save the changes
                AppState.PurchaseManager.AllotCards(selected.Key, recieved);
                AppState.PurchaseManager.Save();

                txtPurchase.Text = "0";
            }
            catch { }
        }

        private void lstVolunteers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Update the key of the ViewModel each time the selection is changed
            ViewModel.VolunteerKey = ((Volunteer)lstVolunteers.SelectedItem).Key;
        }
    }
}
