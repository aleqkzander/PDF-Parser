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
        private List<PdfContentObject> _initialContentObjects;

        public Welcome()
        {
            InitializeComponent();
            DataSourceTextBox.KeyUp += DataSource_OnEnterPressed;
            FilterTextBox.KeyUp += FilterBox_OnEnterPressed;
            _initialContentObjects = new List<PdfContentObject>();
        }

        private async void Welcome_Load(object sender, EventArgs e)
        {
            string _initialContentObjectsString = DatasourceManager.LoadCurrentList();

            if (string.IsNullOrEmpty(_initialContentObjectsString))
            {
                LoadingAnimation.Visible = false;
                return;
            }
            else
            {
                _initialContentObjects = JsonHelper.ConvertJsonToList(_initialContentObjectsString);

                await Task.Run(() =>
                {
                    FillContenBoxFromList(_initialContentObjects);
                });

                LoadingAnimation.Visible = false;
            }
        }

        private void FillContentBoxFromDataSource(string datasource)
        {
            if (string.IsNullOrEmpty(datasource)) return;
            DataboxController.ClearContentBox(DataSourceContentBox);
            _initialContentObjects.Clear();
            DatasourceManager.DeleteCurrentList();

            string[] pdfFiles = Directory.GetFiles(_dataSource, "*.pdf");

            foreach (string pdfFile in pdfFiles)
            {
                string path = Path.Combine(datasource, pdfFile);
                string name = Path.GetFileName(pdfFile);
                string text = ReaderHelper.Read(path);
                PdfContentObject pdfContentObject = new PdfContentObject(path, name, text);
                _initialContentObjects.Add(pdfContentObject);
                DataboxController.FillContentBox(DataSourceContentBox, pdfContentObject);
            }
        }

        private void FillContenBoxFromList(List<PdfContentObject> pdfContentObjects)
        {
            if (pdfContentObjects.Count == 0) return;
            DataboxController.ClearContentBox(DataSourceContentBox);

            foreach (PdfContentObject filteredObject in pdfContentObjects)
            {
                DataboxController.FillContentBox(DataSourceContentBox, filteredObject);
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
        }

        private async void FilterBox_OnEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            LoadingAnimation.Visible = false;

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
                    List<PdfContentObject> localList = DataboxController.CreateLocalList(_initialContentObjects, FilterTextBox.Text);
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
            if (_initialContentObjects == null || _initialContentObjects.Count == 0) return;

            try
            {
                string jsonList = JsonHelper.ConvertListToJson(_initialContentObjects);
                DatasourceManager.SaveCurrentList(jsonList);
                MessageBox.Show("List saved successfully");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Failed saving the list..." + $"\n{exception.Message}");
            }
        }

        private void ShowHelpBtn_Click(object sender, EventArgs e)
        {
            HelpDisplay help = new HelpDisplay();
            help.Show();
        }
    }
}
