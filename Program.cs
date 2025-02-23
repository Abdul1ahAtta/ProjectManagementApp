using ProjectManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagementApp.Data;
using ProjectManagementApp.Repositories;
using ProjectManagementApp.Services;

var services = new ServiceCollection();


string connectionString = "Server=YOUR_SERVER;Database=ProjectManagementDB;Trusted_Connection=True;TrustServerCertificate=True;";

services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

services.AddScoped<IProjectRepository, ProjectRepository>();
services.AddScoped<ProjectService>();

var serviceProvider = services.BuildServiceProvider();
var projectService = serviceProvider.GetService<ProjectService>();

Console.WriteLine("=== Project Management System ===");
Console.WriteLine("1. Add Project");
Console.WriteLine("2. View Projects");
Console.Write("Choose an option: ");

if (int.TryParse(Console.ReadLine(), out int choice))
{
    if (choice == 1)
    {
        var project = new Project
        {
            Name = "New Project",
            StartDate = DateTime.Now,
            Status = "Ongoing"
        };

        projectService.CreateProject(project);
        Console.WriteLine("Project Added Successfully!");
    }
    else if (choice == 2)
    {
        var projects = projectService.GetAllProjects();
        foreach (var project in projects)
        {
            Console.WriteLine($"ID: {project.Id}, Name: {project.Name}, Status: {project.Status}");
        }
    }
}
else
{
    Console.WriteLine("Invalid input! Please enter a number.");
}
