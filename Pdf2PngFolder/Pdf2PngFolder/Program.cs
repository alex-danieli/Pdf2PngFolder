using PdfiumViewer;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Pdf2PngFolder
{

 
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        #region Convert Main Method
        private static Image GetPageImage(int pageNumber, Size size, PdfiumViewer.PdfDocument document, int dpi)
        {
            return document.Render(pageNumber - 1, size.Width, size.Height, dpi, dpi, PdfRenderFlags.Annotations);
        }

        private static void ExportPdfPageToPng(PdfDocument document, int pageNumber, string outputPath, int dpi)
        {

                  
            
            // PdfDocument document = PdfiumViewer.PdfDocument.Load(pdfPath);
            FileStream stream = new FileStream(outputPath, FileMode.Create);
            Size pageSize = document.PageSizes[pageNumber-1].ToSize();

            pageSize.Width = pageSize.Width * 2;
            pageSize.Height = pageSize.Height * 2;


            Image image = Program.GetPageImage(pageNumber, pageSize, document, dpi);
            
            Debug.WriteLine("Page size: " + pageSize);
            image.Save(stream, ImageFormat.Png);
            stream.Close();
            
        }
        #endregion

        public static void ConvertPdfToPngPages(string pdfPath, int dpi)
        {
            PdfDocument document = PdfiumViewer.PdfDocument.Load(pdfPath);
            int numberOfPages = document.PageCount;
            for (int currentPage = 1; currentPage <= numberOfPages; currentPage++)
            {
                ExportPdfPageToPng(document, currentPage, pdfPath+"_page"+currentPage+".png", dpi);
            }

        }



        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // ExportPdfPageToPng("prova.pdf", 1,"prova.jpg",150);
            Application.Run(new Form1());
        }





    }
}