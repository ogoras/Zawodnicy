using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class TrenerzyRepository : ITrenerzyRepository
    {
        private AppDbContext _appDbContext;

        public TrenerzyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task AddAsync(Trener t)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Trener>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Trener t)
        {
            throw new NotImplementedException();
        }

        public Task<Trener> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Trener t)
        {
            throw new NotImplementedException();
        }
    }
}
