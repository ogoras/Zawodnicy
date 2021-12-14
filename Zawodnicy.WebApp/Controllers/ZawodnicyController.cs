using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Zawodnicy.WebApp.Models;

namespace Zawodnicy.WebApp.Controllers
{
    public class ZawodnicyController : Controller
    {
        public IConfiguration Configuration;

        public ZawodnicyController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult GetApiUrl()
        {
            var result = Configuration["RestApiUrl"];
            return Content(result);
        }

        private string CN()
        {
            return ControllerContext.RouteData.Values["controller"].ToString();
        }

        public async Task<IActionResult> Index()
        {
            string _restpath = GetApiUrl().Content + CN();
            List<ZawodnikVM> zawodnikList = new List<ZawodnikVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    zawodnikList = JsonConvert.DeserializeObject<List<ZawodnikVM>>(apiResponse);
                }
            }

            return View(zawodnikList);
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetApiUrl().Content + CN();
            ZawodnikVM zawodnik = new ZawodnikVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    zawodnik = JsonConvert.DeserializeObject<ZawodnikVM>(apiResponse);
                }
            }

            return View(zawodnik);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ZawodnikVM z)
        {
            string _restpath = GetApiUrl().Content + CN();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string zawodnikJson = System.Text.Json.JsonSerializer.Serialize(z);
                    var content = new StringContent(zawodnikJson, Encoding.UTF8, "application/json");

                    await httpClient.PutAsync($"{_restpath}/{z.Id}", content);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ZawodnikVM z)
        {
            string _restpath = GetApiUrl().Content + CN();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string zawodnikJson = System.Text.Json.JsonSerializer.Serialize(z);
                    var content = new StringContent(zawodnikJson, Encoding.UTF8, "application/json");

                    await httpClient.PostAsync($"{_restpath}", content);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
