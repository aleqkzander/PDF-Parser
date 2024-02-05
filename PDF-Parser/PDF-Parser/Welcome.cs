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
        private readonly List<PdfContentObject> _initialContentObjects;

        public Welcome()
        {
            InitializeComponent();
            DataSourceTextBox.KeyUp += DataSource_OnEnterPressed;
            FilterTextBox.KeyUp += FilterBox_OnEnterPressed;
            _initialContentObjects = new List<PdfContentObject>();
        }

        private async void Welcome_Load(object sender, EventArgs e)
        {
            _dataSource = DatasourceManager.LoadDataSource();

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
            _initialContentObjects.Clear();

            try
            {
                string[] pdfFiles = Directory.GetFiles(_dataSource, "*.pdf");

                foreach (string pdfFile in pdfFiles)
                {
                    string path = Path.Combine(datasource, pdfFile);
                    string name = Path.GetFileName(pdfFile);
                    string text = ReaderHelper.Read(path);
                    PdfContentObject pdfContentObject = new PdfContentObject(path, name,text);
                    _initialContentObjects.Add(pdfContentObject);
                    DataboxController.FillContentBox(DataSourceContentBox, pdfContentObject);
                }
            }
            catch
            {
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
            catch
            {
            }
        }

        private void DataSourceContentBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DataSourceContentBox.SelectedItem == null) return;

            try
            {
                PdfContentObject selectedPdfObject = (PdfContentObject)DataSourceContentBox.SelectedItem;
                FileContent fileContent = new FileContent(selectedPdfObject);
                fileContent.Show();
            }
            catch
            {
            }
        }

        private async void DataSource_OnEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || string.IsNullOrEmpty(DataSourceTextBox.Text)) return;

            LoadingAnimation.Visible = true;
            _dataSource = DataSourceTextBox.Text;

            try
            {
                await Task.Run(() =>
                {
                    FillContentBoxFromDataSource(_dataSource);
                });
            }
            catch
            {
            }

            LoadingAnimation.Visible = false;
            _contentList = DataSourceContentBox;
        }

        private async void FilterBox_OnEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            LoadingAnimation.Visible = true;

            try
            {
                if (string.IsNullOrEmpty(FilterTextBox.Text))
                {
                    await Task.Run(() =>
                    {
                        FillContenBoxFromList(_initialContentObjects);
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
            }
            catch
            {
            }

            LoadingAnimation.Visible = false;
        }

        private void SaveDatasourceBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_dataSource)) return;
            //DatasourceManager.SaveDataSource(DataSourceTextBox.Text);
        }
    }
}
