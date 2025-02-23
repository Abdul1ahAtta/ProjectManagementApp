using ProjectManagementApp.Models;
using System.Collections.Generic;
using System.Linq;

using ProjectManagementApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementApp.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects.Include(p => p.Customer).ToList();
        }

        public Project? GetProjectById(int id)
        {
            return _context.Projects.Include(p => p.Customer).FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }
    }
}
