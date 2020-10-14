using System;
using System.Collections.Generic;
using System.Text;
using WebModels.Enums;
using WebModels.ViewModels;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderViewModel> GetAllOrders();
        IEnumerable<OrderViewModel> GetUserOrders(string userId);
        OrderViewModel GetOrderById(int id);
        OrderViewModel GetCurrentOrder(string userId);
        void CreateOrder(OrderViewModel model);
        void ChangeStatus(int orderId, StatusTypeViewModel status);
        void AddProduct(int orderId, int productId, string userId);
        void RemoveProduct(int orderId, int productId);
    }
}
