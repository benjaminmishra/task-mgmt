using Microsoft.AspNetCore.Mvc;
using TaskManagement.Data;
using TaskManagement.Api.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly TaskManagementDbContext _context;

        public TaskController(TaskManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public List<GetTask> Get()
        {
            var tasks = _context.Tasks.Include(x=>x.TaskStatus).Select(x=> new GetTask {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Status = x.TaskStatus.Status
            }).ToList();

            return tasks;
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public ActionResult<GetTask> Get(int id)
        {
            var task = _context.Tasks.Include(x => x.TaskStatus).FirstOrDefault(x => x.Id == id);

            if (task != null)
            {
                var result = new GetTask
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Status = task.TaskStatus.Status
                };

                return Ok(result);
            }
            else
                return NotFound();
        }

        // POST api/<TaskController>
        [HttpPost]
        public void Post(CreateTaskDto createTaskReq)
        {
            Data.Task task = new Data.Task {
                Name = createTaskReq.Name,
                Description = createTaskReq.Description,
                StatusId = 1
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
            
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
