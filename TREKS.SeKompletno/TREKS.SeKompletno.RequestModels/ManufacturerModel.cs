using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DomainModels.Enums;

namespace TREKS.SeKompletno.RequestModels
{
    public class ManufacturerModel
    {
        public int Id { get; set; }
        public string NameOfManafacturer { get; set; }
        public TypeOfManufacturer TypeOfManufacturer { get; set; }
        public int ProductId { get; set; }
        public List<ProductRequestModel> Products { get; set; }
        public double AgreedPercentageOfTotalEarnings { get; set; }
        public double  SeKompletnoEarnings { get; set; }

    }
}
