using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface IZawodyRepository
    {
        Task UpdateAsync(Zawody z);
        Task AddAsync(Zawody z);
        Task DelAsync(Zawody z);
        Task<Zawody> GetAsync(int id);
        Task<IEnumerable<Zawody>> BrowseAllAsync();
    }
}
