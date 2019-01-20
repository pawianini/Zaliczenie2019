using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.App
{
    public class Program
    {
        /// <summary>
        /// Na podstawie danych seansu i sprzedanych biletów należy wyświetlić "podgląd"
        /// sali w ten sposób, że: każdy rząd to jedna linia tekstu, znaków w linii
        /// ma być tyle ile miejsc w rzędzie, miejsca zajęte są inaczej oznaczone niż
        /// miejsca wolne.
        /// </summary>
        /// <param name="sprzedaneBilety"></param>
        /// <param name="seans"></param>
        private static void WyswietlPodgladSali(List<Bilet> sprzedaneBilety, Seans seans)
        {
            for (int i = 1; i < seans.Sala.LiczbaRzedow+1; i++)
            {
                
                for (int j = 1; j < seans.Sala.LiczbaMiejscWRzedzie + 1; j++)
                {
                    if (sprzedaneBilety.Where(x => x.Seans == seans && x.Miejsce==j && x.Rzad==i).Count() != 0)
                        Console.Write("z");
                    else Console.Write("w");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Wyświetlony powinien być tytuł filmu, godzina rozpoczęcia, czas trwania
        /// i nazwa sali.
        /// </summary>
        /// <param name="seanse"></param>
        /// <param name="data"></param>
        private static void WyswietlFilmyOGodzinie(List<Seans> seanse, DateTime data)
        {
            //Wskazówka: Do obliczenia czy parametr data "wpada" w film można wykorzystać
            //metodę AddMinutes wykonanej na czasie rozpoczęcia seansu.
            foreach (var item in seanse)
            {
                if(data>=item.Date && data < item.Date.AddMinutes(item.Film.CzasTrwania))
                Console.WriteLine(item.Film.Tytul);
            }
            Console.ReadKey();
        }

        public static void Main(string[] args)
        {
            WyswietlPodgladSali(Dane.SkladDanych.Bilety, Dane.SkladDanych.Seanse[0]);
            /* Przykładowo:
            ----------
            ----------
            ----------
            ----------
            ----ooo---
            ----ooo---
            -----oo---
            ----------
            */
            Context db = new Context();
            Sala s1 =new Sala() { Nazwa = "Bałtyk", LiczbaMiejscWRzedzie = 10, LiczbaRzedow = 8 };
            Film f1 =new Film() { Tytul = "Konan Destylator", CzasTrwania = 90, Gatunek = "Fantasy" };
            Seans se1 =
             new Seans()
             {
                 Date = new DateTime(2019, 1, 20, 12, 00, 00),
                 Film = f1,
                 Sala = s1
             };

            Bilet bil1 = new Bilet(se1,20.00, 5, 5);
            Bilet bil2 = new Bilet(se1,22.00, 5, 6);
            se1.Bilety.Add(bil1);
            se1.Bilety.Add(bil2);
            s1.Seanse.Add(se1);
            f1.Seanse.Add(se1);
            db.Seanse.Add(se1);
            db.Sale.Add(s1);
            db.Filmy.Add(f1);


            db.SaveChanges();

        }
    }
}
