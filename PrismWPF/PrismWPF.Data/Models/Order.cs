using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWPF.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipAddress { get; set; }

    }
}
