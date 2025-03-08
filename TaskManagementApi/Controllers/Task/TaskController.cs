using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.BusinessLogic.IServices;
using TaskManagementApi.Entities.Models;

namespace TaskManagementApi.Controllers.Task
{
    // TaskController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_taskService.GetAllTasks());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var task = _taskService.GetTaskById(id);
            return task != null ? Ok(task) : NotFound();
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            var createdTask = _taskService.CreateTask(task);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TaskItem task)
        {
            var updatedTask = _taskService.UpdateTask(id, task);
            return updatedTask != null ? Ok(updatedTask) : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return _taskService.DeleteTask(id) ? NoContent() : NotFound();
        }
    }
}
