using System;
using System.Collections.Generic;
using System.Linq;
using TREKS.SeKompletno.DataAccess.Repositories.Interfaces;
using TREKS.SeKompletno.DomainModels.Models;
using TREKS.SeKompletno.RequestModels;
using TREKS.SeKompletno.Services.Interfaces;

namespace TREKS.SeKompletno.Services.Classes
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(ProductRequestModel productRequestModel)
        {
            var product = new Product()
            {
                Id = productRequestModel.Id,
                NameOfProduct = productRequestModel.NameOfProduct,
                Color = (int)productRequestModel.Colors,
                Price = productRequestModel.Price,
                Size = (int)productRequestModel.Size,
                TypeOfProduct = (int)productRequestModel.TypeOfProduct,
                ProductsLeft = productRequestModel.ProductsLeft,
                Image = productRequestModel.Image,
                Description = productRequestModel.Description
            };


            _productRepository.Add(product);
        }

        public void DeleteProductById(int id)
        {
            var product = _productRepository.GetAll().FirstOrDefault(x => x.Id == id);

            if(product == null)
            {
                throw new Exception("This product doesn't exist");
            }
            _productRepository.Delete(product);

        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

    

        public Product GetProductById(int id)
        {
         
            return _productRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        // GENERIC ""GET ALL PRODUCTS"" BECOUSE OF TYPE OF PRODUCTS
    }
}
