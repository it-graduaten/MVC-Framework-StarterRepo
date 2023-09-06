using System.ComponentModel.DataAnnotations;

namespace _02_00.Models
{
    public class Klant
    {
        public int KlantID { get; set; }

        public string Voornaam { get; set; }

        public string Familienaam { get; set; }

        [DataType(DataType.Date)]
        public DateTime AangemaaktDatum { get; set; }
    }
}
