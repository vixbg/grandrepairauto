using System;
using System.Collections.Generic;
using System.Text;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Repository.Contracts
{
    interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int orderId);
        void InsertOrder(Order order);
        void DeleteOrder(int orderID);
        void UpdateOrder(Order order);
        void Save();
    }
}
