using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    class ZawodyRepository : IZawodyRepository
    {
        public Task AddAsync(Zawody z)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Zawody>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Zawody z)
        {
            throw new NotImplementedException();
        }

        public Task<Zawody> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Zawody z)
        {
            throw new NotImplementedException();
        }
    }
}
