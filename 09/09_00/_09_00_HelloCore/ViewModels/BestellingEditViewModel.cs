using _09_00_HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _09_00_HelloCore.ViewModels
{
    public class BestellingEditViewModel
    {
        public int BestellingID { get; set; }
        public string KlantNaam { get; set; } = default!;
        public int KlantID { get; set; }
        public List<OrderLijnEditViewModel> Orderlijnen { get; set; } = default!;
    }
}
