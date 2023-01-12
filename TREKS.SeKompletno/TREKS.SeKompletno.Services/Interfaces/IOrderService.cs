using System;
using System.Collections.Generic;
using System.Text;
using TREKS.SeKompletno.DomainModels.Models;
using TREKS.SeKompletno.RequestModels;

namespace TREKS.SeKompletno.Services.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(OrderRequestModel orderRequestModel);
        Order GetLastOrder();
        Order GetOrderById(int id);
        List<Order> GetAllOrders();
    }
}
