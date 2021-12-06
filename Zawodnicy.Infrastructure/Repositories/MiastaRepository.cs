using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    class MiastaRepository : IMiastaRepository
    {
        public Task AddAsync(Miasto m)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Miasto>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Miasto m)
        {
            throw new NotImplementedException();
        }

        public Task<Miasto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Miasto m)
        {
            throw new NotImplementedException();
        }
    }
}
