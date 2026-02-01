using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = TaskManagementsystem_LLD.Models.Task;

namespace TaskManagementsystem_LLD.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly Dictionary<int, Task> _tasks = new();

        public void Add(Task task)
        {
            _tasks[task.Id] = task;
        }

        public Task GetById(int id)
        {
            return _tasks.GetValueOrDefault(id);
        }

        public List<Task> GetAll()
        {
            return _tasks.Values.ToList();
        }
    }
}
