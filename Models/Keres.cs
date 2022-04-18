using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkolo.Models
{
    public class Keres
    {
        public string AlvazSzamKeres { get; set; }

        public string TipusKeres { get; set; }

        public List<Keszlet> KeszletLista { get; set; }

        public SelectList TipusSelect { get; set; }
    }
}
