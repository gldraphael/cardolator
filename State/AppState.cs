using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Malhar.Cardolator.BL;

namespace Malhar.Cardolator
{
    /// <summary>
    /// Maintains the state of the Cardolator
    /// </summary>
    public static class AppState
    {
        /// <summary>
        /// Manages all actions related to the Volunteer database
        /// </summary>
        public static VolunteerManager VolunteerManager { get; set; }

        /// <summary>
        /// Manages all actions related to cardolate purchases by each volunteer
        /// </summary>
        public static PurchaseManager PurchaseManager { get; set; }

        /// <summary>
        /// Creates the files and folders necessary for the cardolator to run if they dont already exist
        /// Loads the file into memory
        /// </summary>
        public static void Initialize(string directory, string workforce_path, string purchase_record_path)
        {
            // Create the Cardolator Director if it doesn't exist
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            // Create a workforce file if it doesn't exist
            if (!File.Exists(workforce_path))
            {
                AppState.VolunteerManager = VolunteerManager.CreateNew(workforce_path);
            }
            else
            {
                AppState.VolunteerManager = VolunteerManager.Load(workforce_path);
            }

            // Create a purchase record file if it doesn't exist
            if (!File.Exists(purchase_record_path))
            {
                AppState.PurchaseManager = PurchaseManager.CreateNew(purchase_record_path);
            }
            else
            {
                AppState.PurchaseManager = PurchaseManager.Load(purchase_record_path);
            }
        }

    }
}
