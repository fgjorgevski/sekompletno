using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DomainModels.Models;
using TREKS.SeKompletno.RequestModels;

namespace TREKS.SeKompletno.Services.Interfaces
{
    public interface IProductService
    {
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        void AddProduct(ProductRequestModel productRequestModel);
        void DeleteProductById(int id);

    }
}
