using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PDF_Parser.Utility
{
    public class DataboxController
    {
        public static void ClearContentBox(ListBox contentbox)
        {
            contentbox?.Invoke((Action)(()
                => contentbox.Items.Clear()));
        }

        public static void FillContentBox(ListBox contentbox, PdfContentObject pdfContentObject)
        {
            contentbox?.Invoke((Action)(()
                => contentbox.Items.Add(pdfContentObject)));
        }

        public static List<PdfContentObject> CreateLocalList(List<PdfContentObject> pdfContentObjects, string filter)
        {
            List<PdfContentObject> localList = new List<PdfContentObject>();
            foreach (PdfContentObject item in pdfContentObjects)
            {
                if (item.Text.ToLower().Contains(filter.ToLower()))
                {
                    localList.Add(item);
                }
            }
            return localList;
        }
    }
}
