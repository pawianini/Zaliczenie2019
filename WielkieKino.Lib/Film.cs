﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Lib
{
    public class Film
    {
        public Film()
        {
            Seanse = new List<Seans>();
        }
        public int FilmId { get; set; }
        public string Tytul { get; set; }
        public int CzasTrwania { get; set; }
        public string Gatunek { get; set; }

        public virtual List<Seans> Seanse { get; set; }
    }
}
