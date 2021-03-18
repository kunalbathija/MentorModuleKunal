using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        //to be made async for other data structures to be passed.
        public ActionResult<string> Display()
        {
            return "My first ASP.NET Core project, trial second commit";
        }
    }
}
