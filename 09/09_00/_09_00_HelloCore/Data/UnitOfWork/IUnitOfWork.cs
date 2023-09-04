using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _09_00_HelloCore.Models;

namespace _09_00_HelloCore
{
    public interface IUnitOfWork
    {
        IGenericRepository<Bestelling> BestellingRepository { get; }
        IGenericRepository<Klant> KlantRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<OrderLijn> OrderLijnRepository { get; }
        public void Save();
    }
}
