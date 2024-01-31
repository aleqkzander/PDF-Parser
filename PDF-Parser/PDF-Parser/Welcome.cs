using PDF_Parser.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_Parser
{
    public partial class Welcome : Form
    {
        private string _dataSource;

        public Welcome()
        {
            InitializeComponent();
            DataSourceTextBox.KeyUp += DataSource_OnEnterPressed;
        }

        private void DataSource_OnEnterPressed(object sender, KeyEventArgs e)
        {
            // Dont execute when not enter or textbox has no content
            if (e.KeyCode != Keys.Enter || string.IsNullOrEmpty(DataSourceTextBox.Text)) return;

            _dataSource = DatasourceManager.SaveDataSource(DataSourceTextBox, DataSourceGroup);
            FillContentBoxWithDataSourceContent(_dataSource);
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            _dataSource = DatasourceManager.LoadDataSource(DataSourceGroup);
            FillContentBoxWithDataSourceContent(_dataSource);
        }

        private void FillContentBoxWithDataSourceContent(string datasource)
        {
            if (string.IsNullOrEmpty(datasource)) return;

            DataSourceContentBox.Items.Clear();

            try
            {
                string[] pdfFiles = Directory.GetFiles(_dataSource, "*.pdf");

                foreach (string pdfFile in pdfFiles)
                {
                    DataSourceContentBox.Items.Add(Path.GetFileName(pdfFile));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DataSourceContentBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DataSourceContentBox.SelectedItem == null) return;
            OpenListItem(DataSourceContentBox.SelectedItem);
        }

        private void OpenListItem(object item)
        {
            string listItemPath = Path.Combine(_dataSource, item.ToString());
            MessageBox.Show(listItemPath);
        }
    }
}
