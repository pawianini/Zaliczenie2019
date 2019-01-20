using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Dane.Tests
{
    [TestClass()]
    public class MetodyPomocniczeTests
    {
        [TestMethod()]
        public void CzyMoznaKupicBiletTest()
        {
            MetodyPomocnicze met = new MetodyPomocnicze();

            Assert.IsTrue(met.CzyMoznaKupicBilet(SkladDanych.Bilety, SkladDanych.Seanse[0], 2, 1) == true);
            Assert.IsTrue(met.CzyMoznaKupicBilet(SkladDanych.Bilety, SkladDanych.Seanse[0], 5, 5) == false);
        }

        [TestMethod()]
        public void CzyMoznaDodacSeansTest()
        {
            MetodyPomocnicze met = new MetodyPomocnicze();
            Assert.IsTrue(met.CzyMoznaDodacSeans(SkladDanych.Seanse,  SkladDanych.Sale[0], SkladDanych.Filmy[0], new DateTime(2019, 01, 20, 13,00, 00))==false);
        }

        [TestMethod()]
        public void LiczbaWolnychMiejscWSaliTest()
        {
            MetodyPomocnicze met = new MetodyPomocnicze();
            Assert.IsTrue(met.LiczbaWolnychMiejscWSali(SkladDanych.Bilety, SkladDanych.Seanse[0]) == 72);
        }

        [TestMethod()]
        public void CalkowitePrzychodyZBiletowTest()
        {
            MetodyPomocnicze met = new MetodyPomocnicze();
            Assert.IsTrue(met.CalkowitePrzychodyZBiletow(SkladDanych.Bilety) == 400);
        }
    }
}