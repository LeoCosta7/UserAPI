using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("Api/controller")]
    public class UserManagerController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return null;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser()
        {
            return null;
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
