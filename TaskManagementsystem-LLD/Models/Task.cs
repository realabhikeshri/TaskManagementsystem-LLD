using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementsystem_LLD.Enums;
using TaskStatus = TaskManagementsystem_LLD.Enums.TaskStatus;

namespace TaskManagementsystem_LLD.Models
{
    public class Task
    {
        public int Id { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public User AssignedTo { get; private set; }
        public TaskStatus Status { get; private set; }
        public TaskPriority Priority { get; private set; }

        public Task(int id , string title, string description, TaskPriority priority)
        {
            Id = id;
            Title = title;
            Description = description;
            Priority = priority;
            Status = TaskStatus.Todo;
        }

        public void AssignUser(User user)
        {
            AssignedTo = user;
        }

        public void UpdatePriority(TaskPriority priority)
        {
            Priority = priority;
        }

        public void UpdateStatus(TaskStatus newStatus)
        {
            if (!IsValidTransition(Status, newStatus))
                throw new InvalidOperationException(
                    $"Invalid status transition from {Status} to {newStatus}");

            Status = newStatus;
        }

        private bool IsValidTransition(TaskStatus current, TaskStatus next)
        {
            return current switch
            {
                TaskStatus.Todo => next == TaskStatus.InProgress,
                TaskStatus.InProgress => next == TaskStatus.Blocked || next == TaskStatus.Completed,
                TaskStatus.Blocked => next == TaskStatus.InProgress,
                TaskStatus.Completed => false,
                _ => false
            };
        }
    }
}
