using Newtonsoft.Json;

namespace PDF_Parser.Utility
{
    public class JsonHelper
    {
        public static string ConvertPdfContentObjectToJson(PdfContentObject item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public static PdfContentObject ConvertJsonToPdfContentObject(string jsonString)
        {
            return JsonConvert.DeserializeObject<PdfContentObject>(jsonString);
        }
    }
}
