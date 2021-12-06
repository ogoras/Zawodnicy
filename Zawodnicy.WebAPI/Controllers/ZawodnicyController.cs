using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;

namespace Zawodnicy.WebAPI.Controllers
{
    [Route("[controller]")]
    public class ZawodnicyController : Controller
    {
        private readonly IZawodnikService _zawodnikService;

        public ZawodnicyController(IZawodnikService zawodnikService)
        {
            _zawodnikService = zawodnikService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<ZawodnikDTO> z = await _zawodnikService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ZawodnikDTO z = await _zawodnikService.GetZawodnik(id);
            if (z == null)
            {
                return NotFound();
            }
            return Json(z);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByCountry(string country)
        {
            IEnumerable<ZawodnikDTO> z = await _zawodnikService.GetZawodnicyByCountry(country);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateZawodnik zawodnik)
        {
            ZawodnikDTO z = new ZawodnikDTO()
            {
                Id = zawodnik.Id,
                //IdTrenera = zawodnik.Trener.Id,
                Imie = zawodnik.Imie,
                Nazwisko = zawodnik.Nazwisko,
                Kraj = zawodnik.Kraj,
                DataUr = zawodnik.DataUr,
                Waga = zawodnik.Waga,
                Wzrost = zawodnik.Wzrost
            };
            await _zawodnikService.CreateZawodnik(z);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateZawodnik zawodnik, int id)
        {
            ZawodnikDTO original_z = await _zawodnikService.GetZawodnik(id);
            if (original_z == null)
            {
                return NotFound();
            }

            ZawodnikDTO z = new ZawodnikDTO()
            {
                Id = id,
                //IdTrenera = zawodnik.Trener.Id,
                Imie = zawodnik.Imie != null ? zawodnik.Imie : original_z.Imie,
                Nazwisko = zawodnik.Nazwisko != null ? zawodnik.Nazwisko : original_z.Nazwisko,
                Kraj = zawodnik.Kraj != null ? zawodnik.Kraj : original_z.Kraj,
                DataUr = zawodnik.DataUr != DateTime.Parse("0001-01-01T00:00:00") ? zawodnik.DataUr : original_z.DataUr,
                Waga = zawodnik.Waga != 0 ? zawodnik.Waga : original_z.Waga,
                Wzrost = zawodnik.Wzrost != 0 ? zawodnik.Wzrost : original_z.Wzrost
            };
            await _zawodnikService.UpdateZawodnik(z);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _zawodnikService.DeleteZawodnik(id);

            return Ok();
        }
    }
}
