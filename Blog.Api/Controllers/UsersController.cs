using System.Threading.Tasks;
using Blog.Models.Users;
using Blog.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userRepository.GetUsers();
            return Ok(users);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(user);
            }

            await userRepository.UpdateUser(user);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await userRepository.GetUser(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(user);
            }

            await userRepository.AddUser(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await userRepository.DeleteUser(id);
            return Ok();
        }
    }
}
