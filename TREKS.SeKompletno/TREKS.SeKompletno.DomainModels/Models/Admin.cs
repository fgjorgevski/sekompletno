using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TREKS.SeKompletno.DomainModels.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Username{ get; set; }
        public string Password{ get; set; }
        public long PhoneNumber { get; set; }
        public DateTime Logged { get; set; } = DateTime.UtcNow;
        public List<SeKompletnoEarnings> TotalEarnings { get; set; }

    }
}
