using _09_00_HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _09_00_HelloCore.ViewModels
{
    public class OrderLijnEditViewModel
    {
        public int OrderLijnID { get; set; }
        public int ProductID { get; set; }
        public string ProductNaam { get; set; } = default!;
        public double Aantal { get; set; }
    }
}
