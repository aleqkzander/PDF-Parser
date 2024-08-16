using System.Collections.Generic;

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
    }
}