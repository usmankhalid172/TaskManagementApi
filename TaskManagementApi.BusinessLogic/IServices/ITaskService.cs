using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApi.Entities.Models;

namespace TaskManagementApi.BusinessLogic.IServices
{
    public interface ITaskService
    {
        IEnumerable<TaskItem> GetAllTasks();
        TaskItem GetTaskById(Guid id);
        TaskItem CreateTask(TaskItem task);
        TaskItem UpdateTask(Guid id, TaskItem task);
        bool DeleteTask(Guid id);
    }
}
