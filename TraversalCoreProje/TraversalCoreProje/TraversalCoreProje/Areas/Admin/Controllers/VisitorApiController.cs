using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; // JsonConvert sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http; // IHttpClientFactory interface'ni kullanabilmek için bu kütüphaneyi ekledik
using System.Text; // Encoding sınıfını kullanabilmek için ekledik
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models; // VisitorViewModel sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/VisitorApi")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            /* adresi TraversalApiProject içinde Get yapınca oluşan adresten alıyoruz get try it execute dediğimizde oluşan adres*/
            var responseMessage = await client.GetAsync("http://localhost:26901/api/Visitor");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // ilgili içeriği okuyacak
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData); // json format olan bilgileri json formattan çıkardık
                return View(values);
            }
            return View();
        }

        [Route("AddVisitor")]
        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View();
        }

        [Route("AddVisitor")]
        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorViewModel p)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(p); // p parametresinden gelen bilgileri json formata çevirdik
            // StringContent HttpContenten miras alıyor
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:26901/api/Visitor",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Route("DeleteVisitor/{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:26901/api/Visitor/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Route("UpdateVisitor/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:26901/api/Visitor/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData); // gelen parametreyi json formatı dışına çıkardık
                return View(values);
            }
            else
            {
                return View();
            }
        }

        [Route("UpdateVisitor/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel v)
        {
      
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(v); // v parametresinden gelen bilgileri json formata çevirdik
                // StringContent HttpContenten miras alıyor
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:26901/api/Visitor", content);
                if (responseMessage.IsSuccessStatusCode)
                {

                   return RedirectToAction("Index");
            }
                else
                {
                return RedirectToAction("Index");
                } 
        }
    }
}
