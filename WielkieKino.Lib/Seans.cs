using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Lib
{
    public class Seans

    { public Seans() { Bilety = new List<Bilet>(); }
        [Key]
        public int SeansId { get; set; }
        public int SalaId { get; set; }
        public int FilmId { get; set; }
        public DateTime Date { get; set; }
        public Sala Sala { get; set; }
        public Film Film { get; set; }

        public virtual List<Bilet> Bilety { get; set; }



    }
}
