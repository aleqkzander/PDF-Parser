using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using PDF_Parser.Utility;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

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

        private async void DataSource_OnEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || string.IsNullOrEmpty(DataSourceTextBox.Text)) return;
            LoadingAnimation.Visible = true;
            _dataSource = DatasourceManager.SaveDataSource(DataSourceTextBox, DataSourceGroup);

            await Task.Run(() =>
            {
                FillContentBoxWithDataSourceContent(_dataSource);
            });

            LoadingAnimation.Visible = false;
        }

        private async void Welcome_Load(object sender, EventArgs e)
        {
            _dataSource = DatasourceManager.LoadDataSource(DataSourceGroup);

            await Task.Run(() =>
            {
                FillContentBoxWithDataSourceContent(_dataSource);
            });

            LoadingAnimation.Visible = false;
        }

        private void FillContentBoxWithDataSourceContent(string datasource)
        {
            if (string.IsNullOrEmpty(datasource)) return;

            DataSourceContentBox?.Invoke((Action)(() 
                => DataSourceContentBox.Items.Clear()));

            try
            {
                string[] pdfFiles = Directory.GetFiles(_dataSource, "*.pdf");

                foreach (string pdfFile in pdfFiles)
                {
                    PdfContentObject pdfContentObject = new PdfContentObject
                        (
                        Path.Combine(datasource, pdfFile),
                        Path.GetFileName(pdfFile),
                        ReadPdfFile(Path.Combine(datasource, pdfFile))
                        );

                    DataSourceContentBox?.Invoke((Action)(() 
                        => DataSourceContentBox.Items.Add(pdfContentObject)));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private string ReadPdfFile(string path)
        {
            StringBuilder text = new StringBuilder();

            try
            {
                // Create a PdfReader object to read the PDF file
                using (PdfReader pdfReader = new PdfReader(path))
                {
                    // Create a PdfDocument object to represent the PDF document
                    using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
                    {
                        // Iterate through each page of the PDF document
                        for (int pageNumber = 1; pageNumber <= pdfDocument.GetNumberOfPages(); pageNumber++)
                        {
                            // Create a SimpleTextExtractionStrategy to extract text from the page
                            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                            // Parse the content of the page and extract text
                            string pageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNumber), strategy);

                            // Append the extracted text to the StringBuilder
                            text.AppendLine(pageText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., if the PDF file is password-protected or corrupted
                text.AppendLine($"Error reading PDF file: {ex.Message}");
            }

            return text.ToString();
        }

        private void DataSourceContentBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DataSourceContentBox.SelectedItem == null) return;

            PdfContentObject selectedPdfObject = (PdfContentObject)DataSourceContentBox.SelectedItem;
            OpenListItem(selectedPdfObject);
        }

        private void OpenListItem(PdfContentObject pdfContentObject)
        {
            FileContent fileContent = new FileContent(pdfContentObject);
            fileContent.Show();
        }
    }
}
