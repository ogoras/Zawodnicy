using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public class TrenerService : ITrenerService
    {
        public Task<IEnumerable<TrenerDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task CreateTrener(TrenerDTO t)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTrener(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TrenerDTO> GetTrener(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTrener(TrenerDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
