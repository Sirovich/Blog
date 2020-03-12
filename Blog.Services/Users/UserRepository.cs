using Blog.DataLayer;
using Blog.Models;
using Blog.Models.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Users
{
    public class UserRepository : IUserRepository
    {
        private UserContext userContext;

        public UserRepository(IConfiguration configuration)
        {
            var settings = new Settings
            { 
                 ConnectionString = configuration.GetConnectionString("MongoDb"),
                 Database = "UserDb",
            };

            this.userContext = new UserContext(settings);
        }

        public async Task AddUser(User user)
        {
            await userContext.Users.InsertOneAsync(user);
        }

        public async Task DeleteUser(string id)
        {
            await userContext.Users.DeleteOneAsync(
                     Builders<User>.Filter.Eq("Id", id));
        }

        public async Task<User> GetUser(string id)
        {
            return await userContext.Users.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userContext.Users.Find(_ => true).ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(s => s.Id, user.Id);
            var update = Builders<User>.Update
                            .Set(s => s, user);

            await userContext.Users.UpdateOneAsync(filter, update);
        }
    }
}
