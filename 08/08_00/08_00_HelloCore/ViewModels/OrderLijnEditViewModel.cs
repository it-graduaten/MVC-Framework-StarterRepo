using HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.ViewModels
{
    public class OrderLijnEditViewModel
    {
        public int OrderLijnID { get; set; }
        public int ProductID { get; set; }
        public string ProductNaam { get; set; } = default!;
        public double Aantal { get; set; }
    }
}
