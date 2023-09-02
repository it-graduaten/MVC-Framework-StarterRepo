using HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCore
{
    public interface ICategorieRepository
    {

        Categorie Add(Categorie categorie);
        Categorie? Find(int categorie);
        IEnumerable<Categorie> GetAll();
        IQueryable<Categorie> Search();
     }
}