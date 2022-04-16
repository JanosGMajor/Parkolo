using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parkolo.Models
{
    public class Keszlet
    {
        public int Id { get; set; }

        [Display(Name = "Alvázszám")]
        [StringLength(17)]
        public string AlvazSzam { get; set; }

        [Display(Name = "Típus")]
        [StringLength(50)]
        public string Tipus { get; set; }

        [Display(Name = "Kulcs Szám")]
        [StringLength(20)]
        public string KulcsSzam { get; set; }

        [Display(Name = "Pozíció")]
        public int Pozicio { get; set; }
    }
}
