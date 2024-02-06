using Newtonsoft.Json;
using System.Collections.Generic;

namespace PDF_Parser.Utility
{
    public class JsonHelper
    {
        public static string ConvertListToJson(List<PdfContentObject> pdfContentObjects)
        {
            return JsonConvert.SerializeObject(pdfContentObjects);
        }

        public static List<PdfContentObject> ConvertJsonToList(string jsonString)
        {
            return JsonConvert.DeserializeObject<List<PdfContentObject>>(jsonString);
        }
    }
}
