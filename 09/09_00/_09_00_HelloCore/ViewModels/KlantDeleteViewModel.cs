using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace _09_00_HelloCore.ViewModels
{
    public class KlantDeleteViewModel
    {
        public int KlantID { get; set; }
        public string Voornaam { get; set; }
        public string Naam { get; set; }

    }
}
