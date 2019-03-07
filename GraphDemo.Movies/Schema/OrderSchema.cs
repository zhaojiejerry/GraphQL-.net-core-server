using GraphQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo.Orders.Schema
{
    public class OrderSchema: GraphQL.Types.Schema
    {
        public OrderSchema(
            IDependencyResolver dependencyResolver,
            OrdersQuery ordersQuery,
            OrdersMutation ordersMutation,
            OrderSubscription orderSubscription)
        {
            DependencyResolver = dependencyResolver;
            Query = ordersQuery;
            Mutation = ordersMutation;
            Subscription = orderSubscription;
        }
    }
}
