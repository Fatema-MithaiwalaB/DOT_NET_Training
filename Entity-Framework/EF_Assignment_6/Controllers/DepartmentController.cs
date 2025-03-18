using EF_Assignment_6.Models.Entity;
using EF_Assignment_6.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF_Assignment_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var departments = await _departmentService.GetAllDepartments(pageNumber, pageSize);
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentById(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            var newDepartment = await _departmentService.CreateDepartment(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = newDepartment.DepartmentId }, newDepartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] Department department)
        {
            var updated = await _departmentService.UpdateDepartment(id, department);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleted = await _departmentService.DeleteDepartment(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
