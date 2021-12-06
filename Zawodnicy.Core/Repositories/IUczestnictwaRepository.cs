using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface IUczestnictwaRepository
    {
        Task UpdateAsync(Uczestnictwo u);
        Task AddAsync(Uczestnictwo u);
        Task DelAsync(Uczestnictwo u);
        Task<Uczestnictwo> GetAsync(int id);
        Task<IEnumerable<Uczestnictwo>> BrowseAllAsync();
    }
}
