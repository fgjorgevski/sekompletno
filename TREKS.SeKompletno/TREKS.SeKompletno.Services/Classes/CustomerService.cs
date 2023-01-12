using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TREKS.SeKompletno.DataAccess.Repositories.Interfaces;
using TREKS.SeKompletno.DomainModels.Models;
using TREKS.SeKompletno.RequestModels;
using TREKS.SeKompletno.Services.Configuration;
using TREKS.SeKompletno.Services.Interfaces;

namespace TREKS.SeKompletno.Services.Classes
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IOptions<DatabaseOptions> _options;

        public CustomerService(IRepository<Customer> customerRepository, IOptions<DatabaseOptions> databaseOptions)
        {
            _customerRepository = customerRepository;
            _options = databaseOptions;

        }

        public List<Customer> GetAllUsers()
        {
            return _customerRepository.GetAll().ToList();
            

        }
        public CustomerModel Login(LoginRequestModel loginRequestModel)
        {
            var hashPassword = HashString(loginRequestModel.Password);

            var user = _customerRepository.GetAll()
                                        .FirstOrDefault(x =>
                                                         x.Username == loginRequestModel.Username &&
                                                         x.Password == hashPassword);


            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }

            ),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userModel = new CustomerModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                Token = tokenHandler.WriteToken(token),
                
            };

            return userModel;
        }

        public void Register(RegisterRequestModel registerRequestModel)
        {
            if (registerRequestModel.Password != registerRequestModel.ConfirmPassword)
            {
                throw new Exception("Password did not match!");
            }
            var hashedPassword = HashString(registerRequestModel.Password);

            var validateUser = _customerRepository.GetAll().FirstOrDefault(x => x.Username == registerRequestModel.Username);

            if(validateUser != null)
            {
                throw new Exception("User already exist"); 
            }
            

            var user = new Customer()
            {
                
                Username = registerRequestModel.Username,
                Password = hashedPassword,
                FirstName = registerRequestModel.FirstName,
                LastName = registerRequestModel.LastName,
                Address = registerRequestModel.Address,
                City = registerRequestModel.City,
                PhoneNumber = registerRequestModel.PhoneNumber
                
            };

            

            _customerRepository.Add(user);
            
        }

        // update 
        public void DeleteUserById(int id)
        {
            var user = _customerRepository.GetAll()
                                          .FirstOrDefault(x => x.Id == id);

            if(user == null)
            {
                throw new Exception("User not found");
            }
            _customerRepository.Delete(user);
        }




        private string HashString(string input)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            return Encoding.ASCII.GetString(md5Data);
        }

        public Customer GetUserById(int id)
        {
            return _customerRepository.GetAll()
                                         .FirstOrDefault(x => x.Id == id);
           
        }
    }
}
