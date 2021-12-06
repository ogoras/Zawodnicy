using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface IZawodnicyRepository
    {
        Task UpdateAsync(Zawodnik z);
        Task AddAsync(Zawodnik z);
        Task DelAsync(Zawodnik z);
        Task<Zawodnik> GetAsync(int id);
        Task<IEnumerable<Zawodnik>> BrowseAllAsync();
        Task<IEnumerable<Zawodnik>> GetByCountryAsync(string country);
    }
}
