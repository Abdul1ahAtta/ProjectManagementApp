using System.Collections.Generic;
using ProjectManagementApp.Models;
using ProjectManagementApp.Repositories;

namespace ProjectManagementApp.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void CreateProject(Project project)
        {
            _projectRepository.AddProject(project);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _projectRepository.GetProjects();
        }
    }
}
