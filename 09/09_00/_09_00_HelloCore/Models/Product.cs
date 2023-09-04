using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _09_00_HelloCore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Naam { get; set; } = default!;
        public Decimal? Prijs { get; set; }
        public string Merk { get; set; } = default!;
        public string Beschrijving { get; set; } = default!;
        [JsonIgnore]
        public IList<OrderLijn> orderlijnen { get; set; } = new List<OrderLijn>()!;
    }
}
