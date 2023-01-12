using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DomainModels.Models;
using TREKS.SeKompletno.RequestModels;

namespace TREKS.SeKompletno.Services.Interfaces
{
    public interface ICustomerService
    {
        void Register(RegisterRequestModel registerRequestModel);
        CustomerModel Login(LoginRequestModel loginRequestModel);

        List<Customer> GetAllUsers();

        Customer GetUserById(int id);

    }
}
