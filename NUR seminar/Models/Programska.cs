using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NUR.Models
{
    public class Programska
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Kategorija { get; set; }
        public Strojna Strojna { get; set; }
    }
}