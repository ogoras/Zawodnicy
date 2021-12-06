using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;
using System.Linq;

namespace Zawodnicy.Test
{
    [TestClass]
    public class ZawodnikServiceTest
    {/*
        private static Mock<IZawodnicyRepository> _Mock;
        private static Zawodnik _Z1, _Z2, _Z3;
        private static void AssertZawodnikEqualToDTO(ZawodnikDTO dto, Zawodnik z)
        {
            Assert.AreEqual(z.Imie, dto.Imie);
            Assert.AreEqual(z.Nazwisko, dto.Nazwisko);
            Assert.AreEqual(z.DataUr, dto.DataUr);
            Assert.AreEqual(z.Kraj, dto.Kraj);
            Assert.AreEqual(z.Waga, dto.Waga);
            Assert.AreEqual(z.Wzrost, dto.Wzrost);
            Assert.AreEqual(z.Id, dto.Id);
        }

        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            _Mock = new Mock<IZawodnicyRepository>();
            _Z1 = new Zawodnik()
            {
                Id = 2,
                Imie = "Artur",
                Nazwisko = "SM",
                Kraj = "Niemcy",
                Waga = 80,
                Wzrost = 179,
                DataUr = DateTime.Parse("2001-05-06")
            };
            _Z2 = new Zawodnik()
            {
                Id = 3,
                Imie = "Michael",
                Nazwisko = "Rhodes",
                Kraj = "Wielka Brytania",
                Waga = 77,
                Wzrost = 180,
                DataUr = DateTime.Parse("2000-07-04")
            };
            _Z3 = new Zawodnik()
            {
                Id = 4,
                Imie = "Angel",
                Nazwisko = "Heiser",
                Kraj = "Niemcy",
                Waga = 82,
                Wzrost = 181,
                DataUr = DateTime.Parse("1999-04-06")
            };
        }

        [TestMethod]
        public async Task GetExistingPlayerAsync()
        {
            _Mock.Setup(p => p.GetAsync(2)).Returns(Task.FromResult(_Z1));
            ZawodnikService service = new ZawodnikService((IZawodnicyRepository)_Mock.Object);

            ZawodnikDTO dto = await service.GetZawodnik(2);

            AssertZawodnikEqualToDTO(dto, _Z1);
        }

        [TestMethod]
        public async Task GetNonExistentPlayerAsync()
        {
            _Mock.Setup(p => p.GetAsync(2)).Returns(Task.FromResult<Zawodnik>(null));
            ZawodnikService service = new ZawodnikService((IZawodnicyRepository)_Mock.Object);

            ZawodnikDTO dto = await service.GetZawodnik(2);

            Assert.IsNull(dto);
        }

        [TestMethod]
        public async Task GetNoPlayersByCountryAsync()
        {
            _Mock.Setup(p => p.GetByCountryAsync("Atlantyda")).Returns(Task.FromResult<IEnumerable<Zawodnik>>(new List<Zawodnik>()));
            ZawodnikService service = new ZawodnikService((IZawodnicyRepository)_Mock.Object);

            IEnumerable<ZawodnikDTO> dto_list = await service.GetZawodnicyByCountry("Atlantyda");

            Assert.AreEqual(dto_list.Count(), 0);
        }

        [TestMethod]
        public async Task GetOnePlayerByCountryAsync()
        {
            Zawodnik[] zawodnicy = { _Z2 };
            _Mock.Setup(p => p.GetByCountryAsync("Wielka Brytania")).Returns(Task.FromResult<IEnumerable<Zawodnik>>(new List<Zawodnik>(zawodnicy)));
            ZawodnikService service = new ZawodnikService((IZawodnicyRepository)_Mock.Object);

            IEnumerable<ZawodnikDTO> dto_list = await service.GetZawodnicyByCountry("Wielka Brytania");

            Assert.AreEqual(dto_list.Count(), 1);

            ZawodnikDTO dto = dto_list.First();
            AssertZawodnikEqualToDTO(dto, _Z2);
        }

        [TestMethod]
        public async Task GetMultiplePlayersByCountryAsync()
        {
            Zawodnik[] zawodnicy = { _Z1, _Z3 };
            _Mock.Setup(p => p.GetByCountryAsync("Niemcy")).Returns(Task.FromResult<IEnumerable<Zawodnik>>(new List<Zawodnik>(zawodnicy)));
            ZawodnikService service = new ZawodnikService((IZawodnicyRepository)_Mock.Object);

            IEnumerable<ZawodnikDTO> dto_list = await service.GetZawodnicyByCountry("Niemcy");

            Assert.AreEqual(dto_list.Count(), 2);

            foreach(ZawodnikDTO dto in dto_list)
            {
                Assert.AreEqual("Niemcy", dto.Kraj);
            }
        }

        [TestMethod]
        public async Task CreatePlayerAsync()
        {
            ZawodnikDTO dto = new ZawodnikDTO()
            {
                Id = _Z1.Id,
                Imie = _Z1.Imie,
                Nazwisko = _Z1.Nazwisko,
                Kraj = _Z1.Kraj,
                Waga = _Z1.Waga,
                Wzrost = _Z1.Wzrost,
                DataUr = _Z1.DataUr
            };
            ZawodnikService service = new ZawodnikService((IZawodnicyRepository)_Mock.Object);

            await service.CreateZawodnik(dto);

            _Mock.Verify(p => p.AddAsync(_Z1), Times.Once);
        }

        [TestMethod]
        public async Task UpdatePlayerAsync()
        {
            ZawodnikDTO dto = new ZawodnikDTO()
            {
                Id = _Z1.Id,
                Imie = _Z1.Imie,
                Nazwisko = _Z1.Nazwisko,
                Kraj = _Z1.Kraj,
                Waga = _Z1.Waga,
                Wzrost = _Z1.Wzrost,
                DataUr = _Z1.DataUr
            };
            ZawodnikService service = new ZawodnikService((IZawodnicyRepository)_Mock.Object);

            await service.UpdateZawodnik(dto);

            _Mock.Verify(p => p.UpdateAsync(_Z1), Times.Once);
        }


        [TestMethod]
        public async Task DeleteExistingPlayerAsync()
        {
            _Mock.Setup(p => p.GetAsync(2)).Returns(Task.FromResult<Zawodnik>(_Z1));
            ZawodnikService service = new ZawodnikService((IZawodnicyRepository)_Mock.Object);

            await service.DeleteZawodnik(2);

            _Mock.Verify(p => p.DelAsync(_Z1), Times.Once);
        }

        [TestMethod]
        public async Task DeleteNonExistentPlayerAsync()
        {
            _Mock.Setup(p => p.GetAsync(2)).Returns(Task.FromResult<Zawodnik>(null));
            ZawodnikService service = new ZawodnikService((IZawodnicyRepository)_Mock.Object);

            await service.DeleteZawodnik(2);

            _Mock.Verify(p => p.DelAsync(null), Times.Once);
        } */
    }
}
