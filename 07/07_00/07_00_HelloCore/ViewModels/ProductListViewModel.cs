using HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.ViewModels
{
    public class ProductListViewModel
    {
        public string ProductSearch { get; set; } = default!;

        public List<Product> Producten { get; set; } = default!;
    }
}
