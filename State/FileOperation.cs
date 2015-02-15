using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Malhar.Cardolator.BL;

namespace Malhar.Cardolator
{
    public class FileOperation
    {
        static string WorkForcePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Cardolator\Workforce.wf";
        static string PurchaseRecordPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Cardolator\Record.rc";
        static string WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Cardolator";

        public enum DbFile
        {
            WorkForce,
            PurchaseRecord
        }

        /// <summary>
        /// Imports the file and merges it with the internal file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="sourceFilePath"></param>
        public static void ImportAndMerge(DbFile file, string sourceFilePath)
        {
            switch (file)
            {
                case DbFile.WorkForce:
                    AppState.VolunteerManager.Merge(VolunteerManager.Load(sourceFilePath));
                    AppState.VolunteerManager.Save();
                    break;
                case DbFile.PurchaseRecord:
                    AppState.PurchaseManager.Merge(PurchaseManager.Load(sourceFilePath));
                    AppState.PurchaseManager.Save();
                    break;
            }
        }

        /// <summary>
        /// Exports the database to a specifed location
        /// </summary>
        /// <param name="file">The file to export</param>
        /// <param name="destinationpath">The new file name</param>
        public static void Export(DbFile file, string destinationpath)
        {
            switch (file)
            {
                case DbFile.WorkForce:
                    File.Copy(WorkForcePath, destinationpath);
                    break;
                case DbFile.PurchaseRecord:
                    File.Copy(PurchaseRecordPath, destinationpath);
                    break;
            }
        }

        /// <summary>
        /// Deletes the internal copy of the file. Resets user data
        /// </summary>
        public static void Delete(DbFile file)
        {
            switch (file)
            {
                case DbFile.WorkForce:
                    File.Delete(WorkForcePath);
                    AppState.VolunteerManager = null;
                    break;

                case DbFile.PurchaseRecord:
                    File.Delete(PurchaseRecordPath);
                    AppState.PurchaseManager = null;
                    break;
            }
        }

        /// <summary>
        /// Creates the files if they dont exist
        /// </summary>
        public static void CreateIfDoesntExist()
        {
            AppState.Initialize(WorkingDirectory, WorkForcePath, PurchaseRecordPath);
        }
    }
}
