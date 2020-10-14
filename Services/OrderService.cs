using AutoMapper;
using DataAccess.Interfaces;
using DomainModels.Enums;
using DomainModels.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebModels.Enums;
using WebModels.ViewModels;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderProduct> _orderProductRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IRepository<Order> orderRepo,
            IRepository<OrderProduct> orderProductRepo,
            IUserRepository<User> userRepo,
            IMapper mapper,
            IRepository<Product> productRepository)
        {
            _orderRepository = orderRepo;
            _orderProductRepository = orderProductRepo;
            _userRepository = userRepo;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public void CreateOrder(OrderViewModel model)
        {
            _orderRepository.Insert(_mapper.Map<Order>(model));
        }




        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(_orderRepository.GetAll());
        }




        public OrderViewModel GetCurrentOrder(string userId) 
        {
            Order order = _orderRepository.GetAll().FirstOrDefault(x => x.UserId == userId); // get all gi zime site od baza i gi filtrire. moze da se razmislis za nov metod so koristejne na find ako veke go ime da ne prave povik do databaza
            
            if(order == null || order.Status != StatusType.Init)                               // isto vaze za sekade deka sho go imis iskoristeno getall() ili da vrne poveke elementi pa pa filtriris
            {
                CreateOrder(new OrderViewModel { User = new UserViewModel { Id = userId }, Status = StatusTypeViewModel.Init });
                return GetCurrentOrder(userId);
            }

            return _mapper.Map<OrderViewModel>(order);
        }




        public OrderViewModel GetOrderById(int id)  // koa ke imme lista od poveke ordere
        {
            Order order = _orderRepository.GetById(id);
            if (order == null)
                throw new Exception("Order does not exist.");

            return _mapper.Map<OrderViewModel>(order);
        }





        public IEnumerable<OrderViewModel> GetUserOrders(string userId) // userot da si gi provere odrerto
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(_orderRepository.GetAll().Where(u => u.UserId == userId));
        }





        public void ChangeStatus(int orderId, StatusTypeViewModel status)
        {
            _orderRepository.Update(
                new Order
                {
                    Id = orderId,
                    Status = (StatusType)status
                });
        }





        public void AddProduct(int orderId, int productId, string userId)
        {

            Product product = _productRepository.GetById(productId);
            Order order = _orderRepository.GetById(orderId);
            User user = _userRepository.GetById(userId);

            order.OrderProducts.Add(
                new OrderProduct()
                {
                    Product = product,
                    Order = order
                });
            order.User = user;
            _orderRepository.Update(order);


        }


        


        public void RemoveProduct(int orderId, int productId)
        {
            _orderProductRepository.Delete( int.Parse($"{orderId} {productId}") );
        }

        
       
    }
}
