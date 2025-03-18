using EF_Assignment_6.Models.DTOs;
using EmployeeProjectAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EF_Assignment_6.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectDTO>> GetAllProjects()
        {
            return await _context.Projects
                .Include(p => p.EmployeeProjects)
                    .ThenInclude(ep => ep.Employee)
                .Select(p => new ProjectDTO
                {
                    ProjectId = p.ProjectId,
                    ProjectName = p.ProjectName,
                    StartDate = p.StartDate,
                    EmployeeProjects = p.EmployeeProjects.Select(ep => new EmployeeProjectDTO
                    {
                        EmployeeId = ep.EmployeeId,
                        EmployeeName = ep.Employee.Name,
                        ProjectId = ep.ProjectId,
                        ProjectName = p.ProjectName,
                        Role = ep.Role
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<ProjectDTO?> GetProjectById(int id)
        {
            return await _context.Projects
                .Include(p => p.EmployeeProjects)
                    .ThenInclude(ep => ep.Employee)
                .Where(p => p.ProjectId == id)
                .Select(p => new ProjectDTO
                {
                    ProjectId = p.ProjectId,
                    ProjectName = p.ProjectName,
                    StartDate = p.StartDate
                })
                .FirstOrDefaultAsync();
        }
    }
}
