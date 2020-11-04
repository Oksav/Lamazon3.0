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
        void CreateOrder(OrderViewModel model, string userId);
        int ChangeStatus(int orderId, string userId, StatusTypeViewModel status);
        int AddProductToOrder(int productId, string userId);
        void RemoveProductFromOrder(int orderId, int productId);
    }
}
