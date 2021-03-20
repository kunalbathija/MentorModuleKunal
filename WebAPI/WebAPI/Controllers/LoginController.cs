using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        //to be made async for other data structures to be passed.
        public IEnumerable<string> Display()
        {
            return new string[] { "My first WebAPI Project"};
        }
    }
}
