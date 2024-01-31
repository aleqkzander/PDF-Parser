using System.Windows.Forms;

namespace PDF_Parser.Utility
{
    public class DatasourceManager
    {
        public static string SaveDataSource(TextBox datasourcetextbox, GroupBox datasourcegroupbox)
        {
            string _dataSource = datasourcetextbox.Text;
            datasourcegroupbox.Text = $"Datasource: {datasourcetextbox.Text}";

            //Properties.Settings.Default.Datasource = _dataSource;
            //Properties.Settings.Default.Save();

            return _dataSource;
        }

        public static string LoadDataSource(GroupBox datasourcegroupbox)
        {
            string _dataSource = Properties.Settings.Default.Datasource;

            if (string.IsNullOrEmpty(_dataSource))
            {
                datasourcegroupbox.Text = $"Datasource: No datasource provided";
            }

            return _dataSource;
        }
    }
}
