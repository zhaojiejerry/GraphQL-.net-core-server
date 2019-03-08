using GraphDemo.Orders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphDemo.Orders.Services
{
    public interface IOrderService
    {
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> CreateAsync(Order order);
        Task<Order> DeleteAsync(int id);
        Task<Order> UpdateAsync(Order order);

    }
}
