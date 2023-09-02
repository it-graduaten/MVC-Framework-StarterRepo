using HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.ViewModels
{
    public class BestellingDetailsViewModel
    {
        public int BestellingID { get; set; }
        public List<Bestelling> Bestellingen { get; set; } = default!;
    }
}
