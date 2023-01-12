using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DomainModels.Enums;

namespace TREKS.SeKompletno.RequestModels
{
    public class OrderRequestModel
    {
        public int Id { get; set; }

        public  int CustomerId { get; set; }
        public double Price { get; set; }
        public SizeOfClothe Size { get; set; }
        public DateTime DeliveryTime { get; set; } = DateTime.UtcNow.AddMinutes(30);
        public DateTime OrderTime { get; set; } = DateTime.UtcNow;




        public ProductRequestModel ProductRequestModel{ get; set; }
    }
}
