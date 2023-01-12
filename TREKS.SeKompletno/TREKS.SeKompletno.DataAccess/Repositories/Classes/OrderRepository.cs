using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DataAccess.Context;
using TREKS.SeKompletno.DataAccess.Repositories.Interfaces;
using TREKS.SeKompletno.DomainModels.Models;

namespace TREKS.SeKompletno.DataAccess.Repositories.Classes
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly SeKompletnoAppDbContext _context;

        public OrderRepository(SeKompletnoAppDbContext context)
        {
            _context = context;
        }

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();

        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
        }

    }
}
