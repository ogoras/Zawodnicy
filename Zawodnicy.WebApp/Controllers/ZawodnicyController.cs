using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public async Task<IActionResult> IndexAsync()
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
    }
}
