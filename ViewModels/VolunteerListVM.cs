using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Malhar.Cardolator.Entity;

namespace Malhar.Cardolator.ViewModels
{
    public class VolunteerListVM : ViewModel
    {
        public virtual string[] Departments { get { return Enum.GetNames(typeof(DepartmentName)); } }
        public virtual List<string> SubDepartments
        {
            get
            {
                var l = Department.GetSubdepartment((DepartmentName)Enum.Parse(typeof(DepartmentName), SelectedDepartment));
                var q = from s in l select s.ToString();
                var val = q.ToList();
                SelectedSubDepartment = val[0];
                return val;
            }
        }

        private string name = "";
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                base.RaisePropertyChanged("Name");
                base.RaisePropertyChanged("Volunteers");
            }
        }

        private string selectedDepartment = DepartmentName.All.ToString();
        public string SelectedDepartment
        {
            get { return selectedDepartment; }
            set
            {
                selectedDepartment = value;
                base.RaisePropertyChanged("SelectedDepartment");
                base.RaisePropertyChanged("SubDepartments");
                base.RaisePropertyChanged("Volunteers");
            }
        }

        private string selectedSubDepartment = SubDepartment.All.ToString();
        public string SelectedSubDepartment
        {
            get { return selectedSubDepartment; }
            set
            {
                selectedSubDepartment = value;
                base.RaisePropertyChanged("SelectedSubDepartment");
                base.RaisePropertyChanged("Volunteers");
            }
        }

        public virtual List<Volunteer> Volunteers
        {
            get
            {
                IQueryable<Volunteer> x = AppState.VolunteerManager.GetVolunteers().AsQueryable();

                // Filter by department
                if (selectedDepartment != DepartmentName.All.ToString())
                    x = from i in x
                        where i.Department.Name.ToString() == SelectedDepartment
                        select i;

                // Filter by subdepartment
                if (selectedSubDepartment != SubDepartment.All.ToString())
                    x = from i in x
                        where i.Department.SubDepartmentName.ToString() == SelectedSubDepartment
                        select i;

                // Filter by Name
                x = from i in x
                    where i.Name.StartsWith(Name, StringComparison.OrdinalIgnoreCase)
                    select i;
                
                return x.ToList<Volunteer>();
            }
        }

        public override void Refresh()
        {
            base.RaisePropertyChanged("Departments");
            base.RaisePropertyChanged("SubDepartments");
            base.RaisePropertyChanged("Volunteers");
        }
    }
}
