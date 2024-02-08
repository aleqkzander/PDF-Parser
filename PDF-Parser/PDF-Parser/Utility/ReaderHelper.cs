using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using System;
using System.Text;

namespace PDF_Parser.Utility
{
    public class ReaderHelper
    {
        public static string Read(string path)
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

                            if (strategy == null) return string.Empty;

                            // Parse the content of the page and extract text
                            string pageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNumber), strategy);

                            // Append the extracted text to the StringBuilder
                            text.AppendLine(pageText);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                // Handle exceptions, e.g., if the PDF file is password-protected or corrupted
                text.AppendLine($"Error reading PDF file\n\n{exception}");
            }

            return text.ToString();
        }
    }
}
