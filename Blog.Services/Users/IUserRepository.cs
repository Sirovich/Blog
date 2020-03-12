using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Models.Users;
using MongoDB.Driver;

namespace Blog.Services.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(string id);

        Task AddUser(User user);

        Task DeleteUser(string id);

        Task UpdateUser(User user);
    }
}
