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
using System.IO;

using MahApps.Metro.Controls;
using Malhar.Cardolator.BL;

namespace Malhar.Cardolator.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the window is loaded
        /// Creates the files and folders necessary for the cardolator to run if they dont already exist
        /// Loads the file into memory
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileOperation.CreateIfDoesntExist();
        }

        /// <summary>
        /// Called when the Window closes
        /// Saves the latest app-state into the respective files
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AppState.VolunteerManager.Save();
            AppState.PurchaseManager.Save();
        }
    }
}
