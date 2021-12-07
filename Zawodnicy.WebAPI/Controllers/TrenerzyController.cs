using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;

namespace Zawodnicy.WebAPI.Controllers
{
    [Route("[controller]")]
    public class TrenerzyController : Controller
    {
        private readonly ITrenerService _trenerService;

        public TrenerzyController(ITrenerService trenerService)
        {
            _trenerService = trenerService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<TrenerDTO> z = await _trenerService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TrenerDTO z = await _trenerService.GetTrener(id);
            if (z == null)
            {
                return NotFound();
            }
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTrener trener)
        {
            TrenerDTO z = new TrenerDTO()
            {
                Imie = trener.Imie,
                Nazwisko = trener.Nazwisko,
                DataUr = trener.DataUr
            };
            await _trenerService.CreateTrener(z);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateTrener trener, int id)
        {
            TrenerDTO original_z = await _trenerService.GetTrener(id);
            if (original_z == null)
            {
                return NotFound();
            }

            TrenerDTO z = new TrenerDTO()
            {
                Id = id,
                Imie = trener.Imie != null ? trener.Imie : original_z.Imie,
                Nazwisko = trener.Nazwisko != null ? trener.Nazwisko : original_z.Nazwisko,
                DataUr = trener.DataUr != DateTime.Parse("0001-01-01T00:00:00") ? trener.DataUr : original_z.DataUr
            };
            await _trenerService.UpdateTrener(z);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _trenerService.DeleteTrener(id);

            return Ok();
        }
    }
}
