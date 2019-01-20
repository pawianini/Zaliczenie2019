using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Lib
{
    public class Sala
    {
        public Sala()
        {
            Seanse = new List<Seans>();
        }
        public int SalaId { get; set; }
        public string Nazwa { get; set; }
        // zakładamy, że w każdym rzędzie jest tyle samo miejsc
        public int LiczbaRzedow { get; set; }
        public int LiczbaMiejscWRzedzie { get; set; }

        public virtual List<Seans> Seanse { get; set; }
    }
}
