using System.Collections.Generic;

namespace EF_Assignment_6.Models.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
    }
}
