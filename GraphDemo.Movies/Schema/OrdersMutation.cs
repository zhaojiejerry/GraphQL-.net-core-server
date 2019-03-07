using GraphDemo.Orders.Models;
using GraphDemo.Orders.Services;
using GraphQL.Types;
using System.Linq;

namespace GraphDemo.Orders.Schema
{
    public class OrdersMutation : ObjectGraphType
    {
        public OrdersMutation(IOrderService orderService)
        {
            Name = "Mutation";

            FieldAsync<OrderType>(
                "createOrder",
                arguments: new QueryArguments(new QueryArgument<OrderInputType> { Name = "order"}),
                resolve: async context =>
                {
                    var orderInput = context.GetArgument<OrderInput>("order");

                    var orders = await orderService.GetAsync();

                    var maxId = orders.Select(x => x.Id).Max();

                    var order = new Order
                    {
                    Id = ++maxId,
                    Name = orderInput.Name,
                    Number = orderInput.Number,
                    Price = orderInput.Price,
                    UserId = orderInput.UserId,
                    OrderRating = orderInput.OrderRating,
                    CreateDate = orderInput.CreateDate,
                    TotalAmount = orderInput.Price * orderInput.Number
                    };
                    var result =  await orderService.CreateAsync(order);
                    return result;
                });
            FieldAsync<OrderType>(
              "updateOrder",
              arguments: new QueryArguments(new QueryArgument<OrderInputType> { Name = "order" }),
              resolve: async context =>
              {
                  var orderInput = context.GetArgument<OrderInput>("order");
                 
                  var order = new Order
                  {
                      Id = orderInput.Id,
                      Name = orderInput.Name,
                      Number = orderInput.Number,
                      Price = orderInput.Price,
                      UserId = orderInput.UserId,
                      OrderRating = orderInput.OrderRating,
                      CreateDate = orderInput.CreateDate,
                      TotalAmount = orderInput.Price * orderInput.Number
                  };
                  var result = await orderService.UpdateAsync(order);
                  return result;
              });
            FieldAsync<OrderType>(
            "deleteOrder",
            arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            resolve: async context =>
            {
                var Id = context.GetArgument<int>("id");
                var result = await orderService.DeleteAsync(Id);
                return result;
            });
        }
    }
}
