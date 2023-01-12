using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using TREKS.SeKompletno.RequestModels;
using TREKS.SeKompletno.Services.Interfaces;

namespace TREKS.SeKompletno.Controlers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }



        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] LoginRequestModel loginRequestModel)
        
        
        {
            

                var user = _customerService.Login(loginRequestModel);
                if (user == null)
                {
                    return null;
                }
                return Ok(user);
         
           
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterRequestModel registerRequestModel)
        {

         
            try
            {
                _customerService.Register(registerRequestModel);
                return Ok("User successfully registered");
            }
            catch (Exception)
            {

                throw new Exception();
            }



        }
        [AllowAnonymous]
        [HttpGet]
        [Route("getallusers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var response = _customerService.GetAllUsers();
                return Ok(response);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getuserbyid")]
        public IActionResult GetUserById([FromQuery] int id)
        {
            try
            {
                var user = _customerService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
           
           

                
           
           
            // username confiramtion // servirce
            // number confiramtion
            // admin confiramtion with token for UI 
            


        }

    }

