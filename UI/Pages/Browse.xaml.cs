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

using Malhar.Cardolator.Entity;
using Malhar.Cardolator.ViewModels;

namespace Malhar.Cardolator.UI.Pages.WorkForce
{
    /// <summary>
    /// Interaction logic for Browse.xaml
    /// </summary>
    public partial class Browse : Page
    {
        public BrowseVM ViewModel { get; set; }

        public Browse()
        {
            ViewModel = new BrowseVM();
            InitializeComponent();
        }
    }
}
