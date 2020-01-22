
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NUR.Models
{
    public class Strojna
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Kategorija { get; set; }
        public Prostorija Prostorija { get; set; }
    }
}