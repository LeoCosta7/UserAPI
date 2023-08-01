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

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            IEnumerable<User> users = await _userRepository.GetAllUsers();

            return users.Any() ? Ok(users) : NoContent();
        }


        [HttpGet("GetUserById{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            User user = await _userRepository.GetUserById(id);

            return user is null ? BadRequest("User Not Found") : Ok(user);
        }


        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            _userRepository.AddUser(user);

            return await _userRepository.Commit() ? Ok("User successfully added ") : BadRequest("Error");
        }


        [HttpPut("UpdateUser{id}")]
        public async Task<IActionResult> UpdateUser(int id, User ReceiverUser)
        {
            User userDb = await _userRepository.GetUserById(id);

            if (userDb is null)
                NotFound("User Not Found");

            //userDb.Name = ReceiverUser.Name ?? userDb.Name;
            //userDb.Address = ReceiverUser.Address ?? userDb.Address;
            //userDb.DateOfBirth = ReceiverUser.DateOfBirth ?? userDb.DateOfBirth;

            _userRepository.UpdateUser(userDb);

            return await _userRepository.Commit() ? Ok("User successfully updated") : BadRequest("Error");
        }


        [HttpDelete("DeleteUser{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User userDb = await _userRepository.GetUserById(id);

            if (userDb is null)
                NotFound("User not found");

            _userRepository.DeleteUser(userDb);

            return await _userRepository.Commit() ? Ok("User sucessfully delete") : BadRequest("Error");
        }
    }
}
