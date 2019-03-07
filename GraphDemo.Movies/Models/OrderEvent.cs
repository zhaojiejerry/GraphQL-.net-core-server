using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo.Orders.Models
{
    public class OrderEvent
    {
        
        public int OrderId { get; set; }

        public string Name { get; set; }

        public DateTime TimeStamp { get; set; }

        public OrderRating OrderRating { get; set; }
    }
}
