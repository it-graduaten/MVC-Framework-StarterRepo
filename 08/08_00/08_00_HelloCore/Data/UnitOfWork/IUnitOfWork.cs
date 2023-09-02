using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloCore.Models;

namespace HelloCore
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
