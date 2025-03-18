using EF_Assignment_6.Models.DTOs;
using EF_Assignment_6.Models.Entity;

namespace EF_Assignment_6.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> GetAllDepartments(int pageNumber, int pageSize);
        Task<DepartmentDTO?> GetDepartmentById(int id);
        Task<Department> CreateDepartment(Department department);
        Task<bool> UpdateDepartment(int id, Department department);
        Task<bool> DeleteDepartment(int id);
    }
}
