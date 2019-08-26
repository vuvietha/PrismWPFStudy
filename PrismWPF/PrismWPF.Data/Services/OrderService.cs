using PrismWPF.Data.Data;
using PrismWPF.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWPF.Data.Services
{
    public class OrderService : IOrderService
    {
        public List<Order> DeleteOrder(Order order)
        {
            DBContext.Orders.Remove(order);
            return DBContext.Orders;
        }

        public List<Order> GetAllOrder()
        {
            return DBContext.Orders;
        }

        public void SaveOrders(List<Order> orders)
        {
            DBContext.Orders.AddRange(orders);
        }
        public List<Order> DeleteOrders(List<Order> orders)
        {

            foreach (var item in orders)
            {
                DBContext.Orders.Remove(item);
            }
            return DBContext.Orders;
        }
    }
}
