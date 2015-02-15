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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        Volunteer lastAdded = null;
        public AddVM ViewModel { get; set; }
        public Add()
        {
            ViewModel = new AddVM();
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get name
                string name = txtName.Text;
                // Year and Course
                Year year = (Year)Enum.Parse(typeof(Year), cbxYear.SelectedItem.ToString());
                Course course = (Course)Enum.Parse(typeof(Course), cbxCourse.SelectedItem.ToString());
                // Get department and subdepartment details
                DepartmentName department = (DepartmentName)Enum.Parse(typeof(DepartmentName), cbxDepartment.SelectedItem.ToString());
                SubDepartment subdepartment = (SubDepartment)Enum.Parse(typeof(SubDepartment), cbxSubDepartment.SelectedItem.ToString());
                // Volunteer type (volunteer, coordi, etc.)
                WorkForceType type = (WorkForceType)Enum.Parse(typeof(WorkForceType), cbxType.SelectedItem.ToString());

                // Validating Name
                if (name.Length <= 3 || name.Length > 30)
                {
                    lblLastAdded.Content = "Enter a valid name";
                    return;
                }

                // Create and object and add it to the database
                lastAdded = new Volunteer(name, year, course, new Department(department, subdepartment), type);

                // Add the details to the database and commit the changes
                AppState.VolunteerManager.Add(lastAdded);
                AppState.VolunteerManager.Save();

                // Add the details of the just added volunteers's details
                StringBuilder sb = new StringBuilder();
                sb.Append("Name:\t\t" + name);
                sb.Append("\nYear:\t\t" + year.ToString());
                sb.Append("\nCourse:\t\t" + course.ToString());
                sb.Append("\nDepartment:\t" + department.ToString());
                sb.Append("\nSubdepartment:\t" + subdepartment.ToString());
                sb.Append("\nType:\t\t" + type.ToString());
                lblLastAdded.Content = sb.ToString();

                // Remove the name from the textbox
                txtName.Text = string.Empty;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                lblLastAdded.Content = "Something went wrong";
            }
        }
    }
}
