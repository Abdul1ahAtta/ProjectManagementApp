using ProjectManagementApp.Models;
public interface IProjectRepository
{
    void AddProject(Project project);
    IEnumerable<Project> GetProjects();
    Project? GetProjectById(int id); 
    void UpdateProject(Project project);
    void DeleteProject(int id);
}
