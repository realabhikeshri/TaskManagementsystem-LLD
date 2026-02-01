using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = TaskManagementsystem_LLD.Models.Task;

namespace TaskManagementsystem_LLD.Repositories
{
    public interface ITaskRepository
    {
        void Add(Task task);
        Task GetById(int id);
        List<Task> GetAll();
    }
}
