using GraphDemo.Orders.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo.Orders.Services
{
    public interface IOrderEventService
    {
        ConcurrentStack<OrderEvent> AllEvents { get; }

        void AddError(Exception ex);

        OrderEvent AddEvent(OrderEvent e);

        IObservable<OrderEvent> EventStream();

    }
}
