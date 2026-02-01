using System;
using TaskManagementsystem_LLD.Enums;
using TaskManagementsystem_LLD.Models;
using TaskManagementsystem_LLD.Repositories;
using TaskManagementsystem_LLD.Services;
using TaskStatus = TaskManagementsystem_LLD.Enums.TaskStatus;

class Program
{
    static void Main()
    {
        var repo = new InMemoryTaskRepository();
        var taskService = new TaskService(repo);

        var alice = new User("Alice");
        var bob = new User("Bob");

        var task1 = taskService.CreateTask(
            1,
            "Design API",
            "Design task management API",
            TaskPriority.High);

        taskService.AssignTask(task1.Id, alice);
        taskService.UpdateStatus(task1.Id, TaskStatus.InProgress);

        var task2 = taskService.CreateTask(
            2,
            "Fix Bug",
            "Fix production issue",
            TaskPriority.Critical);

        taskService.AssignTask(task2.Id, bob);

        Console.WriteLine("Alice Tasks:");
        foreach (var task in taskService.GetTasksByUser(alice))
            Console.WriteLine($"{task.Title} - {task.Status}");
    }
}
