using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasRestFull.Dto;
using TareasRestFull.Models;
using TareasRestFull.Services;

[Route("api/[controller]")]
[ApiController]
public class TareasController : ControllerBase
{
    private readonly ITareaService _taskService;

        public TareasController(ITareaService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTasks()
        {
            var tasks = await _taskService.GetTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTask(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Tarea>> CreateTask([FromBody] CreateTareaDto taskItem)
        {
            var tarea = new Tarea
            {
                Title = taskItem.Title,
                Description = taskItem.Description,
                CreatedAt = taskItem.CreatedAt,
                UpdatedAt = DateTime.Now,
            };

            var task = await _taskService.CreateTaskAsync(tarea);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTareaDto taskItem)
        {
            if (id != taskItem.Id)
            {
                return BadRequest();
            }

            var tarea = new Tarea
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                UpdatedAt = DateTime.Now,
            };

            var result = await _taskService.UpdateTaskAsync(tarea);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _taskService.DeleteTaskAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
}