using System.Collections.Generic;

namespace EF_Assignment_6.Models.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeProjectDTO> EmployeeProjects { get; set; } = new List<EmployeeProjectDTO>();
    }
}
