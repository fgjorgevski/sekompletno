using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DomainModels.Models;
using TREKS.SeKompletno.RequestModels;

namespace TREKS.SeKompletno.Services.Interfaces
{
    public interface IManufacturerService
    {
        void AddManufacturer(ManufacturerModel manufacturerModel);
        void DeleteManufacturerById(int id );
        double TotatlEarningsOfManufacturer(ManufacturerModel manufacturerModel);

    }
}
