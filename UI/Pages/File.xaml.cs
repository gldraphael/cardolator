using Microsoft.Win32;
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

namespace Malhar.Cardolator.UI.Pages.WorkForce
{
    /// <summary>
    /// Interaction logic for File.xaml
    /// </summary>
    public partial class File : Page
    {
        public File()
        {
            InitializeComponent();
        }

        private void btnDeleteWF_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("You will lose all volunteer's information.\nProceed anyway?", "Delete WorkForce Database?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                FileOperation.Delete(FileOperation.DbFile.WorkForce);
                FileOperation.CreateIfDoesntExist();
            }
        }

        private void btnMergeWF_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose workforce file to import and merge";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Workforce Database File (.wf) |*.wf";
            if (dialog.ShowDialog() == true)
            {
                string source = dialog.FileName;
                FileOperation.ImportAndMerge(FileOperation.DbFile.WorkForce, source);
                AppState.VolunteerManager.Save();
            }
        }

        private void btnExportWF_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Export workforce database";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Workforce Database File (.wf) |*.wf";
            if (dialog.ShowDialog() == true)
            {
                string destination = dialog.FileName;
                FileOperation.Export(FileOperation.DbFile.WorkForce, destination);
            }
        }


        private void btnDeletePR_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("You will lose all purchase information.\nProceed anyway?", "Delete Purchase Database?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                FileOperation.Delete(FileOperation.DbFile.PurchaseRecord);
                FileOperation.CreateIfDoesntExist();
            }
        }

        private void btnMergePR_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose Purchase Record file to import and merge";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Purchase Record (.rc) |*.rc";
            if (dialog.ShowDialog() == true)
            {
                string source = dialog.FileName;
                FileOperation.ImportAndMerge(FileOperation.DbFile.PurchaseRecord , source);
                AppState.PurchaseManager.Save();
            }
        }

        private void btnExportPR_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Export workforce database";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Workforce Database File (.rc) |*.rc";
            if (dialog.ShowDialog() == true)
            {
                string destination = dialog.FileName;
                FileOperation.Export(FileOperation.DbFile.PurchaseRecord, destination);
            }
        }
    }
}
