using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DataAccess.Context;
using TREKS.SeKompletno.DataAccess.Repositories.Interfaces;
using TREKS.SeKompletno.DomainModels.Models;

namespace TREKS.SeKompletno.DataAccess.Repositories.Classes
{
    public class ManufacturerRepository : IRepository<Manufacturer>
    {
        private readonly SeKompletnoAppDbContext _context;

        public ManufacturerRepository(SeKompletnoAppDbContext context)
        {
            _context = context;
        }

        public void Add(Manufacturer entity)
        {
            _context.Manfluencers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Manufacturer entity)
        {
            _context.Manfluencers.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return _context.Manfluencers;
        }

        public void Update(Manufacturer entity)
        {
            _context.Manfluencers.Update(entity);
            _context.SaveChanges();
        }
    }
}
