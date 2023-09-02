using InterimKantoor.Data;
using InterimKantoor.Models;
using InterimKantoor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace InterimKantoor.Controllers
{
    public class JobController : Controller
    {
        private readonly InterimKantoorContext _context;
        public JobController(InterimKantoorContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            JobIndexViewModel viewModel = new JobIndexViewModel();
            viewModel.Vacatures = await _context.Jobs.Include(x => x.KlantJobs).ThenInclude(x => x.Klant).ToListAsync();                 
            return View(viewModel);
        }

        /*
        public IActionResult Edit(int? id)
        {



        }
        */



        public IActionResult Detail(int? id)
        {
            Job Job = _context.Jobs.Where(k => k.Id == id).Include(k => k.KlantJobs)
                                                .ThenInclude(k => k.Klant)
                                                .First();
            if (Job != null)
            {
                JobDetailViewModel viewModel = new JobDetailViewModel();
                {
                    viewModel.Job = Job;
                };
                return View(viewModel);
            }
            else
            {
                JobIndexViewModel viewModel = new JobIndexViewModel();
                {
                    viewModel.Vacatures = _context.Jobs.Include(x => x.KlantJobs).ThenInclude(x => x.Klant).ToList();
                };
                return View(viewModel);
            }
        }
 
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(JobCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Job()
                {
                    Omschrijving = viewModel.Omschrijving,
                    StartDatum = viewModel.StartDatum,
                    EindDatum = viewModel.EindDatum,
                    Locatie = viewModel.Locatie,
                    IsBadge = viewModel.IsBadge,
                    IsKleding = viewModel.IsKleding,
                    IsWerkschoenen = viewModel.IsWerkschoenen,
                    AantalPlaatsen = viewModel.AantalPlaatsen
                });
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);

        }


        [HttpGet]
        public IActionResult Assign(int id)
        {
            var klanten = _context.Klanten.ToList();
            Job job = _context.Jobs.Where(x => x.Id == id).Include(k => k.KlantJobs).ThenInclude(k => k.Klant).First();

            JobAssignViewModel viewModel = new()
            {
                JobId = job.Id,
                JobOmschrijving = job.Omschrijving,
                Klanten = klanten.Select(k => new SelectListItem
                    {
                        Value = k.KlantId.ToString(),
                        Text = k.Naam
                    }).ToList()
        };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Assign(JobAssignViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _context.KlantJobs.Where(x=> x.JobId == viewModel.JobId && x.KlantId==viewModel.KlantId).ToList();

                if (result.Count == 0)
                {
                    _context.Add(new KlantJob
                    {
                        KlantId = viewModel.KlantId,
                        JobId = viewModel.JobId
                    });

                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ErrorShowViewModel Error = new()
                    {
                        Error = viewModel.KlantId + " is reeds toegewezen aan deze vacature!"
                    };
                    return View("Error",Error);
                }
            }
            return View(viewModel);
         
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Job = await _context.Jobs.FirstOrDefaultAsync(a => a.Id == id);
            if (Job == null)
            {
                return NotFound();
            }

            JobDeleteViewModel viewModel = new JobDeleteViewModel()
            {
                JobId = Job.Id,
                Omschrijving = Job.Omschrijving
            };
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Job? job = await _context.Jobs.FirstOrDefaultAsync(a => a.Id == id);
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        

    }
}
