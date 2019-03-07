using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using GraphDemo.Orders.Models;

namespace GraphDemo.Orders.Services
{
    public class OrderEventService : IOrderEventService
    {
        private readonly ISubject<OrderEvent> _eventStream = new ReplaySubject<OrderEvent>();
        public ConcurrentStack<OrderEvent> AllEvents { get; }

        public OrderEventService()
        {
            AllEvents = new ConcurrentStack<OrderEvent>();
        }
        public void AddError(Exception ex)
        {
            _eventStream.OnError(ex);
        }

        public OrderEvent AddEvent(OrderEvent e)
        {
            AllEvents.Push(e);
            _eventStream.OnNext(e);
            return e;
        }

        public IObservable<OrderEvent> EventStream()
        {
           return _eventStream.AsObservable();
        }
    }
}
