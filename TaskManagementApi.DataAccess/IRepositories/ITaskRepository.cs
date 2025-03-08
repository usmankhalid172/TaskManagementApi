using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApi.Entities.Models;

namespace TaskManagementApi.DataAccess.IRepositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem GetById(Guid id);
        TaskItem Add(TaskItem task);
        TaskItem Update(TaskItem task);
        bool Delete(Guid id);
    }
}
