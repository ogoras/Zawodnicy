using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public class ZawodnikService : IZawodnikService
    {
        private readonly IZawodnicyRepository _zawodnicyRepository;
        private readonly ITrenerzyRepository _trenerzyRepository;

        public ZawodnikService(IZawodnicyRepository zawodnicyRepository, ITrenerzyRepository trenerzyRepository)
        {
            _zawodnicyRepository = zawodnicyRepository;
            _trenerzyRepository = trenerzyRepository;
        }

        public async Task<IEnumerable<ZawodnikDTO>> BrowseAll()
        {
            var z = await _zawodnicyRepository.BrowseAllAsync();

            return z.Select(x => new ZawodnikDTO()
            {
                Id = x.Id,
                IdTrenera = x.Trener.Id,
                Imie = x.Imie,
                Nazwisko = x.Nazwisko,
                Kraj = x.Kraj,
                DataUr = x.DataUr,
                Waga = x.Waga,
                Wzrost = x.Wzrost
            });
        }

        public async Task<IEnumerable<ZawodnikDTO>> GetZawodnicyByCountry(string country)
        {
            var z = await _zawodnicyRepository.GetByCountryAsync(country);

            return z.Select(x => new ZawodnikDTO()
            {
                Id = x.Id,
                IdTrenera = x.Trener.Id,
                Imie = x.Imie,
                Nazwisko = x.Nazwisko,
                Kraj = x.Kraj,
                DataUr = x.DataUr,
                Waga = x.Waga,
                Wzrost = x.Wzrost
            });
        }

        public async Task<ZawodnikDTO> GetZawodnik(int id)
        {
            Zawodnik z = await _zawodnicyRepository.GetAsync(id);
            if (z == null)
            {
                return null;
            }

            return new ZawodnikDTO()
            {
                Id = z.Id,
                IdTrenera = z.Trener.Id,
                Imie = z.Imie,
                Nazwisko = z.Nazwisko,
                Kraj = z.Kraj,
                DataUr = z.DataUr,
                Waga = z.Waga,
                Wzrost = z.Wzrost
            };
        }

        public async Task CreateZawodnik(ZawodnikDTO z)
        {
            Zawodnik zawodnik = new Zawodnik()
            {
                Id = z.Id,
                Trener = await _trenerzyRepository.GetAsync(z.IdTrenera),
                Imie = z.Imie,
                Nazwisko = z.Nazwisko,
                Kraj = z.Kraj,
                DataUr = z.DataUr,
                Waga = z.Waga,
                Wzrost = z.Wzrost
            };
            await _zawodnicyRepository.AddAsync(zawodnik);
        }

        public async Task UpdateZawodnik(ZawodnikDTO z)
        {
            Zawodnik zawodnik = new Zawodnik()
            {
                Id = z.Id,
                Trener = await _trenerzyRepository.GetAsync(z.IdTrenera),
                Imie = z.Imie,
                Nazwisko = z.Nazwisko,
                Kraj = z.Kraj,
                DataUr = z.DataUr,
                Waga = z.Waga,
                Wzrost = z.Wzrost
            };
            await _zawodnicyRepository.UpdateAsync(zawodnik);
        }

        public async Task DeleteZawodnik(int id)
        {
            Zawodnik z = await _zawodnicyRepository.GetAsync(id);
            await _zawodnicyRepository.DelAsync(z);
        }
    }
}
