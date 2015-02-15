using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malhar.Cardolator.Entity
{
    public class Department
    {
        /// <summary>
        /// The Department Name
        /// </summary>
        public DepartmentName Name { get; set; }

        /// <summary>
        /// The subdepartment name
        /// </summary>
        public SubDepartment SubDepartmentName { get; set; }

        /// <summary>
        /// If the department is one of the big four departments
        /// </summary>
        public bool IsBigFour
        {
            get
            {
                switch (Name)
                {
                    case DepartmentName.Logistics:
                    case DepartmentName.Security:
                    case DepartmentName.Texxx:
                    case DepartmentName.Assistance:
                        return true;
                }
                return false;
            }
        }

        public Department()
        {
            this.Name = DepartmentName.Admin;
            this.SubDepartmentName = SubDepartment.None;
        }

        public Department(DepartmentName DepartmentName, SubDepartment SubDepartmentName)
        {
            this.Name = DepartmentName;
            this.SubDepartmentName = SubDepartmentName;
        }

        public static List<SubDepartment> GetSubdepartment(DepartmentName dept)
        {
            List<SubDepartment> list = new List<SubDepartment>();
            switch (dept)
            {
                case DepartmentName.Security:
                    list.Add(SubDepartment.All);
                    list.Add(SubDepartment.MnT);
                    list.Add(SubDepartment.AudienceGates);
                    list.Add(SubDepartment.VIPGates);
                    list.Add(SubDepartment.FirstQuad);
                    list.Add(SubDepartment.Woods);
                    break;

                case DepartmentName.Texxx:
                    list.Add(SubDepartment.All);
                    list.Add(SubDepartment.FirstQuad);
                    list.Add(SubDepartment.Foyer);
                    list.Add(SubDepartment.Halls);
                    list.Add(SubDepartment.Classrooms);
                    list.Add(SubDepartment.VSM);
                    list.Add(SubDepartment.Mobiles);
                    list.Add(SubDepartment.Inventory);
                    break;

                case DepartmentName.All:
                    list.Add(SubDepartment.All);
                    list.Add(SubDepartment.MnT);
                    list.Add(SubDepartment.AudienceGates);
                    list.Add(SubDepartment.VIPGates);
                    list.Add(SubDepartment.FirstQuad);
                    list.Add(SubDepartment.Woods);
                    list.Add(SubDepartment.Judges);
                    list.Add(SubDepartment.Floors);
                    list.Add(SubDepartment.Halls);
                    list.Add(SubDepartment.Foyer);
                    list.Add(SubDepartment.Classrooms);
                    list.Add(SubDepartment.Events);
                    list.Add(SubDepartment.Constructions);
                    list.Add(SubDepartment.Displays);
                    list.Add(SubDepartment.VSM);
                    list.Add(SubDepartment.Mobiles);
                    list.Add(SubDepartment.Inventory);
                    break;

                case DepartmentName.Assistance:
                    list.Add(SubDepartment.All);
                    list.Add(SubDepartment.Judges);
                    list.Add(SubDepartment.Floors);
                    list.Add(SubDepartment.Halls);
                    list.Add(SubDepartment.Foyer);
                    break;

                case DepartmentName.Logistics:
                    list.Add(SubDepartment.All);
                    list.Add(SubDepartment.Classrooms);
                    list.Add(SubDepartment.Events);
                    list.Add(SubDepartment.Constructions);
                    list.Add(SubDepartment.Displays);
                    break;
            }

            list.Add(SubDepartment.None);
            return list;
        }

        public override string ToString()
        {
            return Name.ToString() + " (" + SubDepartmentName.ToString() + ")";
        }
    }
}
