using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomerController : ControllerBase
    {
        [Authorize(Roles = "User")]
        [HttpGet("user")]
        public IEnumerable<string> Get()
        {
            return new string[] { "santhosh", "varadhan" };
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "santhosh", "varadhan" };
        }

    }
}
