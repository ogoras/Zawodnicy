using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public class TrenerService : ITrenerService
    {
        private readonly ITrenerzyRepository _trenerzyRepository;

        public TrenerService(ITrenerzyRepository trenerzyRepository)
        {
            _trenerzyRepository = trenerzyRepository;
        }
        public async Task<IEnumerable<TrenerDTO>> BrowseAll()
        {
            var t = await _trenerzyRepository.BrowseAllAsync();

            return t.Select(x => new TrenerDTO()
            {
                Id = x.Id,
                Imie = x.Imie,
                Nazwisko = x.Nazwisko,
                DataUr = x.DataUr,
            });
        }

        public async Task CreateTrener(TrenerDTO t)
        {
            Trener trener = new Trener()
            {
                Id = t.Id,
                Imie = t.Imie,
                Nazwisko = t.Nazwisko,
                DataUr = t.DataUr,
            };
            await _trenerzyRepository.AddAsync(trener);
        }

        public async Task DeleteTrener(int id)
        {
            Trener t = await _trenerzyRepository.GetAsync(id);
            await _trenerzyRepository.DelAsync(t);
        }

        public async Task<TrenerDTO> GetTrener(int id)
        {
            Trener t = await _trenerzyRepository.GetAsync(id);
            if (t == null)
            {
                return null;
            }

            return new TrenerDTO()
            {
                Id = t.Id,
                Imie = t.Imie,
                Nazwisko = t.Nazwisko,
                DataUr = t.DataUr
            };
        }

        public async Task UpdateTrener(TrenerDTO t)
        {
            Trener trener = new Trener()
            {
                Id = t.Id,
                Imie = t.Imie,
                Nazwisko = t.Nazwisko,
                DataUr = t.DataUr,
            };
            await _trenerzyRepository.UpdateAsync(trener);
        }
    }
}
