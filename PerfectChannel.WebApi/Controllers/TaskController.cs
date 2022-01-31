using Microsoft.AspNetCore.Mvc;

namespace PerfectChannel.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public string Get(){
            return "hello task";
        }
    }
}
