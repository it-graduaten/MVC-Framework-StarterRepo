 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Models
{
    public class Bestelling
    {
        public int BestellingID { get; set; }

        public int KlantID { get; set; }

        public Klant klant { get; set; } = new Klant()!;

        public List<OrderLijn> orderlijnen { get; set; } = new List<OrderLijn>();
    }
}
