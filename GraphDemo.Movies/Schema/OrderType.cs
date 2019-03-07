using GraphDemo.Orders.Models;
using GraphDemo.Orders.Services;
using GraphQL.Types;

namespace GraphDemo.Orders.Schema
{
    public class OrderType: ObjectGraphType<Order>
    {
        public OrderType(IUserService userService)
        {
            Name = "Order";
            Description = "";

            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.UserId);
            Field(x => x.CreateDate);
            Field(x => x.Price);
            Field(x => x.Number);
            Field(x => x.TotalAmount);

            Field<UserType>("user", resolve: context => userService.GetByIdAsync(context.Source.UserId));

            Field<OrderRatingEnum>("orderRatings", resolve: context => context.Source.OrderRating);

            Field<StringGraphType>("customString", resolve: context => "1234");
        }
    } 
}
