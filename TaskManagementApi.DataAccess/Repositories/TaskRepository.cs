using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApi.DataAccess.IRepositories;
using TaskManagementApi.Entities.Models;

namespace TaskManagementApi.DataAccess.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Dictionary<Guid, TaskItem> _tasks = new();

        public IEnumerable<TaskItem> GetAll() => _tasks.Values;

        public TaskItem GetById(Guid id) => _tasks.GetValueOrDefault(id);

        public TaskItem Add(TaskItem task)
        {
            task.Id = Guid.NewGuid();
            _tasks[task.Id] = task;
            return task;
        }

        public TaskItem Update(TaskItem task)
        {
            _tasks[task.Id] = task;
            return task;
        }

        public bool Delete(Guid id) => _tasks.Remove(id);
    }

}
