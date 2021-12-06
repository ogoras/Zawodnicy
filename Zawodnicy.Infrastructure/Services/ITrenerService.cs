using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public interface ITrenerService
    {
        Task<IEnumerable<TrenerDTO>> BrowseAll();
        Task<TrenerDTO> GetTrener(int id);
        Task CreateTrener(TrenerDTO t);
        Task UpdateTrener(TrenerDTO t);
        Task DeleteTrener(int id);
    }
}
