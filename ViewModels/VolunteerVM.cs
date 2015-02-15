using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Malhar.Cardolator.Entity;

namespace Malhar.Cardolator.ViewModels
{
    public class VolunteerVM
    {
        private Volunteer Volunteer { get; set; }

        public string GetKey()
        {
            return Volunteer.Key;
        }

        public string Name
        {
            get
            {
                return Volunteer.Name;
            }
            set
            {
                Volunteer.Name = value;
            }
        }

        public DepartmentName Department
        {
            get
            {
                return Volunteer.Department.Name;
            }
            set
            {
                Volunteer.Department.Name = value;
            }
        }

        public WorkForceType Post
        {
            get
            {
                return Volunteer.WorkForceType;
            }
            set
            {
                Volunteer.WorkForceType = value;
            }
        }

        public SubDepartment SubDepartment
        {
            get
            {
                return Volunteer.Department.SubDepartmentName;
            }
            set
            {
                Volunteer.Department.SubDepartmentName = value;
            }
        }

        public Year Year
        {
            get
            {
                return Volunteer.Year;
            }
            set
            {
                Volunteer.Year = value;
            }
        }

        public Course Course
        {
            get
            {
                return Volunteer.Course;
            }
            set
            {
                Volunteer.Course = value;
            }
        }

        public int No {
            get
            {
                return AppState.PurchaseManager.TotalPurchased(GetKey());
            }
        }

        public VolunteerVM(Volunteer v)
        {
            this.Volunteer = v;
        }

        public static List<VolunteerVM> Convert(List<Volunteer> volunteers)
        {
            List<VolunteerVM> vlvm = new List<VolunteerVM>();
            foreach (var v in volunteers)
                vlvm.Add(new VolunteerVM(v));
            return vlvm;
        }

        public static implicit operator Volunteer(VolunteerVM vm)
        {
            return vm.Volunteer;
        }
    }
}
