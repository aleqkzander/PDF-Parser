using PDF_Parser.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            _dataSource = DatasourceManager.LoadDataSource(DataSourceTextBox, DataSourceGroup);
        }
    }
}
