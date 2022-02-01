using Microsoft.AspNetCore.Mvc;
using PerfectChannel.Domain.DTO;
using PerfectChannel.Domain.Interfaces.Services;

namespace PerfectChannel.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService){
            _taskService = taskService;
        }
        [HttpGet]
        public TasksResponseDTO Get(){
            return _taskService.GetTasks();
        }
    }
}
