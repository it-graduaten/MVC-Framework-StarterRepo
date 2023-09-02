using System;

namespace HelloCore.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }
        public string Naam { get; set; }
        public Decimal? Prijs { get; set; }
        public string Merk { get; set; }
        public string Beschrijving { get; set; }
    }
}
