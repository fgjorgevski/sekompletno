using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DataAccess.Context;
using TREKS.SeKompletno.DataAccess.Repositories.Interfaces;
using TREKS.SeKompletno.DomainModels.Models;

namespace TREKS.SeKompletno.DataAccess.Repositories.Classes
{
    public class AdminRepository : IRepository<Admin>
    {
        private readonly SeKompletnoAppDbContext _context;

        public AdminRepository(SeKompletnoAppDbContext context)
        {
            _context = context;
        }

        public void Add(Admin entity)
        {
            _context.Admins.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Admin entity)
        {
            _context.Admins.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Admin> GetAll()
        {
            return _context.Admins;
        }

        public void Update(Admin entity)
        {
            _context.Admins.Update(entity);
            _context.SaveChanges();
        }
    }
}
