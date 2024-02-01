using System.Windows.Forms;

namespace PDF_Parser.Utility
{
    public class DatasourceManager
    {
        public static string SaveDataSource(string datasource)
        {
            string _dataSource = datasource;
            Properties.Settings.Default.Datasource = _dataSource;
            Properties.Settings.Default.Save();
            return _dataSource;
        }

        public static string LoadDataSource()
        {
            string _dataSource = Properties.Settings.Default.Datasource;
            return _dataSource;
        }
    }
}
