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
        private readonly IRepository<OrderProduct> _orderProductRepository;

        public OrderService(IRepository<Order> orderRepo,
            IUserRepository<User> userRepo,
            IMapper mapper,
            IRepository<Product> productRepository,
            IRepository<OrderProduct> orderProductRepository)
        {
            _orderRepository = orderRepo;
            _userRepository = userRepo;
            _mapper = mapper;
            _productRepository = productRepository;
            _orderProductRepository = orderProductRepository;
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
                Order order = _orderRepository.GetAll().Where(x => x.UserId == userId).LastOrDefault();
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

        public int AddProductToOrder(int orderId, int productId, string userId) // koga dodaavis veke postoecki produkt vo order(so ist orderId i productId vage errror alreaady exist od database).
        {

            try
            {
                Product product = _productRepository.GetById(productId);
                Order order = _orderRepository.GetById(orderId);
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
                
                Order order = _orderRepository.GetById(orderId);

                order.Status = (StatusType)status;

                if(status == StatusTypeViewModel.Paid || status == StatusTypeViewModel.Delivered) 
                {
                    User user = _userRepository.GetById(userId);

                    _orderRepository.Insert(new Order()
                    {
                        User = user,
                        Status = StatusType.Init,
                        DateCreated = DateTime.UtcNow
                        
                    });

                    UpdateProductQuantity(order.OrderId);
                }
               return _orderRepository.Update(order);
            }
            catch(Exception ex)
            {
                string message = $"Something went wrong with updating the Status! {ex.InnerException}";
                throw new Exception(message, ex);
            }
        }


        public void UpdateProductQuantity(int orderId) // update rabote samo so 1, ako sakis da rabote so kolku quantity ke pisis trebe: da dodadis vo view-to quantity field ogranicen so kolicnta na proizvodot
        {                                             // i taa kolicina da a dodadis kako parametar na vaa funkcija za da moze tolku da se odzeme vo databazata
            Order order = _orderRepository.GetById(orderId);
            foreach(var product in order.OrderProducts)
            {
                Product productForUpdate = _productRepository.GetById(product.ProductId);
                productForUpdate.Quantity -= 1;
                _productRepository.Update(productForUpdate);
            }
        }


        public bool RemoveProductFromOrder(int orderId, int productId)
        {
            try
            {
                int removeOrderProduct = _orderProductRepository.Delete(int.Parse($"{orderId}{productId}"));
                if (removeOrderProduct == 1)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                string message = $"Something went wrong with deleting your product! {ex.InnerException}";
                throw new Exception(message, ex);
                
            }
        }
    }
}
