using GraphDemo.Orders.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo.Orders.Schema
{
    public class OrdersQuery: ObjectGraphType
    {
        public OrdersQuery(IOrderService orderService)
        {
            Name = "Query";

            Field<ListGraphType<OrderType>>("orders", resolve: context => orderService.GetAsync());
        }
    }
}
