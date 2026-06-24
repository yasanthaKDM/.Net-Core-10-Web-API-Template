using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net_Core_10_Domain.Data;
using Net_Core_10_Domain.IRepository;
using Net_Core_10_Domain.IService;
using Net_Core_10_ServiceContract;

namespace Net_Core_10_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {   
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserDTO user)
        {
            if (user == null) return BadRequest();
            var created = await _userService.CreateUserAsync(user);
            return Created(string.Empty, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(int id, [FromBody] UserDTO user)
        {
            if (user == null) return BadRequest();
            var updated = await _userService.UpdateUserAsync(user);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUserAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
