using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DataAccess.Context;
using TREKS.SeKompletno.DataAccess.Repositories.Interfaces;
using TREKS.SeKompletno.DomainModels.Models;

namespace TREKS.SeKompletno.DataAccess.Repositories.Classes
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly SeKompletnoAppDbContext _context;

        public ProductRepository(SeKompletnoAppDbContext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }
    }
}
