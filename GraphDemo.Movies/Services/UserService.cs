using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphDemo.Orders.Models;

namespace GraphDemo.Orders.Services
{
    public class UserService : IUserService
    {
        private readonly IList<User> _users;
        public UserService()
        {
            _users = new List<User>
            {
                new User{ Id = 1,Name = "李兆杰"},
                new User{ Id = 2,Name = "王凯"},
                new User{ Id = 3,Name = "范笑宇"},
                new User{ Id = 4,Name = "李艳茹"},
                new User{ Id = 5,Name = "刘瑞霞"}
            };
        }
        public Task<User> CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAsync()
        {
            return Task.FromResult(_users.AsEnumerable());
        }

        public Task<User> GetByIdAsync(int id)
        {
            return Task.FromResult(_users.SingleOrDefault(x => x.Id == id));
        }

        public Task<User> updateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
