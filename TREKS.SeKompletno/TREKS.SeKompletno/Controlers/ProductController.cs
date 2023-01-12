using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TREKS.SeKompletno.RequestModels;
using TREKS.SeKompletno.Services.Interfaces;

namespace TREKS.SeKompletno.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateProduct([FromBody] ProductRequestModel productRequestModel)
        {


            //orderRequestModel.UserId = GetAuthorziedUserId();
            _productService.AddProduct(productRequestModel);

            return Ok("Product added");



        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProcucts()
        {
            
            var response = _productService.GetAllProducts();
            return Ok(response);

            
            
        }

        [HttpGet]
        [Route("GetProductById")]
        public IActionResult GetProductById([FromQuery] int id)
        {
            try
            {
            var response = _productService.GetProductById(id);
            return Ok(response);

            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        
        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct([FromQuery] int id)
        {
            try
            {
             _productService.DeleteProductById(id);
                return Ok();

            }
            catch (Exception)
            {

                throw new Exception();
            }
            


        }

    }
}
