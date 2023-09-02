using HelloCore.Data;
using HelloCore.Models;
using HelloCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HelloCore.Controllers
{

    public class KlantController : Controller
    {

        //DI van Generieke Repository van de entiteit Klant
        private readonly IGenericRepository<Klant> _context;

        public KlantController(IGenericRepository<Klant> context)
        {
            _context = context;
        }

        // Alle klanten ophalen uit de database en tonen in de view
        public async Task<IActionResult> Index()
        {
            KlantListViewModel viewModel = new KlantListViewModel();
            var klanten = await _context.GetAllAsync();
            viewModel.Klanten = klanten.ToList();
            return View(viewModel); 
        }
        // De methode SearchKlant toevoegen







        public async Task<IActionResult> Details(int id)
        {
            Klant? klant = await _context.GetByIdAsync(id);
            if (klant != null)
            {
                KlantDetailsViewModel viewModel = new KlantDetailsViewModel
                {
                    Voornaam = klant.Voornaam,
                    Naam = klant.Naam,
                    AangemaaktDatum = klant.AangemaaktDatum                    
                };
                return View(viewModel);
            }
            else
            {
                KlantListViewModel viewModel = new KlantListViewModel();
                var klanten = await _context.GetAllAsync();
                viewModel.Klanten = klanten.ToList();
                return View(viewModel);
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(KlantCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(new Klant()
                {
                    Voornaam=viewModel.Voornaam,
                    Naam=viewModel.Naam,
                    AangemaaktDatum=viewModel.AangemaaktDatum
                });
                _context.Save();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var klant = await _context.GetByIdAsync(id);
            if (klant == null)
            {
                return NotFound();
            }

            KlantEditViewModel viewModel = new KlantEditViewModel()
            {
                KlantID = klant.KlantID,
                Voornaam = klant.Voornaam,
                Naam = klant.Naam,
                AangemaaktDatum = klant.AangemaaktDatum
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, KlantEditViewModel viewModel)
        {
            if (id != viewModel.KlantID)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    Klant klant = new Klant()
                    {
                        KlantID = viewModel.KlantID,
                        Voornaam = viewModel.Voornaam,
                        Naam = viewModel.Naam,
                        AangemaaktDatum = viewModel.AangemaaktDatum
                    };
                     _context.Update(klant);
                     _context.Save();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_context.GetByIdAsync(id) != null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var klant = await _context.GetByIdAsync(id);
            if (klant == null)
            {
                return NotFound();
            }

            KlantDeleteViewModel viewModel = new KlantDeleteViewModel()
            {
                KlantID=klant.KlantID,
                Voornaam=klant.Voornaam,
                Naam=klant.Naam
            };
            return View(viewModel); 
        }

        [HttpPost, ActionName("Delete") ]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klant = await _context.GetByIdAsync(id);
            if (klant != null)
            {
                _context.Delete(klant);
                _context.Save();
            }

            return RedirectToAction("Index");
        }
    }
}
