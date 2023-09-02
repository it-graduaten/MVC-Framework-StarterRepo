using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace HelloCore.ViewModels
{
    public class KlantEditViewModel
    {
        public int KlantID { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [DataType(DataType.Date), Display(Name = "Datum Aangemaakt")]

        public DateTime AangemaaktDatum { get; set; }
    }
}
