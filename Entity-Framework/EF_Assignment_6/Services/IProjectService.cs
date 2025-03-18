using EF_Assignment_6.Models.DTOs;

namespace EF_Assignment_6.Services
{
    public interface IProjectService
    {
        Task<List<ProjectDTO>> GetAllProjects();
        Task<ProjectDTO?> GetProjectById(int id);
    }
}
