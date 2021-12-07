using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class ZawodnicyRepository : IZawodnicyRepository
    {
        private AppDbContext _appDbContext;

        public ZawodnicyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Zawodnik z)
        {
            try
            {
                _appDbContext.Zawodnik.Add(z);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Zawodnik>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Zawodnik.Include(z => z.Trener).ToList());
        }

        public async Task DelAsync(Zawodnik z)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Zawodnik.FirstOrDefault(x => x.Id == z.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Zawodnik> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Zawodnik.Include(z => z.Trener).FirstOrDefault(x=>x.Id==id));
        }

        public async Task<IEnumerable<Zawodnik>> GetByCountryAsync(string country)
        {
            return await Task.FromResult(_appDbContext.Zawodnik.Where(x => x.Kraj == country));
        }

        public async Task UpdateAsync(Zawodnik z)
        {
            try
            {
                var zaw = _appDbContext.Zawodnik.FirstOrDefault(x => x.Id == z.Id);

                zaw.Imie = z.Imie;
                zaw.Nazwisko = z.Nazwisko;
                zaw.DataUr = z.DataUr;
                zaw.Waga = z.Waga;
                zaw.Kraj = z.Kraj;
                zaw.Wzrost = z.Wzrost;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
