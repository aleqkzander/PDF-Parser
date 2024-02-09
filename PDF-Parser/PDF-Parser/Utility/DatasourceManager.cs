using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PDF_Parser.Utility
{
    public class DatasourceManager
    {
        private static string _folderPath;

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

        public static void CreatSaveDirectory()
        {
            string folderPath = Path.Combine(Application.StartupPath, "save");

            if (Directory.Exists(folderPath) == false)
            {
                Directory.CreateDirectory(folderPath);
            }

            _folderPath = folderPath;
        }

        public static void SaveList(List<PdfContentObject> list)
        {
            string dataFile = Path.Combine(_folderPath, "saved_list");

            using (StreamWriter writer = new StreamWriter(dataFile))
            {
                foreach (var item in list)
                {
                    // Convert each object to JSON and write it to the file stream
                    string jsonItem = JsonHelper.ConvertPdfContentObjectToJson(item);
                    writer.WriteLine(jsonItem);
                }
            }
        }

        public static List<PdfContentObject> LoadList()
        {
            List<PdfContentObject> loadedList = new List<PdfContentObject>();
            string dataFile = Path.Combine(_folderPath, "saved_list");

            if (!File.Exists(dataFile))
            {
                // return a new list when the file doesn't exist
                return loadedList;
            }

            using (StreamReader reader = new StreamReader(dataFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Deserialize each JSON string back to a PdfContentObject
                    PdfContentObject item = JsonHelper.ConvertJsonToPdfContentObject(line);
                    if (item != null)
                    {
                        loadedList.Add(item);
                    }
                }
            }

            return loadedList;
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
