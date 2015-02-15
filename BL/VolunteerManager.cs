using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Malhar.Cardolator.Entity;
using Malhar.Cardolator.DA;

namespace Malhar.Cardolator.BL
{
    public class VolunteerManager
    {
        public WorkForce Workforce { get; set; }

        private VolunteerManager() { }

        public VolunteerManager(string filename)
        {
            Workforce = WorkForce.Load(filename);
        }

        public void Add(Volunteer volunteer)
        {
            Workforce.Volunteers.Add(volunteer);
        }

        public Volunteer Get(String key)
        {
            return
                (
                    from x in Workforce.Volunteers
                    where x.Key == key
                    select x
                ).SingleOrDefault();
        }

        public List<Volunteer> GetVolunteers()
        {
            return Workforce.Volunteers;
        }

        public static VolunteerManager CreateNew(string path)
        {
            VolunteerManager v = new VolunteerManager() { Workforce = WorkForce.Create(path) };
            return v;
        }

        public bool Save()
        {
            return this.Workforce.Save();
        }

        public static VolunteerManager Load(string filename)
        {
            return new VolunteerManager() { Workforce = WorkForce.Load(filename) };
        }

        /// <summary>
        /// Merges a volunteer manager with the current volunteer manager
        /// </summary>
        /// <param name="v1"></param>
        public void Merge(VolunteerManager v1)
        {
            foreach (var volunteer in v1.GetVolunteers())
                if (!Exists(volunteer))
                    this.Add(volunteer);
        }

        /// <summary>
        /// Returns true if the volunteer already exists
        /// </summary>
        /// <param name="v">The volunteer to check</param>
        /// <returns>True if exists. Else false.</returns>
        public bool Exists(Volunteer v)
        {
            return (from x in Workforce.Volunteers
                    where x.Key == v.Key
                    select x).Count() > 0;
        }
    }
}
