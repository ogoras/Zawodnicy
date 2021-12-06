using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAsync(Trener t)
        {
            try
            {
                _appDbContext.Trener.Add(t);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Trener>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Trener);
        }

        public async Task DelAsync(Trener t)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Trener.FirstOrDefault(x => x.Id == t.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Trener> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Trener.FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdateAsync(Trener t)
        {
            try
            {   
                var tren = _appDbContext.Trener.FirstOrDefault(x => x.Id == t.Id);

                tren.Imie = t.Imie;
                tren.Nazwisko = t.Nazwisko;
                tren.DataUr = t.DataUr;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
