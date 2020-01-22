using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NUR.Models
{
    public class Programska
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        public string Ime { get; set; }
        [MaxLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        public string Kategorija { get; set; }
       // public Strojna Strojna { get; set; } // mislim da bi trebalo maknit ovo
    }
}

//[11:17, 22/01/2020] Anton Šustić: Kako ti je 1 naprama vise kad si stavija samo 1 strojna.Ako zelis vise mora ti bit List<Strojna>
//[11:17, 22 / 01 / 2020] Anton Šustić: I mozes stavit virtual isto
//   [11:17, 22 / 01 / 2020] Anton Šustić: public virtual List<Strojna> Strojna
//       [11:18, 22 / 01 / 2020] Anton Šustić: Ako zelis 1:N jelte
//           [11:18, 22 / 01 / 2020] Anton Šustić: Ovo sad ti je 1:1