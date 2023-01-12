using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DomainModels.Enums;

namespace TREKS.SeKompletno.RequestModels
{
    public class ProductRequestModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string  NameOfProduct { get; set; }
        public SizeOfClothe Size { get; set; }
        public TypeOfColors Colors { get; set; }
        public TypeOfProduct TypeOfProduct { get; set; }
        public string Image { get; set; }
        public int ProductsLeft { get; set; }
        public string Description { get; set; }



    }
}
