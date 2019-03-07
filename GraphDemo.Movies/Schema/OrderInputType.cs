using GraphDemo.Orders.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo.Orders.Schema
{
    public class OrderInputType:InputObjectGraphType<OrderInput>
    {
        public OrderInputType()
        {
            Name = "OrderInput";
            Field(x => x.Id,type:typeof(IntGraphType));
            Field(x => x.Name);
            Field(x => x.Number);
            Field(x => x.OrderRating,type:typeof(OrderRatingEnum));
            Field(x => x.Price);
            Field(x => x.UserId);
            Field(x => x.CreateDate);
        }

    }
}
