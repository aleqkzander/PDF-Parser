using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PDF_Parser.Utility
{
    public class DatasourceManager
    {
        public static void SaveList(List<PdfContentObject> list)
        {
            foreach (var item in list)
                SQLiteAdapter.InsertEntry(item);
        }

        public static List<PdfContentObject> LoadList() => SQLiteAdapter.GetAllEntries();

        public static void DeleteCurrentList()
        {
            string folderPath = Path.Combine(Application.StartupPath, "save");
            string dataFile = Path.Combine(folderPath, "saved_list");

            if (File.Exists(SQLiteAdapter.GetPathToDataFile()))
                File.Delete(dataFile);
        }
    }
}