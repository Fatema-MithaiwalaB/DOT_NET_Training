using System.ComponentModel.DataAnnotations;

namespace EF_Assignment_4_CRUD.Models
{
    public class AddEmployeesDTO
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }

    }
}
