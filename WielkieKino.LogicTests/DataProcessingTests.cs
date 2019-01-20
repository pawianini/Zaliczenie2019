using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Logic;
using WielkieKino.Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Logic.Tests
{
    [TestClass()]
    public class DataProcessingTests
    {
        [TestMethod()]
        public void ZwrocFilmNaKtorySprzedanoNajwiecejBiletowTest()
        {

            DataProcessing dp = new DataProcessing();

            Assert.IsTrue(dp.ZwrocFilmNaKtorySprzedanoNajwiecejBiletow(SkladDanych.Filmy, SkladDanych.Bilety).Tytul == "Konan Destylator");
        }

        [TestMethod()]
        public void ZwrocSaleGdzieJestNajwiecejSeansowTest()
        {
            DataProcessing dp = new DataProcessing();

            Assert.IsTrue(dp.ZwrocSaleGdzieJestNajwiecejSeansow(SkladDanych.Seanse, new DateTime(2019, 01, 20)).Nazwa == "Wisła");
        }

        [TestMethod()]
        public void NajpopularniejszyGatunekTest()
        {
            DataProcessing dp = new DataProcessing();

            Assert.IsTrue(dp.NajpopularniejszyGatunek(SkladDanych.Filmy) == "Obyczajowy");
        }

        [TestMethod()]
        public void WybierzFilmyPokazywaneDanegoDniaTest()
        {
            Assert.Fail();
        }
    }
}