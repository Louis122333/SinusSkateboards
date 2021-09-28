using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinusSkateboards.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderRef { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
