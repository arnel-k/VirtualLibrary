using Microsoft.AspNetCore.Mvc;

namespace vLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get(){
            return "Hello from test!";
        }
    }
}