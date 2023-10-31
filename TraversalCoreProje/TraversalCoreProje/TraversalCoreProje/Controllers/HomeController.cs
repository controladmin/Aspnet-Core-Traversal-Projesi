﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /* bu kodu biz ekledik*/
            _logger.LogInformation("Index Sayfası Çağrıldı");
            _logger.LogInformation("Error Log Çağrıldı");
            return View();
        }

        public IActionResult Privacy()
        {
            /* bu kodu biz ekledik*/
            DateTime dt =Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            _logger.LogInformation(dt+" Privacy Sayfası Çağrıldı");
            return View();
        }
        public IActionResult Test()
        {
            /* bu kodu biz ekledik*/
            _logger.LogInformation("Test Sayfası Çağrıldı");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
