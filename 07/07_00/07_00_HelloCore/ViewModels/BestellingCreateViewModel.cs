using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelloCore.ViewModels
{
    public class BestellingCreateViewModel
    {
        public int KlantID { get; set; }

        public List<SelectListItem> Klanten { get; set; } = new  List<SelectListItem>();
        public List<OrderLijnCreateViewModel> OrderLijnen { get; set; } = new List<OrderLijnCreateViewModel>();
        public List<SelectListItem> Producten { get; set; } = new List<SelectListItem>();



    }
}
