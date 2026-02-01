using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementsystem_LLD.Enums;
using TaskManagementsystem_LLD.Models;
using TaskManagementsystem_LLD.Repositories;
using Task = TaskManagementsystem_LLD.Models.Task;
using TaskStatus = TaskManagementsystem_LLD.Enums.TaskStatus;

namespace TaskManagementsystem_LLD.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task CreateTask(int id ,string title, string description, TaskPriority priority)
        {
            var task = new Task(id, title, description, priority);
            _taskRepository.Add(task);
            return task;
        }

        public void AssignTask(int taskId, User user)
        {
            var task = GetTask(taskId);
            task.AssignUser(user);
        }

        public void UpdateStatus(int taskId, TaskStatus status)
        {
            var task = GetTask(taskId);
            task.UpdateStatus(status);
        }

        public void UpdatePriority(int taskId, TaskPriority priority)
        {
            var task = GetTask(taskId);
            task.UpdatePriority(priority);
        }

        public List<Task> GetTasksByUser(User user)
        {
            return _taskRepository.GetAll()
                .Where(t => t.AssignedTo?.Id == user.Id)
                .ToList();
        }

        public List<Task> GetTasksByStatus(TaskStatus status)
        {
            return _taskRepository.GetAll()
                .Where(t => t.Status == status)
                .ToList();
        }

        public List<Task> GetTasksByPriority(TaskPriority priority)
        {
            return _taskRepository.GetAll()
                .Where(t => t.Priority == priority)
                .ToList();
        }

        private Task GetTask(int id)
        {
            return _taskRepository.GetById(id)
                   ?? throw new Exception("Task not found");
        }
    }
}
