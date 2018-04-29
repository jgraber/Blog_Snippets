using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Collections.Generic;
using System.IO;

namespace CombinePDF
{
    public class PdfHelper
    {
        public void CombineFiles(List<Stream> files, string outputFilePath)
        {
            // the new file to store the combined documents
            PdfDocument outputDocument = new PdfDocument();

            foreach (Stream file in files)
            {
                // Attention: must be in Import mode
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);

                int totalPages = inputDocument.PageCount;
                for (int pageNumber = 0; pageNumber < totalPages; pageNumber++)
                {
                    // Get the page from the input document...
                    PdfPage page = inputDocument.Pages[pageNumber];

                    // ...and copy it to the output document.
                    outputDocument.AddPage(page);
                }
            }

            // Save the document
            outputDocument.Save(outputFilePath);
        }

        public int CountPages(string filePath)
        {
            PdfDocument inputDocument = PdfReader.Open(filePath);
            var pages = inputDocument.PageCount;
            inputDocument.Close();

            return pages;
        }
    }
}
