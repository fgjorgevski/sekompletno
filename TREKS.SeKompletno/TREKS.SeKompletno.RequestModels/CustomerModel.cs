using System;
using System.Collections.Generic;
using System.Text;

namespace TREKS.SeKompletno.RequestModels
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Token { get; set; }
        public List<OrderRequestModel> OrderList { get; set; }




    }
}
