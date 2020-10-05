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

        public OrderService(IRepository<Order> orderRepo,
            IRepository<OrderProduct> orderProductRepo,
            IUserRepository<User> userRepo,
            IMapper mapper)
        {
            _orderRepository = orderRepo;
            _orderProductRepository = orderProductRepo;
            _userRepository = userRepo;
            _mapper = mapper;
        }

        

        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(_orderRepository.GetAll());
        }

        public OrderViewModel GetCurrentOrder(string userId)
        {
            Order order = _orderRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            if(order == null || order.Status != StatusType.Init)
            {
                CreateOrder(new OrderViewModel { User = new UserViewModel { Id = userId } });
                return GetCurrentOrder(userId);
            }

            return _mapper.Map<OrderViewModel>(order);
        }

        public OrderViewModel GetOrderById(int id)
        {
            Order order = _orderRepository.GetById(id);
            if (order == null)
                throw new Exception("Order does not exist.");

            return _mapper.Map<OrderViewModel>(order);
        }

        public IEnumerable<OrderViewModel> GetUserOrders(string userId)
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

        public void AddProduct(int orderId, int productId)
        {
           _orderProductRepository.Insert(
                new OrderProduct
                {
                    OrderId = orderId,
                    ProductId = productId
                }
                );
        }

        public void RemoveProduct(int orderId, int productId)
        {
            _orderProductRepository.Delete( int.Parse($"{orderId} {productId}") );
        }

        
        public void CreateOrder(OrderViewModel model)
        {
            _orderRepository.Insert(_mapper.Map<Order>(model));
        }
    }
}
