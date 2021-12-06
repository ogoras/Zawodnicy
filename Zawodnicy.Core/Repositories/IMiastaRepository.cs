using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface IMiastaRepository
    {
        Task UpdateAsync(Miasto m);
        Task AddAsync(Miasto m);
        Task DelAsync(Miasto m);
        Task<Miasto> GetAsync(int id);
        Task<IEnumerable<Miasto>> BrowseAllAsync();
    }
}
