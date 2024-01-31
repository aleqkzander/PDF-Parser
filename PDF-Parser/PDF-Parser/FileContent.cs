using PDF_Parser.Utility;
using System.Windows.Forms;

namespace PDF_Parser
{
    public partial class FileContent : Form
    {
        public FileContent(PdfContentObject pdfContentObject)
        {
            InitializeComponent();
            
            this.Text = pdfContentObject.Name;
            FileContentBox.Text = pdfContentObject.Text;
        }
    }
}
