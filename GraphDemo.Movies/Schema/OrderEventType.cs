using GraphDemo.Orders.Models;
using GraphQL.Types;

namespace GraphDemo.Orders.Schema
{
    public class OrderEventType : ObjectGraphType<OrderEvent>
    {
        public OrderEventType()
        {
            Name = "OrderEvent";

            Field(e => e.Name);
            Field(e => e.OrderId);
            Field(e => e.TimeStamp);
            Field(e => e.OrderRating, type: typeof(OrderRatingEnum));
        }
    }
}
