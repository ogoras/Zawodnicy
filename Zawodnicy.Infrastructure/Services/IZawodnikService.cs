using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public interface IZawodnikService
    {
        Task<IEnumerable<ZawodnikDTO>> BrowseAll();
        Task<ZawodnikDTO> GetZawodnik(int id);
        Task<IEnumerable<ZawodnikDTO>> GetZawodnicyByCountry(string country);
        Task CreateZawodnik(ZawodnikDTO z);
        Task UpdateZawodnik(ZawodnikDTO z);
        Task DeleteZawodnik(int id);
    }
}
