using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_Parser.Utility
{
    public class DatasourceManager
    {
        public static string SaveDataSource(TextBox datasourcetextbox, GroupBox datasourcegroupbox)
        {
            string _dataSource = datasourcetextbox.Text;
            datasourcegroupbox.Text = $"Datasource: {datasourcetextbox.Text}";
            Properties.Settings.Default.Datasource = _dataSource;

            return _dataSource;
        }

        public static string LoadDataSource(TextBox datasourcetextbox, GroupBox datasourcegroupbox)
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
