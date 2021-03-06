﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NUR.Models
{
    public class Strojna
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        public string Ime { get; set; }
        [MaxLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        public string Kategorija { get; set; }
        public Prostorija Prostorija { get; set; }
        public int ProstorijaId { get; set; }
        public Programska Programska { get; set; }
        public int ProgramskaId { get; set; }
        // staviti strani kljuc tu da moze 1 program biti na vise strojne opreme?
        // public Programska Programska { get; set; }

    }
}