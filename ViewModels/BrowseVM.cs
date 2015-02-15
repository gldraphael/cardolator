using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Malhar.Cardolator;
using Malhar.Cardolator.Entity;
using System.Windows.Data;

namespace Malhar.Cardolator.ViewModels
{
    public class BrowseVM : VolunteerListVM
    {
        public new List<VolunteerVM> Volunteers
        {
            get
            {
                return VolunteerVM.Convert(base.Volunteers);
            }
        }
    }

    //public class SubDepartmentConvertor : IValueConverter
    //{

    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        var d = (DepartmentName)Enum.Parse(typeof(DepartmentName), value.ToString());
    //        return Department.GetSubdepartment(d);
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
