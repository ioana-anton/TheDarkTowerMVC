using Aspose.Pdf;

namespace TheDarkTowerMVC.Utils.FileStrategyDP
{
    public class PdfFileStrategy : FileStrategy
    {
        public override void CreateFile(string input)
        {
            // Initialize document object
            Document document = new Document();

            // Add page
            Page page = document.Pages.Add();

            // Add text to new page
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(input));

            // Save PDF 
            document.Save("Document.pdf");
        }
    }
}
