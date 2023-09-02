using HelloCore.Data;
using HelloCore.Models;
using HelloCore.ViewModels;
using Microsoft.AspNetCore.Mvc;



namespace HelloCore.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ICategorieRepository _context;
        public CategorieController(ICategorieRepository context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
           CategorieListViewModel viewModel = new CategorieListViewModel();

            var categorieën = _context.GetAll();
            if (categorieën != null)
            {
                viewModel.Categorieën = categorieën.ToList();
            }
            else
            {
                viewModel.Categorieën = new List<Categorie>();
            }
            return View(viewModel);
        }
        
    }
}
