using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREKS.SeKompletno.DataAccess.Repositories.Interfaces;
using TREKS.SeKompletno.DomainModels.Models;
using TREKS.SeKompletno.RequestModels;
using TREKS.SeKompletno.Services.Interfaces;

namespace TREKS.SeKompletno.Services.Classes
{
    public class ManufacturerService : IManufacturerService
    {
        public readonly IRepository<Manufacturer> _manfacturerRepository;

        public ManufacturerService(IRepository<Manufacturer> repository)
        {
            _manfacturerRepository = repository;
        }

        public void AddManufacturer(ManufacturerModel manufacturerModel)
        {
                                           
           
            var manufactutrer = new Manufacturer()
            {
                Id = manufacturerModel.Id,
                NameOfManfluencer = manufacturerModel.NameOfManafacturer,
                AgreedPercentage = manufacturerModel.AgreedPercentageOfTotalEarnings,
                TypeOfManfluencer = (int)manufacturerModel.TypeOfManufacturer,
            };
            _manfacturerRepository.Add(manufactutrer);
        }

        public void DeleteManufacturerById(int id)
        {
            var manufacturer = _manfacturerRepository.GetAll()
                                            .FirstOrDefault(x => x.Id == id);
            if(manufacturer == null)
            {
                throw new Exception("Manufacturer doesn't exist");
            }

            _manfacturerRepository.Delete(manufacturer);
                                            
        }
        
        public double TotatlEarningsOfManufacturer(ManufacturerModel manufacturerModel)
        {
            var manufacturer = _manfacturerRepository.GetAll()
                                                     .FirstOrDefault(x => x.Id == manufacturerModel.Id);

            var totalEarnings = manufacturer.TotalEarnings.ToString();
            var totalEarningsDouble =  double.Parse(totalEarnings);
            // LAST TO DO 
            return   totalEarningsDouble * manufacturer.AgreedPercentage / 100;
        }

     
    }
}
