using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TREKS.SeKompletno.DomainModels.Models
{
    public class Users
    {
        public int Id { get; set; }
        public Admin Admin { get; set; }
        public Customer Customer{ get; set; }
    }
}
