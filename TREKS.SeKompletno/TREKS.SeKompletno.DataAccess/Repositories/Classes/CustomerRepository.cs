using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DataAccess.Context;
using TREKS.SeKompletno.DataAccess.Repositories.Interfaces;
using TREKS.SeKompletno.DomainModels.Models;

namespace TREKS.SeKompletno.DataAccess.Repositories.Classes
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly SeKompletnoAppDbContext _context;

        public CustomerRepository(SeKompletnoAppDbContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers;
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
            _context.SaveChanges();
        }
    }
}
