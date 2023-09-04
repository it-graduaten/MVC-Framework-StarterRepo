using Microsoft.AspNetCore.Mvc.Rendering;

namespace _09_00_HelloCore.ViewModels
{
    public class OrderLijnCreateViewModel
    {
            public int ProductID { get; set; }
            public int Aantal { get; set; }

        public List<SelectListItem> Producten { get; set; } = new List<SelectListItem>();
    }
 
}
