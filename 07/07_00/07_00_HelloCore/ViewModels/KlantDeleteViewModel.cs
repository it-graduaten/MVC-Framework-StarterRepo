﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace HelloCore.ViewModels
{
    public class KlantDeleteViewModel
    {
        public int KlantID { get; set; }
        public string Voornaam { get; set; } = default!;
        public string Naam { get; set; } = default!;

    }
}
