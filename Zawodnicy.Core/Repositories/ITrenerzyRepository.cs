using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ITrenerzyRepository
    {
        Task UpdateAsync(Trener t);
        Task AddAsync(Trener t);
        Task DelAsync(Trener t);
        Task<Trener> GetAsync(int id);
        Task<IEnumerable<Trener>> BrowseAllAsync();
    }
}
