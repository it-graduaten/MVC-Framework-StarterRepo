using System;

namespace HelloCore.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }
        public string Naam { get; set; } = default!;
        public Decimal? Prijs { get; set; }
        public string Merk { get; set; } = default!;
        public string Beschrijving { get; set; } = default!;
    }
}
