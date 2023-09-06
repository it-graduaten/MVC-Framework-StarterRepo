using _02_00.Models;
using Microsoft.AspNetCore.Mvc;

namespace _02_00.Controllers
{
    public class MVC2Controller : Controller
    {
        public List<Klant> klanten = new List<Klant>()
        {
            new Klant() { KlantID = 1, Voornaam = "Anneleen", Familienaam = "De Neve", AangemaaktDatum = new DateTime(2019, 1, 20) },
            new Klant() { KlantID = 2, Voornaam = "Nele", Familienaam = "Bruynseels", AangemaaktDatum = new DateTime(2020, 2, 4) },
            new Klant() { KlantID = 3, Voornaam = "Joris", Familienaam = "Naert", AangemaaktDatum = new DateTime(2020, 1, 5) },
            new Klant() { KlantID = 4, Voornaam = "Jan", Familienaam = "Vermeire", AangemaaktDatum = new DateTime(2021, 7, 13) },
            new Klant() { KlantID = 5, Voornaam = "Sasha", Familienaam = "Van Gompel", AangemaaktDatum = new DateTime(2022, 9, 25) }
        };

        public IActionResult Index()
        {
            List<Klant> alleKlanten = klanten;
            return View(alleKlanten);
        }
    }
}
