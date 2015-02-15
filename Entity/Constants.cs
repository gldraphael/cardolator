using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malhar.Cardolator.Entity
{
    /// <summary>
    /// The course the volunteer is studying in
    /// </summary>
    public enum Course
    {
        BA = 0,
        BMM = 4,
        BMS = 3,
        BSC = 1,
        [Description("BSc IT")]
        BSCIT = 2,
        JC = 7,
        //MA = 5,
        //MSC = 6,
        None = 8
    }

    /// <summary>
    /// The post of the volunteer
    /// </summary>
    public enum WorkForceType
    {
        Volunteer = 0,
        [Description("Co-ordinator")]
        Coordinator = 1,
        Organizer = 2,
        [Description("Organizer In-Charge")]
        OrganizerInCharge = 3,
        Trinity = 4
    }

    /// <summary>
    /// The year the volunteer is studying in
    /// </summary>
    public enum Year
    {
        FY,
        SY,
        TY,
        None
    }

    /// <summary>
    /// The Malhar department the volunteer belongs to
    /// </summary>
    public enum DepartmentName
    {
        All,
        Admin,
        Assistance,
        Computers,
        Conclave,
        ETC,
        Finance,
        FineArts,
        Graffix,
        Hospitality,
        IPA,
        LA,
        Logistics,
        Marketing,
        PR,
        Raga,
        Security,
        Souvenirs,
        Texxx,
        Trinity,
        WInc,
        WPA
    }

    /// <summary>
    /// The volunteer's subdepartment
    /// </summary>
    public enum SubDepartment
    {
        All = 0,
        None = 1,
        [Description("Audience Gates")]
        AudienceGates = 3,
        Classrooms = 11,
        Constructions = 13,
        Displays = 14,
        Events = 12,
        [Description("First Quad")]
        FirstQuad = 5,
        Floors = 8,
        Foyer = 10,
        Halls = 9,
        Inventory = 0x11,
        Judges = 7,
        [Description("Movement & Traffic")]
        MnT = 2,
        Mobiles = 0x10,
        [Description("VIP Gates")]
        VIPGates = 4,
        VSM = 15,
        Woods = 6
    }
}