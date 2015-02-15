using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Malhar.Cardolator.Entity
{
    [Serializable]
    public class Volunteer
    {
        /// <summary>
        /// The Primary Key
        /// </summary>
        [XmlElement("Key")]
        public string Key { get; set; }

        /// <summary>
        /// The year the volunteer is studying in
        /// </summary>
        [XmlElement("Year")]
        public Year Year { get; set; }

        /// <summary>
        /// The Course the Volunteer is studying
        /// </summary>
        [XmlElement("Course")]
        public Course Course { get; set; }

        /// <summary>
        /// The Malhar Department the Volunteer belongs to
        /// </summary>
        [XmlElement("Department")]
        public Department Department { get; set; }

        /// <summary>
        /// The Name of the volunteer
        /// </summary>
        [XmlElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Volunteer, Coordinator, OG, OC, CP, etc.
        /// </summary>
        [XmlElement("WorkForceType")]
        public WorkForceType WorkForceType { get; set; }

        private Volunteer() 
        {
            
        }

        public Volunteer(string key, string Name, Year Year, Course Course, Department Department, WorkForceType WorkForceType)
        {
            this.Key = key;
            this.Name = Name;
            this.Year = Year;
            this.Course = Course;
            this.Department = Department;
            this.WorkForceType = WorkForceType;
        }

        public Volunteer(string Name, Year Year, Course Course, Department Department, WorkForceType WorkForceType)
            : this(Guid.NewGuid().ToString(), Name, Year, Course, Department, WorkForceType)
        { }
    }
}
