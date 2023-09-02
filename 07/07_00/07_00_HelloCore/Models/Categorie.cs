using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Models
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string Naam { get; set; } = default!;
        public string Beschrijving { get; set; } = default!;
    }
}
