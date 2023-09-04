using _09_00_HelloCore.Data;
using _09_00_HelloCore.Models;
using _09_00_HelloCore.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace _09_00_HelloCore.Controllers
{
    public class ProductController : Controller
    {
        //DI van Generieke Repository van de entiteit Klant
        private readonly IUnitOfWork _uow;

        public ProductController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IActionResult> Index()
        {
            ProductListViewModel viewModel = new ProductListViewModel();
            var producten = await _uow.ProductRepository.GetAllAsync();
            viewModel.Producten = producten.ToList();
            return View(viewModel);
        }
        
        public async Task<IActionResult> Search(ProductListViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.ProductSearch))
            {
                viewModel.Producten = _uow.ProductRepository.Find(p => p.Naam.Contains(viewModel.ProductSearch)).ToList();
            }
            else
            {
                var producten = await _uow.ProductRepository.GetAllAsync();
                viewModel.Producten = producten.ToList();
            }
            return View("Index", viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            Product? product = await _uow.ProductRepository.GetByIdAsync(id);

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
                var producten = await _uow.ProductRepository.GetAllAsync();
                viewModel.Producten = producten.ToList();
                return View(viewModel);
            }
        }
        public IActionResult Edit()
        {
            return View();
        }
        
    }
}
