﻿using System.Collections.Generic;
using HelloCore.Models;

namespace HelloCore.ViewModels
{
    public class KlantListViewModel
    {
        public string KlantSearch { get; set; } = default!;
        public List<Klant> Klanten { get; set; } = default!;
    }
}
