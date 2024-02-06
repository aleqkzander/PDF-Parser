using System.IO;
using System.Windows.Forms;

namespace PDF_Parser.Utility
{
    public class DatasourceManager
    {
        private static bool IsSaveFilePresent()
        {
            string folderPath = Path.Combine(Application.StartupPath, "save");
            string dataFile = Path.Combine(folderPath, "saved_list");

            if (File.Exists(dataFile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SaveCurrentList(string content)
        {
            string folderPath = Path.Combine(Application.StartupPath, "save");
            string dataFile = Path.Combine(folderPath, "saved_list");

            if (Directory.Exists(folderPath) == false)
            {
                Directory.CreateDirectory(folderPath);
            }

            if (IsSaveFilePresent() == false)
            {
                File.WriteAllText(dataFile, content);
            }
        }

        public static string LoadCurrentList()
        {
            string folderPath = Path.Combine(Application.StartupPath, "save");
            string dataFile = Path.Combine(folderPath, "saved_list");

            if (IsSaveFilePresent())
            {
                string jsonUser = File.ReadAllText(dataFile);
                return jsonUser;
            }
            else
            {
                return string.Empty;
            }
        }

        public static void DeleteCurrentList()
        {
            string folderPath = Path.Combine(Application.StartupPath, "save");
            string dataFile = Path.Combine(folderPath, "saved_list");

            if (IsSaveFilePresent())
            {
                File.Delete(dataFile);
            }
        }
    }
}
