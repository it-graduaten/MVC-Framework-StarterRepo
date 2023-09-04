using _09_00_HelloCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using _09_00_HelloCore;
using _09_00_HelloCore.Data;
using System;
using System.Linq;
using System.Diagnostics;
using _09_00_HelloCore.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _09_00_HelloCore.Controllers
{
    
    public class BestellingController : Controller
    {
        private readonly IUnitOfWork _uow;
        public BestellingController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ActionResult Index()
        {
            BestellingListViewModel viewModel = new BestellingListViewModel();
            var bestelling = _uow.BestellingRepository.Find(x => x.klant, x => x.orderlijnen);

            viewModel.Bestellingen = bestelling.ToList();
            return View(viewModel);
        }
        public ActionResult<Bestelling> GetBestelling(int id)
        {
            var bestelling = _uow.BestellingRepository.Search().Where(x => x.BestellingID == id).Include(x => x.klant).Include(x => x.orderlijnen).ThenInclude(x => x.product);
            if (bestelling == null) return NotFound();

            BestellingDetailsViewModel viewModel = new BestellingDetailsViewModel
            {
                BestellingID = id,
                Bestellingen = bestelling.ToList()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> AddBestelling()
        {
            var viewModel = new BestellingCreateViewModel();

            // Load customers into the dropdown
           var klanten = await _uow.KlantRepository.GetAllAsync();
            viewModel.Klanten = klanten.Select(k => new SelectListItem
            {
                Value = k.KlantID.ToString(),
                Text = k.Naam
            }).ToList();

            // Load products into the dropdowns for order lines
            var producten = await _uow.ProductRepository.GetAllAsync();
            viewModel.Producten = producten.Select(p => new SelectListItem
            {
                Value = p.ProductID.ToString(),
                Text = p.Naam
            })
            .ToList();
            foreach (var orderLijn in viewModel.OrderLijnen)
            {
                orderLijn.Producten = producten.Select(p => new SelectListItem
                    {
                        Value = p.ProductID.ToString(),
                        Text = p.Naam
                    })
                    .ToList();
            }
            return View(viewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddBestelling(BestellingCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var bestelling = new Bestelling
                {
                    KlantID = viewModel.KlantID,
                };

                foreach (var orderLijnViewModel in viewModel.OrderLijnen)
                {
                    var orderlijn = new OrderLijn
                    {
                        ProductID = orderLijnViewModel.ProductID,
                        Aantal = orderLijnViewModel.Aantal
                    };
                    bestelling.orderlijnen.Add(orderlijn);
                }
                await _uow.BestellingRepository.AddAsync(bestelling);
                _uow.Save();

                return RedirectToAction("Index");
            }

            var producten = await _uow.ProductRepository.GetAllAsync();
            foreach (var orderlijn in viewModel.OrderLijnen)
            {
                orderlijn.Producten = producten.Select(p => new SelectListItem
                    {
                        Value = p.ProductID.ToString(),
                        Text = p.Naam
                    })
                    .ToList();
            }

            var klanten = await _uow.KlantRepository.GetAllAsync();
            viewModel.Klanten = klanten.Select(c => new SelectListItem
                {
                    Value = c.KlantID.ToString(),
                    Text = c.Naam
                })
                .ToList();

            return View(viewModel);
        }
        
        [HttpGet]
        public ActionResult EditBestelling(int id)
        {     
            var bestelling = _uow.BestellingRepository.Search().Include(x => x.klant).Include(x => x.orderlijnen).ThenInclude(x => x.product).FirstOrDefault(x => x.BestellingID == id);
            if (bestelling == null) return NotFound();

            BestellingEditViewModel viewModel = new BestellingEditViewModel
            {
                BestellingID = id,
                KlantNaam = bestelling.klant.Naam,
                KlantID = bestelling.KlantID,
                Orderlijnen = bestelling.orderlijnen.Select(ol => new OrderLijnEditViewModel
                {
                    OrderLijnID = ol.OrderLijnID,
                    ProductID = ol.ProductID,
                    ProductNaam = ol.product.Naam,
                    Aantal = ol.Aantal
                }).ToList()
            };

            return View(viewModel);
        }

           // Bestelling updaten
        [HttpPost]
        public IActionResult EditBestelling(BestellingEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var bestelling = _uow.BestellingRepository.Search().Include(b => b.orderlijnen)
                    .FirstOrDefault(b => b.BestellingID == viewModel.BestellingID);

                if (bestelling == null)
                {
                    return NotFound();
                }

                foreach (var viewModelOrderLijn in viewModel.Orderlijnen)
                {
                    var orderLijn = bestelling.orderlijnen
                        .FirstOrDefault(ol => ol.OrderLijnID == viewModelOrderLijn.OrderLijnID);

                    if (orderLijn != null)
                    {
                        orderLijn.Aantal = viewModelOrderLijn.Aantal;
                    }
                }

                _uow.Save();

                return RedirectToAction("index");
            }
            //return RedirectToAction("index");
            return View(viewModel);      
    }



        [HttpGet]
        public async Task<ActionResult<Bestelling>> DeleteBestelling(int id)
        {
            Bestelling? bestelling = await _uow.BestellingRepository.GetByIdAsync(id);
            if (bestelling == null) return NotFound();

            _uow.BestellingRepository.Delete(bestelling);
            _uow.Save();

            return RedirectToAction("Index");
        }
        

    }
}
