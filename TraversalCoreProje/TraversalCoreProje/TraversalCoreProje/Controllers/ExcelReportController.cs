using BusinessLayer.Abstract; // IExcelService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using ClosedXML.Excel; // XMLWorkbook sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için bu kütüphaneyi yükledik
using EntityLayer.Concreate; // Destination sınıfını kullanabilmek için bu kütüphaneyi ekliyoruz
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml; //ExcelPackage sınıfını kullanabilmek için bu kütüphaneyi yükledik
using System;
using System.Collections.Generic;
using System.IO; // MemoryStream sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Models; // DestinationModel sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.Controllers
{
    public class ExcelReportController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelReportController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
          
        }

        public List<DestinationModel> destinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using(var c=new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    Price = x.Price,
                    DayNight = x.DayNight,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModels;
        }
        public IActionResult StaticExcelReport()
        {  
            return File(_excelService.ExcelList(destinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","YeniExcel.xlsx");
        }
        public IActionResult DestinationExcelReport()
        {
            /*ClosedXml NuGet pakettini indiriyoruz*/
            using(var workbook=new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Tur Listesi");
                worksheet.Cell(1, 1).Value = "Şehir";
                worksheet.Cell(1, 2).Value = "Konaklama Süresi";
                worksheet.Cell(1, 3).Value = "Fiyat";
                worksheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;
                foreach(var item in destinationList())
                {
                    worksheet.Cell(rowCount, 1).Value = item.City;
                    worksheet.Cell(rowCount, 2).Value = item.DayNight;
                    worksheet.Cell(rowCount, 3).Value = item.Price;
                    worksheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }
                using(var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
         
            }
        }


    }
}
