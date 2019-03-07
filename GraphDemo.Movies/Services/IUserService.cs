using GraphDemo.Orders.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphDemo.Orders.Services
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);

        Task<IEnumerable<User>> GetAsync();
        Task<User> CreateAsync(User user);
        Task DeleteAsync(int id);
        Task<User> updateAsync(int id);
    }
}
