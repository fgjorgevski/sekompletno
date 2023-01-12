﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TREKS.SeKompletno.RequestModels
{
    public class RegisterRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PhoneNumber{ get; set; }
    }
}
