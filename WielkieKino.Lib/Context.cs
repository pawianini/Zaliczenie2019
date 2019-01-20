using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Lib
{
   public class Context:DbContext
    {
       public DbSet<Bilet> Bilety { get; set; }
       public DbSet<Seans> Seanse { get; set; }
        public DbSet<Film> Filmy { get; set; }
        public DbSet<Sala> Sale { get; set; }
    }
}
