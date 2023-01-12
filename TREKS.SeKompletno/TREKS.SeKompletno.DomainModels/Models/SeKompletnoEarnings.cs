using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TREKS.SeKompletno.DomainModels.Models
{
    public class SeKompletnoEarnings
    {
        public int Id { get; set; }
        public Manufacturer Manfluencer { get; set; }
        public int ManfluencerId{ get; set; }
        public double TotalEarnings{ get; set; }

    }
}
