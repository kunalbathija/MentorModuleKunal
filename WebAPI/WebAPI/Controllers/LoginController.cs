using Business;
using Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager _loginManager;

        public LoginController(ILoginManager loginManager)
        {
            this._loginManager = loginManager;
        }

        [HttpGet]
        //to be made async for other data structures to be passed.
        public IEnumerable<string> Display()
        {
            return new string[] { "My first WebAPI Project"};
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if(_loginManager.CheckLogin(user))
            {
                return Ok(true);
            }
            else
            {
                return Unauthorized(false);
            }
        }
    }
}
