using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using TREKS.SeKompletno.RequestModels;
using TREKS.SeKompletno.Services.Interfaces;

namespace TREKS.SeKompletno.Controlers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }



        [HttpPost]
        [Route("CreateOrder")]
        public IActionResult CreateOrder([FromBody] OrderRequestModel orderRequestModel)
        {
            try
            {


                orderRequestModel.CustomerId = GetAuthorziedUserId();
                _orderService.AddOrder(orderRequestModel);

                return Ok("Order added");
            }
            catch (Exception)
            {

                throw new Exception(); 
            }

      

        }

        [HttpGet]
        [Route("GetOrders")]
        public IActionResult GetOrders()
        {

            try
            {
                var userId = GetAuthorziedUserId();
                var response = _orderService.GetAllOrders();

                return Ok(response);
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }

        [HttpGet]
        [Route("GetOrderById")]
        public IActionResult GetOrderById([FromQuery] int id)
        {
            try
            {
                var userId = GetAuthorziedUserId();
                var repsone = _orderService.GetOrderById(id);
                return Ok(repsone);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        private int GetAuthorziedUserId()
        {
            bool userIdExists = int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);

            if (!userIdExists)
            {
                string name = User.FindFirst(ClaimTypes.Name)?.Value;
                throw new Exception("Name identifier claim does not exist!");
            }

            return userId;
        }


    }
}
