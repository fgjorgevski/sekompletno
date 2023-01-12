using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;

namespace TREKS.SeKompletno.DomainModels.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public int Size { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
