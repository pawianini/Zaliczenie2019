using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Logic
{
    /// <summary>
    /// Metody do napisania z wykorzystaniem LINQ (w składni zapytania, wyrażeń
    /// lambda lub mieszanej)
    /// </summary>
    public class DataProcessing
    {
        public List<string> WybierzFilmyZGatunku(List<Film> filmy, string gatunek)
        {
            // Właściwa odpowiedź: np. "Konan Destylator" dla "Fantasy"
            return (from f in filmy where f.Gatunek == gatunek select f.Tytul).ToList();
                  
        }

        /// <summary>
        /// Sumujemy wpływy bez względu na datę seansu
        /// </summary>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public int PodajCalkowiteWplywyZBiletow(List<Bilet> bilety)
        {
            // Właściwa odpowiedź: 400
            return (from b in bilety select b.Cena).Sum(x=>Convert.ToInt32(x));
        }

        public List<Film> WybierzFilmyPokazywaneDanegoDnia(List<Seans> seanse, DateTime data)
        {
            return (from s in seanse where s.Date.Date==data.Date select s.Film).Distinct().ToList();
        }

        /// <summary>
        /// Zwraca gatunek, z którego jest najwięcej filmów. Jeśli jest kilka takich
        /// gatunków, to zwraca dowolny z nich.
        /// </summary>
        /// <param name="filmy"></param>
        /// <returns></returns>
        public string NajpopularniejszyGatunek(List<Film> filmy)
        {
            // Właściwa odpowiedź: Obyczajowy
            var x = (from f in filmy group f by f.Gatunek into gropuing select new { gatunek = gropuing.Key, ilosc = gropuing.Count() }).ToList();
            int max = x.Max(a => a.ilosc);
            return x.Where(g => g.ilosc == max).Select(a => a.gatunek).ToList().FirstOrDefault();
        }

        public List<Sala> ZwrocSalePosortowanePoCalkowitejLiczbieMiejsc(List<Sala> sale)
        {
            // Właściwa odpowiedź: Kameralna, Bałtyk, Wisła (lub w odwrotnej kolejności)
            return sale.OrderBy(x=>x.LiczbaRzedow*x.LiczbaMiejscWRzedzie).ToList();
        }

        public Sala ZwrocSaleGdzieJestNajwiecejSeansow(List<Seans> seanse, DateTime data)
        {
            // Właściwa odpowiedź dla daty 2019-01-20: sala "Wisła" 

           var x = (from s in seanse where s.Date.Date == data.Date group s by s.Sala into grouping select new { sala = grouping.Key, ilosc = grouping.Count() }).ToList() ;
            int max = x.Max(a => a.ilosc);
            return x.Where(a=>a.ilosc==max).Select(a => a.sala).ToList().FirstOrDefault();
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry przekazane do metody muszą być użyte przy
        /// implementacji. Jeśli jest kilka takich filmów, zwracamy dowolny.
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public Film ZwrocFilmNaKtorySprzedanoNajwiecejBiletow(List<Film> filmy, List<Bilet> bilety)
        {
            // Właściwa odpowiedź: "Konan Destylator"
            var x = (from b in bilety  group b by b.Seans.Film into grouping
            select new { Film = grouping.Key, ilosc = grouping.Count() }).ToList();
            int max = x.Max(a => a.ilosc);
            return x.Where(a => a.ilosc == max).Select(a => a.Film).ToList().FirstOrDefault();
         
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry metody muszą być wykorzystane przy
        /// implementacji. Filmy z takim samym przychodem zwracamy w dowolnej kolejności
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public List<Film> PosortujFilmyPoDochodach(List<Film> filmy, List<Bilet> bilety)
        {
            return (from b in bilety
                    group b by b.Seans.Film into grouping
                    select new { Film = grouping.Key, ilosc = grouping.Count() }).OrderBy(x=>x.ilosc).Select(x=>x.Film).ToList();
        }


    }
}
