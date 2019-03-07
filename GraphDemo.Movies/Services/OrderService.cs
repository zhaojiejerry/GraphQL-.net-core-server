using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphDemo.Orders.Models;

namespace GraphDemo.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderEventService _orderEventService;
        private readonly IList<Order> _orders;
        public OrderService(IOrderEventService orderEventService)
        {
            _orderEventService = orderEventService;
            #region Orders

            _orders = new List<Order>
            {
                new Order
                {
                Id =1,
                Name = "Gps",
                UserId = 1,
                CreateDate = new DateTime(2019,3,5),
                Price = 200,
                Number = 5,
                TotalAmount = 1000,
                OrderRating = OrderRating.G
                },
                new Order
                {
                Id =2,
                Name = "喷漆",
                UserId = 2,
                CreateDate = new DateTime(2019,3,5),
                Price = 200,
                Number = 5,
                TotalAmount = 1000,
                OrderRating = OrderRating.G
                },
                new Order
                {
                Id =3,
                Name = "方向盘",
                UserId = 3,
                CreateDate = new DateTime(2019,2,5),
                Price = 2200,
                Number = 10,
                TotalAmount = 22000,
                OrderRating = OrderRating.G
                },
                new Order
                {
                Id =4,
                Name = "座椅",
                UserId = 4,
                CreateDate = new DateTime(2019,3,2),
                Price = 5000,
                Number = 1,
                TotalAmount = 5000,
                OrderRating = OrderRating.G
                },
                new Order
                {
                Id =5,
                Name = "大屏机",
                UserId = 5,
                CreateDate = new DateTime(2019,3,1),
                Price = 1000,
                Number = 2,
                TotalAmount = 2000,
                OrderRating = OrderRating.G
                },
            };
            OrderEventService = orderEventService;
            #endregion
        }

        public IOrderEventService OrderEventService { get; }

        public async Task<Order> CreateAsync(Order order)
        {
            _orders.Add(order);
            var orderEvent = new OrderEvent()
            {
                Name = $"Add Order",
                OrderId = order.Id,
                TimeStamp = DateTime.Now,
                OrderRating = order.OrderRating
            };
            _orderEventService.AddEvent(orderEvent);
            return await Task.FromResult(order);
        }

        public async Task<Order> DeleteAsync(int id)
        {
            var order = _orders.SingleOrDefault(x => x.Id == id);
            if (order == null)
            {
                throw new ArgumentException(String.Format("Order ID {0} 不正确", id));
            }
            else
            {
              _orders.Remove(order);
            }
            return await Task.FromResult(order);
        }

        public Task<IEnumerable<Order>> GetAsync()
        {
            return Task.FromResult(_orders.AsEnumerable());
        }

        public Task<Order> GetByIdAsync(int id)
        {
            var order = _orders.SingleOrDefault(x => x.Id == id);
            if(order == null)
            {
                throw new ArgumentException(String.Format("Order ID {0} 不正确",id));
            }
            return Task.FromResult(order);
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            var oldorder = _orders.SingleOrDefault(x => x.Id == order.Id);
            if (oldorder == null)
            {
                throw new ArgumentException(String.Format("Order ID {0} 不正确", order.Id));
            }
            else
            {
                oldorder.Name = order.Name;
                oldorder.Number = order.Number;
                oldorder.Price = order.Price;
                oldorder.TotalAmount = order.TotalAmount;
                oldorder.UserId = order.UserId;
                oldorder.OrderRating = order.OrderRating;
                oldorder.CreateDate = order.CreateDate;
            }
            return await Task.FromResult(oldorder);
        }
    }
}