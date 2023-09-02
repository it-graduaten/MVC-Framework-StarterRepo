using HelloCore.Data;
using Microsoft.AspNetCore.Mvc;
using HelloCore.Models;

namespace HelloCore.Controllers
{
    public class VerkoopController : Controller
    {
        private readonly HelloCoreContext _context;
        public VerkoopController(HelloCoreContext context)
        {
            _context = context;
        }

        public void Afdrukken()
        {
            //Opvullen van lijsten
            List<Product> producten = _context.Producten.ToList();
            List<Klant> klanten = _context.Klanten.ToList();

            //Afdrukken van lijsten
            AfdrukkenLijst(producten);
            AfdrukkenLijst(klanten);
        }

        private static void AfdrukkenLijst<T>(List<T> lijst)
        {
            //Headers
            foreach (var props in typeof(T).GetProperties())
            {
                Console.Write(props.Name + ";");
            }
            Console.WriteLine();
            //Values
            foreach (var item in lijst)
            {
                foreach (var props in typeof(T).GetProperties())
                {
                    Console.Write(props.GetValue(item) + ";");
                }
                Console.WriteLine();
            }
        }
        /* Niet generieke manieren
        private static void AfdrukkenLijst(List<Product> lijst)
        {
            //Headers
            foreach(var props in typeof(Product).GetProperties())
            {
                Console.Write(props.Name + ";");
            }
            Console.WriteLine();
            //Values
            foreach(var item in lijst)
            {
                foreach (var props in typeof(Product).GetProperties())
                {
                    Console.Write(props.GetValue(item) + ";");
                }
                Console.WriteLine();
            }
        }

        private static void AfdrukkenLijst(List<Klant> lijst)
        {
            //Headers
            foreach (var props in typeof(Klant).GetProperties())
            {
                Console.Write(props.Name + ";");
            }
            Console.WriteLine();
            //Values
            foreach (var item in lijst)
            {
                foreach (var props in typeof(Klant).GetProperties())
                {
                    Console.Write(props.GetValue(item) + ";");
                }
                Console.WriteLine();
            }
        }*/

    }
}
