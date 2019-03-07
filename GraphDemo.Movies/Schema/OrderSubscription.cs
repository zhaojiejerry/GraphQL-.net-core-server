using GraphDemo.Orders.Models;
using GraphDemo.Orders.Services;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace GraphDemo.Orders.Schema
{
    public class OrderSubscription: ObjectGraphType
    {
        private IOrderEventService _orderEventService;

        public OrderSubscription(IOrderEventService orderEventService)
        {
            _orderEventService = orderEventService;
            Name = "Subscription";

            AddField(new EventStreamFieldType
            {
                Name = "orderEvent",
                Arguments = new QueryArguments(new QueryArgument<ListGraphType<OrderRatingEnum>>
                {
                    Name = "orderRatings"
                }),
                Type = typeof(OrderEventType),
                Resolver = new FuncFieldResolver<OrderEvent>(ResolveEvent),
                Subscriber = new EventStreamResolver<OrderEvent>(Subscribe)
            });
        }

        private IObservable<OrderEvent> Subscribe(ResolveEventStreamContext context)
        {
            var ratingList = context.GetArgument<IList<OrderRating>>("orderRatings", new List<OrderRating>());
            if (ratingList.Any())
            {
                OrderRating ratings = 0;

                foreach (var rating in ratingList)
                {
                    ratings = rating | rating;
                }

                return _orderEventService.EventStream().Where(e =>(e.OrderRating & ratings) == e.OrderRating);
            }
            else
            {
                return _orderEventService.EventStream();
            }
        }

        private OrderEvent ResolveEvent(ResolveFieldContext context)
        {
            var orderEvent = context.Source as OrderEvent;
            return orderEvent;
        }
    }
}
