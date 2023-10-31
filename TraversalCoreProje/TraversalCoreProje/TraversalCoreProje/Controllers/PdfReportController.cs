using iTextSharp.text; // A4 bilgisi gelmesi için bu kütüphaneyi ekledik
using iTextSharp.text.pdf; // PdfWriter sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO; // Path sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");
            document.Add(paragraph);
            document.Close();
            return File("/PdfReports/dosya1.pdf", "application/pdf", "dosya1.pdf");

        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);

            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Deneme");
            pdfPTable.AddCell("deneme");
            pdfPTable.AddCell("11111111111");

            pdfPTable.AddCell("deneme");
            pdfPTable.AddCell("deneme");
            pdfPTable.AddCell("22222222222");

            pdfPTable.AddCell("deneme");
            pdfPTable.AddCell("deneme");
            pdfPTable.AddCell("333333333333");

            document.Add(pdfPTable);

            document.Close();
            return File("/PdfReports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
