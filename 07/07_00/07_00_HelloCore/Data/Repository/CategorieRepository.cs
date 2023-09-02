using HelloCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using HelloCore.Models;

namespace HelloCore
{
    public class CategorieRepository : ICategorieRepository { 
        private readonly HelloCoreContext _context;
        public CategorieRepository(HelloCoreContext context)
        {
            _context = context;
        }
        public Categorie Add(Categorie categorie)
        {
            return _context.Categorieën.Add(categorie).Entity;
        }
        public Categorie? Find(int categorie)
        {
            return _context.Categorieën.Find(categorie);
        }

        public IEnumerable<Categorie> GetAll()
        {
            return _context.Categorieën.ToList();
        }
        public IQueryable<Categorie> Search()
        {
            return _context.Categorieën.AsQueryable();
        }
        
    }
}
