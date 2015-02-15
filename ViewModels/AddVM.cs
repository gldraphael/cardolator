using Malhar.Cardolator.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malhar.Cardolator.ViewModels
{
    public class AddVM : VolunteerListVM
    {
        public string[] Types { get { return Enum.GetNames(typeof(WorkForceType)); } }
        public string[] Year { get { return Enum.GetNames(typeof(Year)); } }
        public string[] Courses { get { return Enum.GetNames(typeof(Course)); } }
        public override string[] Departments
        {
            get
            {
                var x = from v in base.Departments
                        where v!="All"
                        select v;
                return x.ToArray();
            }
        }

        public override List<string> SubDepartments
        {
            get
            {
                var x = from s in base.SubDepartments
                        where s != "All"
                        select s;
                return x.ToList();
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            base.RaisePropertyChanged("Types");
            base.RaisePropertyChanged("Year");
            base.RaisePropertyChanged("Courses");
        }
    }
}
