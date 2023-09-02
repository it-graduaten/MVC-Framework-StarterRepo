
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HelloCore.Models
{
    public class Klant
    {
        public int KlantID { get; set; }
        [Required]
        public string Naam { get; set; } = default!;
        [Required]
        public string Voornaam { get; set; } = default!;
        [DataType(DataType.Date),Display(Name ="Datum Aangemaakt")]

        public DateTime AangemaaktDatum { get; set; }
        [JsonIgnore]
        public IList<Bestelling> bestelling { get; set; } = default!;
    }
}
