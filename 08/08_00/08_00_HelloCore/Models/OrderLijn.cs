using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Models
{
    public class OrderLijn
    {
        public int OrderLijnID { get; set; }

        [Required]
        public double Aantal { get; set; }
        public int BestellingID { get; set; }

        public Bestelling bestelling { get; set; } = default!;

        public int ProductID { get; set; }

        public Product product { get; set; } = default!;
    }
}
