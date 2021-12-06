using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ISkocznieRepository
    {
        Task UpdateAsync(Skocznia s);
        Task AddAsync(Skocznia s);
        Task DelAsync(Skocznia s);
        Task<Skocznia> GetAsync(int id);
        Task<IEnumerable<Skocznia>> BrowseAllAsync();
    }
}
