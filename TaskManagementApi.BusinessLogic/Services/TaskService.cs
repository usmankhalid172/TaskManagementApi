using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApi.BusinessLogic.IServices;
using TaskManagementApi.DataAccess.IRepositories;
using TaskManagementApi.Entities.Models;

namespace TaskManagementApi.BusinessLogic.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IEnumerable<TaskItem> GetAllTasks() => _taskRepository.GetAll();

        public TaskItem GetTaskById(Guid id) => _taskRepository.GetById(id);

        public TaskItem CreateTask(TaskItem task) => _taskRepository.Add(task);

        public TaskItem UpdateTask(Guid id, TaskItem task)
        {
            var existingTask = _taskRepository.GetById(id);
            if (existingTask == null) return null;
            task.Id = id;
            return _taskRepository.Update(task);
        }

        public bool DeleteTask(Guid id) => _taskRepository.Delete(id);
    }
}
