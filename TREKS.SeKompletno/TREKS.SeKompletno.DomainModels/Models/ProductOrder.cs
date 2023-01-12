using System;
using System.Collections.Generic;
using System.Text;

namespace TREKS.SeKompletno.DomainModels.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int ProductId{ get; set; }
    }
}
