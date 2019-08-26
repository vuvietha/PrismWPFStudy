using PrismWPF.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWPF.Data.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrder();
        void SaveOrders(List<Order> orders);
        List<Order> DeleteOrder(Order user);
        List<Order> DeleteOrders(List<Order> orders);
    }
}
