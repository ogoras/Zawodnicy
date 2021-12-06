using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    class SkocznieRepository : ISkocznieRepository
    {
        public Task AddAsync(Skocznia s)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Skocznia>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Skocznia s)
        {
            throw new NotImplementedException();
        }

        public Task<Skocznia> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Skocznia s)
        {
            throw new NotImplementedException();
        }
    }
}
