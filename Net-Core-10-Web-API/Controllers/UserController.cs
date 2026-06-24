using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net_Core_10_Domain.IRepository;
using Net_Core_10_Domain.IService;

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
        public async Task<ActionResult<IEnumerable<string>>> GetAll()
        {   
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
