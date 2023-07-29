using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.Repository.Interface;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("Api/controller")]
    public class UserManagerController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserManagerController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            return users.Any() ? Ok(users) : NoContent();
        }

        [HttpGet("GetUserById{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            return user is null ? BadRequest("Not ound") : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            _userRepository.AddUser(user);

            return await _userRepository.Commit() ? Ok("User added") : BadRequest("Error");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser()
        {
            return null;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            return null;
        }
    }
}
