using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NUR.Models
{
    public class Prostorija
    {
        public int ID { get; set; }
        [MaxLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        public string Kategorija { get; set; }
        [Required]
        public int Broj { get; set; }
    }
}