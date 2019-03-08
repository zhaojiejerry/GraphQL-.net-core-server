using GraphDemo.Orders.Services;
using GraphQL.Types;

namespace GraphDemo.Orders.Schema
{
    public class OrdersQuery: ObjectGraphType
    {
        public OrdersQuery(IOrderService orderService)
        {
            Name = "Query";

            Field<ListGraphType<OrderType>>("orders", resolve: context => orderService.GetAsync());

            FieldAsync<OrderType>("getOrderById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context =>
                 {
                     var Id = context.GetArgument<int>("id");
                     var result = await orderService.GetByIdAsync(Id);
                     return result;
                 }
                );
        }
       
        
    }
}
