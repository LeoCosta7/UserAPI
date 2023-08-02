using Microsoft.AspNetCore.Mvc;
using UserAPI.Entity;
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
            try
            {
                IEnumerable<User> users = await _userRepository.GetAllUsers();

                return users.Any() ? Ok(users) : NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }


        [HttpGet("GetUserById{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                User user = await _userRepository.GetUserById(id);

                return user is null ? BadRequest("User Not Found") : Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserViewModel userViewModel)
        {
            try
            {
                //_userRepository.AddUser(user);

                await _userRepository.Commit();

                return Ok("User successfully added");
            }
            catch (Exception ex)
            {
                return BadRequest("Error " + ex.Message);
            }
        }

        [HttpPut("UpdateUser{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserViewModel userViewModel)
        {
            try
            {
                User userDb = await _userRepository.GetUserById(id);

                if (userDb is null)
                    return NotFound("User Not Found");

                User userMappser = _userRepository.Map(userViewModel);

                //userDb.Name = ReceiverUser.Name ?? userDb.Name;
                //userDb.Address = ReceiverUser.Address ?? userDb.Address;
                //userDb.DateOfBirth = ReceiverUser.DateOfBirth ?? userDb.DateOfBirth;

                _userRepository.UpdateUser(userMappser);
                await _userRepository.Commit();

                return Ok("User successfully updated");
            }
            catch(Exception ex)
            {
                return BadRequest("Error " + ex.Message);
            }
        }

        [HttpDelete("DeleteUser{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                User userDb = await _userRepository.GetUserById(id);

                if (userDb is null)
                    return NotFound("User not found");

                _userRepository.DeleteUser(userDb);
                await _userRepository.Commit();

                return Ok("User sucessfully delete");
            }
            catch (Exception ex)
            {
                return BadRequest("Error " + ex.Message);
            }            
        }
    }
}
