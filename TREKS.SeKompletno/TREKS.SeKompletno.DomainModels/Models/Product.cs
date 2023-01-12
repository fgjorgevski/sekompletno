using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TREKS.SeKompletno.DomainModels.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string NameOfProduct { get; set; }
        public double Price { get; set; }
        public string Image{ get; set; }
        public int ProductsLeft { get; set; }
        public bool InStock { get; set; }
        public int Size { get; set; }
        public  int Color{ get; set; }
        public int TypeOfProduct { get; set; }
        public string Description { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }



      
    }


}
