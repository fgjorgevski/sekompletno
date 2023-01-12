using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TREKS.SeKompletno.DomainModels.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string NameOfManfluencer { get; set; }
        public int TypeOfManfluencer { get; set; }
        public double AgreedPercentage { get; set; } 
        public List<Product> Products { get; set; }
        public int ProductId { get; set; }
        public SeKompletnoEarnings TotalEarnings { get; set; }

       
    }
}
