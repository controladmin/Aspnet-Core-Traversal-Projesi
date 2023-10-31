using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http; // HttpClient sınıfını kullanabilmek için bu kütüphaneyi ekledik
using TraversalCoreProje.Areas.Admin.Models; // BookingExchangeViewModel sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Newtonsoft.Json; // JsonConvert sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ApiExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
			List<BookingExchangeViewModel2> exchangeViewModel2 = new List<BookingExchangeViewModel2>();
			
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
				Headers =
	{
		{ "X-RapidAPI-Key", "e1439ff560mshacb89d7b78e3eb7p196341jsn4a5a446ad70c" },
		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values= JsonConvert.DeserializeObject<BookingExchangeViewModel2>(body);
				return View(values.exchange_rates); // exchaneg_rates'ten veri geliyor 
			}
		}
    }
}
