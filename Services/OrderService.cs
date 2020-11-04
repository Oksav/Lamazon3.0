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
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IRepository<Order> orderRepo,
            IUserRepository<User> userRepo,
            IMapper mapper,
            IRepository<Product> productRepository)
        {
            _orderRepository = orderRepo;
            _userRepository = userRepo;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        

        public IEnumerable<OrderViewModel> GetAllOrders() 
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(_orderRepository.GetAll());
        }


        public IEnumerable<OrderViewModel> GetUserOrders(string userId) // userot da si gi provere odrerto
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(_orderRepository.GetAll().Where(x => x.UserId == userId));
        }



        public OrderViewModel GetCurrentOrder(string userId) 
        {
            try
            {
                Order order = _orderRepository.GetAll().Where(x => x.UserId == userId && x.Status == StatusType.Init).FirstOrDefault();
                OrderViewModel orderViewModel = _mapper.Map<OrderViewModel>(order);

                if(order.OrderProducts != null){

                IEnumerable<Product> products = order.OrderProducts.Select(x => _productRepository.GetById(x.ProductId));

                orderViewModel.Products = _mapper.Map<List<ProductViewModel>>(products);

                }
                               
                return orderViewModel;
                           
            }
            catch (Exception ex)
            {
                string message = $"Order does not exist! {ex.InnerException}";
                throw new Exception(message ,ex);
            }

            
        }

        public int AddProductToOrder(int productId, string userId) // koga dodaavis veke postoecki produkt vo order(so ist orderId i productId vage errror alreaady exist od database).
        {

            try
            {
                Product product = _productRepository.GetById(productId);
                Order order = _orderRepository.GetAll().Where(x => x.UserId == userId && x.Status == StatusType.Init).LastOrDefault();
                User user = _userRepository.GetById(userId);

                OrderProduct newOrderProduct = new OrderProduct { Order = order, Product = product };

                order.OrderProducts.Add(newOrderProduct);
                order.User = user;
                return _orderRepository.Update(order);
            }
            catch (Exception ex)
            {
                string message = $"Something went wrong with adding your product {ex.InnerException}";
                throw new Exception(message, ex);
            }

        }




        public OrderViewModel GetOrderById(int id)  // koa ke imme lista od poveke ordere
        {
            try
            {
                return _mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
            }
            catch(Exception ex)
            {
                string message = $"Order does not exist! {ex.InnerException}";
                throw new Exception(message, ex);
            }
        }


        public void CreateOrder(OrderViewModel model, string userId)
        {
            try
            {
                User user = _userRepository.GetById(userId);

                Order createdOrder = _mapper.Map<Order>(model);

                createdOrder.User = user;

                _orderRepository.Insert(createdOrder);
            }
            catch (Exception ex)
            {
                string message = $"Something went wrong with creating your order! {ex.InnerException}";
                throw new Exception(message, ex);
            }
        }



        public int ChangeStatus(int orderId,string userId, StatusTypeViewModel status)
        {
            try
            {
                User user = _userRepository.GetById(userId);
                Order order = _orderRepository.GetById(orderId);

                order.Status = (StatusType)status;

                if(status == StatusTypeViewModel.Processing)
                {
                    _orderRepository.Insert(new Order()
                    {
                        User = user,
                        Status = StatusType.Init
                    });
                }
               return _orderRepository.Update(order);
            }
            catch(Exception ex)
            {
                string message = $"Something went wrong with updating the Status! {ex.InnerException}";
                throw new Exception(message, ex);
            }
        }





       

        public void RemoveProductFromOrder(int orderId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
