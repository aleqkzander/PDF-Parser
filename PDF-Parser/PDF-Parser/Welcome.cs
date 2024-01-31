using PDF_Parser.Utility;
using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PDF_Parser
{
    public partial class Welcome : Form
    {
        private string _dataSource;
        private ListBox _contentList;

        public Welcome()
        {
            InitializeComponent();
            DataSourceTextBox.KeyUp += DataSource_OnEnterPressed;
            FilterTextBox.KeyUp += FilterBox_OnEnterPressed;
        }

        private async void Welcome_Load(object sender, EventArgs e)
        {
            _dataSource = DatasourceManager.LoadDataSource(DataSourceGroup);

            await Task.Run(() =>
            {
                FillContentBoxFromDataSource(_dataSource);
            });

            LoadingAnimation.Visible = false;
            _contentList = DataSourceContentBox;
        }

        private void FillContentBoxFromDataSource(string datasource)
        {
            if (string.IsNullOrEmpty(datasource)) return;
            DataboxController.ClearContentBox(DataSourceContentBox);

            try
            {
                string[] pdfFiles = Directory.GetFiles(_dataSource, "*.pdf");

                foreach (string pdfFile in pdfFiles)
                {
                    string path = Path.Combine(datasource, pdfFile);
                    string name = Path.GetFileName(pdfFile);
                    string text = ReaderHelper.Read(path);
                    PdfContentObject pdfContentObject = new PdfContentObject(path, name,text);
                    DataboxController.FillContentBox(DataSourceContentBox, pdfContentObject);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void FillContenBoxFromList(List<PdfContentObject> pdfContentObjects)
        {
            if (pdfContentObjects.Count == 0) return;
            DataboxController.ClearContentBox(DataSourceContentBox);

            try
            {
                foreach (PdfContentObject filteredObject in pdfContentObjects)
                {
                    DataboxController.FillContentBox(DataSourceContentBox, filteredObject);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DataSourceContentBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*
             * Open a new window
             */

            if (DataSourceContentBox.SelectedItem == null) return;

            PdfContentObject selectedPdfObject = (PdfContentObject)DataSourceContentBox.SelectedItem;
            FileContent fileContent = new FileContent(selectedPdfObject);
            fileContent.Show();
        }

        private async void DataSource_OnEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || string.IsNullOrEmpty(DataSourceTextBox.Text)) return;

            LoadingAnimation.Visible = true;
            _dataSource = DatasourceManager.SaveDataSource(DataSourceTextBox, DataSourceGroup);

            await Task.Run(() =>
            {
                FillContentBoxFromDataSource(_dataSource);
            });

            LoadingAnimation.Visible = false;
            _contentList = DataSourceContentBox;
        }

        private async void FilterBox_OnEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            LoadingAnimation.Visible = true;

            if (string.IsNullOrEmpty(FilterTextBox.Text))
            {
                await Task.Run(() =>
                {
                    FillContentBoxFromDataSource(_dataSource);
                });
            }
            else
            {
                List<PdfContentObject> localList = DataboxController.CreateLocalList(_contentList, FilterTextBox.Text);
                await Task.Run(() =>
                {
                    FillContenBoxFromList(localList);
                });
            }

            LoadingAnimation.Visible = false;
        }
    }
}
