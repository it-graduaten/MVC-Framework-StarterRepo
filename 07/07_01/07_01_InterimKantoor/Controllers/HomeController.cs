using InterimKantoor.Data;
using InterimKantoor.Models;
using InterimKantoor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace InterimKantoor.Controllers
{

    public class HomeController : Controller
    {
        private readonly InterimKantoorContext _context;

        public HomeController(InterimKantoorContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
                var jobs =  _context.Jobs.ToList();

            var viewModelList = new List<JobDetailsViewModel>();

                foreach (var job in jobs)
                {
                    int aantalBezettePlaatsen = _context.KlantJobs.Count(kj => kj.JobId == job.Id);
                    var viewModel = new JobDetailsViewModel
                    {
                        Id= job.Id,
                        Omschrijving=job.Omschrijving,
                        StartDatum=job.StartDatum,
                        EindDatum=job.EindDatum,
                        IsBadge=job.IsBadge,
                        IsKleding=job.IsKleding,
                        IsWerkschoenen=job.IsWerkschoenen,
                        Locatie=job.Locatie,
                        AantalPlaatsen=job.AantalPlaatsen,
                        VrijePlaatsen = job.AantalPlaatsen-aantalBezettePlaatsen
                    };

                    viewModelList.Add(viewModel);
                }

                return View(viewModelList);
            }
        }


}
