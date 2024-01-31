using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Parser.Utility
{
    public class PdfContentObject
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }

        public PdfContentObject(string path, string name, string text) 
        {
            Path = path;
            Name = name;
            Text = text;
        }

        public override string ToString()
        {
            /*
             * Important:
             * The ListBox should display the Name property of the PdfContentObject instead of the default string representation.
             */

            return Name;
        }
    }
}
