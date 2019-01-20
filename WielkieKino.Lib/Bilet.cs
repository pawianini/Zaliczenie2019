using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Lib
{
    public class Bilet
    {   [Key]
        public int BiletId { get; set; }
        public virtual Seans Seans { get; set; }

        public int SeansId { get; set; }
        public double Cena { get; set; }
        public int Rzad { get; set; }
        public int Miejsce { get; set; }

        public Bilet() { }
        public Bilet(Seans seans, double cena, int rzad, int miejsce)
        {
            Seans = seans;
            Cena = cena;
            Rzad = rzad;
            Miejsce = miejsce;
        }
    }
}
