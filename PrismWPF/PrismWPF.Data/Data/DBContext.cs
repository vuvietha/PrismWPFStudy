using PrismWPF.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWPF.Data.Data
{
    public static class DBContext
    {
        public static List<User> Users = new List<User>(){
            new User { UserId = 1, FirstName = "Ha", LastName = "Vu", Email = "ha@gmail.com", IsNew = 1, IsUpdate = false },
            new User { UserId = 2, FirstName = "Binh", LastName = "Vu", Email = "binh@gmail.com", IsNew = 1, IsUpdate = false }};
        public static List<Order> Orders = new List<Order>(){
            new Order { OrderId = 1, CustomerId = 1, EmployeeId = 1, OrderDate = DateTime.Now, ShippedDate = DateTime.Now, ShipAddress="Ha Noi" },
            new Order { OrderId = 2, CustomerId = 2, EmployeeId = 2, OrderDate = DateTime.Now, ShippedDate = DateTime.Now, ShipAddress="Ha Noi" },

           };
    }
}
