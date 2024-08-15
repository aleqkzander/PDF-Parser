using PDF_Parser.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private async void Welcome_Load(object sender, EventArgs e)
        {
            //DatasourceManager.CreatSaveDirectory();
            SQLiteAdapter.InitializeDatabase();

            await Task.Run(() =>
            {
                _initialContentObjects = DatasourceManager.LoadList();
            });

            if (_initialContentObjects.Count == 0)
            {
                LoadingAnimation.Visible = false;
                return;
            }

            else
            {
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
            string[] pdfFiles;

            DialogResult result = MessageBox.Show("Do you want to include subfolders?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                pdfFiles = Directory.GetFiles(_dataSource, "*.pdf", SearchOption.AllDirectories);
            }
            else
            {
                pdfFiles = Directory.GetFiles(_dataSource, "*.pdf");
            }

            foreach (string pdfFile in pdfFiles)
            {
                string path = Path.Combine(datasource, pdfFile);
                string name = Path.GetFileName(pdfFile);
                string text = ReaderHelper.Read(path);
                PdfContentObject pdfContentObject = new PdfContentObject(name, text);
                _initialContentObjects.Add(pdfContentObject);
                DataboxController.FillContentBox(DataSourceContentBox, pdfContentObject, this);
            }
        }

        private void FillContenBoxFromList(List<PdfContentObject> pdfContentObjects)
        {
            if (pdfContentObjects.Count == 0) return;

            DataboxController.ClearContentBox(DataSourceContentBox);

            foreach (PdfContentObject filteredObject in pdfContentObjects)
            {
                DataboxController.FillContentBox(DataSourceContentBox, filteredObject, this);
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

            if (LoadingAnimation.Visible)
            {
                MessageBox.Show("Currently there is an operation ongoing.");
                return;
            }

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

            if (LoadingAnimation.Visible)
            {
                MessageBox.Show("Currently there is an operation ongoing.");
                return;
            }

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

        private async void SaveDatasourceBtn_Click(object sender, EventArgs e)
        {
            if (_initialContentObjects == null || _initialContentObjects.Count == 0) return;

            if (LoadingAnimation.Visible)
            {
                MessageBox.Show("Currently there is an operation ongoing.");
                return;
            }

            try
            {
                DatasourceManager.DeleteCurrentList();
                LoadingAnimation.Visible = true;

                await Task.Run(() =>
                {
                    DatasourceManager.SaveList(_initialContentObjects);
                });

                LoadingAnimation.Visible = false;
                MessageBox.Show("List saved successfully");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Failed saving the list..." + $"\n\n{exception}");
            }
        }

        private void ShowHelpBtn_Click(object sender, EventArgs e)
        {
            HelpDisplay help = new HelpDisplay();
            help.Show();
        }
    }
}