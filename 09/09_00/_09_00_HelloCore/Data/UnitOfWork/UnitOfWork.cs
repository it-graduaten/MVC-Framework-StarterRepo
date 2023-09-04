using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _09_00_HelloCore.Models;
using _09_00_HelloCore.Data;

namespace _09_00_HelloCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HelloCoreContext _context;

        public UnitOfWork(HelloCoreContext context)
        {
            _context = context;
            KlantRepository = new GenericRepository<Klant>(_context);
            BestellingRepository = new GenericRepository<Bestelling>(_context);
            ProductRepository = new GenericRepository<Product>(_context);
            OrderLijnRepository = new GenericRepository<OrderLijn>(_context);
        }

        public IGenericRepository<Klant> KlantRepository { get; }
        public IGenericRepository<Bestelling> BestellingRepository { get; }
        public IGenericRepository<Product> ProductRepository { get; }
        public IGenericRepository<OrderLijn> OrderLijnRepository { get; }


        /* Andere manier: Lazy Loading = repository-objecten worden pas aangemaakt op het moment dat ze voor de eerste keer worden aangeroepen. 
         * Dit is nuttiger voor grotere projecten die veel resources vergen, maar de code wordt wel complexer
         
        private readonly HelloCoreContext _context;
        private IGenericRepository<Bestelling> bestellingRepository;
        private IGenericRepository<Klant> klantRepository;

        public UnitOfWork(HelloCoreContext context)
        {
            _context = context;
        }

        public IGenericRepository<Bestelling> BestellingRepository
        {
            get
            {
                if (this.bestellingRepository == null)
                    this.bestellingRepository = new GenericRepository<Bestelling>(_context);

                return bestellingRepository;
            }
        }

                public IGenericRepository<Klant> KlantRepository
        {
            get
            {
                if (this.klantRepository == null)
                    this.klantRepository = new GenericRepository<Klant>(_context);

                return klantRepository;
            }
        }

        */


        public void Save()
        {
            _context.SaveChanges();
        }
}
}
