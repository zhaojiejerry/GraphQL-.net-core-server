using GraphDemo.Orders.Models;
using GraphQL.Types;

namespace GraphDemo.Orders.Schema
{
    public class OrderRatingEnum: EnumerationGraphType<OrderRating>
    {
        public OrderRatingEnum()
        {
            Name = "OrderRatings";
            Description = "";

            AddValue(OrderRating.Unrated.ToString(), "Unrated", OrderRating.Unrated);
            AddValue(OrderRating.PG13.ToString(), ".PG13", OrderRating.PG13);
            AddValue(OrderRating.PG.ToString(), "PG", OrderRating.PG);
            AddValue(OrderRating.NC17.ToString(), "NC17", OrderRating.NC17);
            AddValue(OrderRating.G.ToString(), "G", OrderRating.G);
            AddValue(OrderRating.R.ToString(), "R", OrderRating.R);
        }
    }
}
