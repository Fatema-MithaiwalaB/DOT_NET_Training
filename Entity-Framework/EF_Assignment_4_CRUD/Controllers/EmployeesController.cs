using EF_Assignment_4_CRUD.Data;
using EF_Assignment_4_CRUD.Models;
using EF_Assignment_4_CRUD.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Assignment_4_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees() 
        {
            var employees = await dbContext.Employees.ToListAsync();

            return Ok(employees);
        }


        [HttpPost]
        public async Task<ActionResult> AddEmployee(AddEmployeesDTO addEmployeesDTO)
        {
            if (addEmployeesDTO == null || string.IsNullOrWhiteSpace(addEmployeesDTO.Name))
            {
                return BadRequest("Invalid employee data.");
            }
            var employeeEntity = new Employee()
            {
                Name = addEmployeesDTO.Name,
                Email = addEmployeesDTO.Email,
                Phone = addEmployeesDTO.Phone,
                Salary = addEmployeesDTO.Salary,
                IsDeleted = false
            };

            try
            {
                await dbContext.Employees.AddAsync(employeeEntity);
                await dbContext.SaveChangesAsync();
                return Ok(employeeEntity);
            }
            catch (Exception e)
            {
                return BadRequest("Employee not added");
            }    
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateEmployee(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            await dbContext.SaveChangesAsync();

            return Ok(employee);
        }

        //Hard Delete
        //[HttpDelete]
        //public IActionResult DeleteEmployee(int id) 
        //{
        //    var employees = dbContext.Employees.Find(id);

        //    if(employees is null)
        //    {
        //        return NotFound();
        //    }

        //    dbContext.Employees.Remove(employees);
        //    dbContext.SaveChanges();

        //    return Ok("Employee deleted");
        //}

        //Soft Delete
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            employee.IsDeleted = true;  
            await dbContext.SaveChangesAsync();

            return Ok($"Employee with ID { id} is marked as deleted.");
        }

    }
}
