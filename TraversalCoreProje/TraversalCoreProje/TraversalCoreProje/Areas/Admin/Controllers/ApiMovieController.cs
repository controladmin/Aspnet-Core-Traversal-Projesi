using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http; // HttpClient sınıfını kullanabilmek için bu kütüphaneyi ekliyoruz
using TraversalCoreProje.Areas.Admin.Models; // ApiMovieViewModel sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Newtonsoft.Json; // JsonCnvert sınıfını kullanabilmek için bu kütüphaneyi ekliyoruz

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApiMovieController : Controller
    {

		List<ApiMovieViewModel> apiMovies = new List<ApiMovieViewModel>();  // bu class'tan bir liste oluşturduk
		
        public async  Task<IActionResult> Index()
        {
			/* metotlar asenkron geldiği için async olarak ayarladık IActionResult kısmını*/

			/* Bu kodu https://rapidapi.com/hub sitesinden alıyoruz üye olup ücretsiz olarak aylık 500 api desteği veriyor*/
		
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
	{
		{ "X-RapidAPI-Key", "e1439ff560mshacb89d7b78e3eb7p196341jsn4a5a446ad70c" },
		{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				apiMovies = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body); // body json verisini json formattan çıkarıp list olarak atadık
				return View(apiMovies);
			}
		}
    }
}
