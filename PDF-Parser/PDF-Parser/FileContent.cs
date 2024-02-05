using PDF_Parser.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PDF_Parser
{
    public partial class FileContent : Form
    {
        private List<int> searchResults;
        private int currentIndex;
        readonly string originalText;

        public FileContent(PdfContentObject pdfContentObject)
        {
            InitializeComponent();
            this.Text = pdfContentObject.Name;
            originalText = pdfContentObject.Text;
            FileContentBox.Text = pdfContentObject.Text;
            FilterContentTextBox.KeyUp += FilterContentTextBox_OnEnterPressed;
        }

        private void FilterContentTextBox_OnEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            if (string.IsNullOrEmpty(FilterContentTextBox.Text))
            {
                FileContentBox.Clear();
                FileContentBox.Text = originalText;
                return;
            }

            try
            {
                string searchText = FilterContentTextBox.Text;
                searchResults = FindAllIndices(FileContentBox.Text.ToLower(), searchText.ToLower());
                currentIndex = (currentIndex + 1) % searchResults.Count;

                if (searchResults.Count > 0)
                {
                    FileContentBox.Select(searchResults[currentIndex], searchText.Length);
                    FileContentBox.SelectionBackColor = Color.Yellow;
                    FileContentBox.ScrollToCaret();
                }
            }
            catch
            {
            }
        }

        private List<int> FindAllIndices(string source, string searchText)
        {
            List<int> indices = new List<int>();
            int index = source.IndexOf(searchText);

            while (index != -1)
            {
                indices.Add(index);
                index = source.IndexOf(searchText, index + 1);
            }

            return indices;
        }
    }
}
