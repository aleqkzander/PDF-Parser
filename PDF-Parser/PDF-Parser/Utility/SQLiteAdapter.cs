using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace PDF_Parser.Utility
{
    internal class SQLiteAdapter
    {
        static readonly string _folderPath = Path.Combine(Application.StartupPath, "save");
        static readonly string _dataFile = Path.Combine(_folderPath, "localdata.db");

        public static void InitializeDatabase()
        {
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);

            if (!File.Exists(_dataFile))
            {
                SQLiteConnection.CreateFile(_dataFile);

                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={_dataFile};Version=3;"))
                {
                    connection.Open();

                    string createTableQuery = @"CREATE TABLE IF NOT EXISTS appdata (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT NOT NULL UNIQUE,
                content TEXT NOT NULL
                 );";

                    using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void InsertEntry(PdfContentObject pdfContentObject)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={_dataFile};Version=3;"))
            {
                connection.Open();

                string insertQuery = @"
        INSERT INTO appdata (name, content)
        VALUES (@name, @content);";

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", pdfContentObject.Name);
                    command.Parameters.AddWithValue("@content", pdfContentObject.Text);

                    try
                    {
                        // we only execute when the pdfContentObject is a new object - we don't add twice
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                }
            }
        }

        public static List<PdfContentObject> GetAllEntries()
        {
            List<PdfContentObject> entries = new List<PdfContentObject>();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={_dataFile};Version=3;"))
            {
                connection.Open();

                string selectQuery = "SELECT id, name, content FROM appdata;";

                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PdfContentObject pdfContentObject = new PdfContentObject(reader.GetString(1), reader.GetString(2));
                            entries.Add(pdfContentObject);
                        }
                    }
                }
            }

            return entries;
        }

        public static string GetPathToDataFile() => _dataFile;
    }
}