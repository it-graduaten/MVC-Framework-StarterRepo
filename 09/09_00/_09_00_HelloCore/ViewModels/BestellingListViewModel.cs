using _09_00_HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _09_00_HelloCore.ViewModels
{
    public class BestellingListViewModel
    {

        public List<Bestelling> Bestellingen { get; set; } = default!;
    }
}
