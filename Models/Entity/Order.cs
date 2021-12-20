using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string? OrderNumber { get; set; }
        public int? OrderStatusId { get; set; }  
        public DateTime? OrderDate { get; set; } = DateTime.Now;
    }
}
