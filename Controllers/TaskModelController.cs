using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TestApp1.Models;

namespace TestApp1.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskModelController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TaskModelController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetTasks()
        {
            return await _context.TaskModels.ToListAsync();
        }

        // GET: api/tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTask(int id)
        {
            var task = await _context.TaskModels.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostTask(TaskModel taskmodel)
        {
            _context.TaskModels.Add(taskmodel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = taskmodel.TaskId }, taskmodel);
        }

        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, TaskModel taskmodel)
        {
            if (id != taskmodel.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(taskmodel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{Title}")]
        public async Task<IActionResult> DeleteTask(string title)
        {
            var task = await _context.TaskModels.FindAsync(title);
            if (task == null)
            {
                return NotFound();
            }

            _context.TaskModels.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.TaskModels.Any(e => e.TaskId == id);
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TaskModel>>> GetUserTasks()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the current user's ID
        //    var tasks = await _context.TaskModels.Where(t => t.UserId == userId).ToListAsync();
        //    return tasks;
        //}

    }
}
