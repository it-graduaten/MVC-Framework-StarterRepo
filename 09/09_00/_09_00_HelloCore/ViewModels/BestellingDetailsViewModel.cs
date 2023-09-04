using _09_00_HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _09_00_HelloCore.ViewModels
{
    public class BestellingDetailsViewModel
    {
        public int BestellingID { get; set; }
        public List<Bestelling> Bestellingen { get; set; } = default!;
    }
}
