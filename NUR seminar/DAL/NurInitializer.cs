using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NUR.Models;

namespace NUR.DAL
{
    public class NurInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<NurContext>
    {
        protected override void Seed(NurContext context)
        {
            var programskaOprema = new List<Programska>
            {
            new Programska{Ime="Windows",Kategorija="10"},
            new Programska{Ime="Linux",Kategorija="NekiTamo"},

            };

            programskaOprema.ForEach(s => context.Programskas.Add(s));
            context.SaveChanges();
            var strojnaOprema = new List<Strojna>
            {
            new Strojna{Ime="Monitor",Kategorija="DELL"},
            new Strojna{Ime="Laptop",Kategorija="DELL"},

            };
            strojnaOprema.ForEach(s => context.Strojnas.Add(s));
            context.SaveChanges();
            var prostorije = new List<Prostorija>
            {
            new Prostorija{Kategorija="Skladiste",Broj=1050},
            new Prostorija{Kategorija="Skladiste",Broj=4022},

            };
            prostorije.ForEach(s => context.Prostorijas.Add(s));
            context.SaveChanges();
        }
    }
}