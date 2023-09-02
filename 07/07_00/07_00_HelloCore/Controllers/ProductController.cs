using HelloCore.Data;
using HelloCore.Models;
using HelloCore.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Controllers
{
    public class ProductController : Controller
    {
        //Opdracht Productcontroller met UnitOfWork laten werken
        private readonly HelloCoreContext _context;

        public ProductController(HelloCoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ProductListViewModel viewModel = new ProductListViewModel();
            viewModel.Producten =  _context.Producten.ToList();
            return View(viewModel);
        }
        
        public  IActionResult Search(ProductListViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.ProductSearch))
            {
                viewModel.Producten =  _context.Producten.Where(p => p.Naam.Contains(viewModel.ProductSearch)).ToList();
            }
            else
            {
                viewModel.Producten =   _context.Producten.ToList();
            }
            return View("Index", viewModel);
        }

        public  IActionResult Details(int id)
        {
            Product? product = _context.Producten.FirstOrDefault(x=>x.ProductID==id);

            if (product != null)
            {
                ProductDetailsViewModel viewModel = new ProductDetailsViewModel()
                {
                    Naam = product.Naam,
                    Prijs = product.Prijs,
                    Beschrijving = product.Beschrijving,
                    Merk = product.Merk,
                };
                return View(viewModel);

            }
            else
            {
                ProductListViewModel viewModel = new ProductListViewModel();
                viewModel.Producten =  _context.Producten.ToList();
                return View(viewModel);
            }
        }
        public IActionResult Edit()
        {
            return View();
        }
        
    }
}
