using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    class UczestnictwaRepository : IUczestnictwaRepository
    {
        public Task AddAsync(Uczestnictwo u)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Uczestnictwo>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Uczestnictwo u)
        {
            throw new NotImplementedException();
        }

        public Task<Uczestnictwo> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Uczestnictwo u)
        {
            throw new NotImplementedException();
        }
    }
}
