using System;
using System.Collections.Generic;
using System.Linq;
using TREKS.SeKompletno.DataAccess.Repositories.Interfaces;
using TREKS.SeKompletno.DomainModels.Enums;
using TREKS.SeKompletno.DomainModels.Models;
using TREKS.SeKompletno.RequestModels;
using TREKS.SeKompletno.Services.Interfaces;

namespace TREKS.SeKompletno.Services.Classes
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IRepository<Order> orderRepository,
                            IRepository<Customer> customerRepository, 
                            IRepository<Product> productRepository  )
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public void AddOrder(OrderRequestModel orderRequestModel)
        {
            var product = _productRepository.GetAll()
                                            .FirstOrDefault(x =>
                                                            x.Id == orderRequestModel.ProductRequestModel.Id);

            
                                        
            if(product.ProductsLeft > 0)
            {
                product.InStock = true;
            }
            if(product.ProductsLeft <= 0)
            {
                product.InStock = false;
                throw new Exception("Out of stock");
                // IF <10 LET ADMIN KNOW 
            }

            var user = _customerRepository.GetAll()
                                          .FirstOrDefault(x =>
                                                          x.Id == orderRequestModel.CustomerId);

            
            

            var order = new Order()
            {
                Id = orderRequestModel.Id,
                Customer = user,
                CustomerId = user.Id,
                ProductId = product.Id,
                Price = product.Price,
                Size = (int)orderRequestModel.Size

            };
            product.ProductsLeft -- ;
           

            _orderRepository.Add(order);
        }


        public List<Order> GetAllOrders()
        {
            var orders =_orderRepository.GetAll().ToList();

            if(orders == null)
            {
                return null;
            }
            return orders;
        }

        public Order GetLastOrder()
        {
            var orders = _orderRepository.GetAll().ToList();
            if(orders == null)
            {
                return null;
            }

            return orders[^1];
        }

        public Order GetOrderById(int id)
        {
           var order = _orderRepository.GetAll().FirstOrDefault(x => x.Id == id);

            if(order == null)
            {
                return null;
            }
            return order;
                
        }

      
    }
}
