using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET_CORE_DAY_4.Services;

namespace NET_CORE_DAY_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("add")]
        public IActionResult AddStudent(Student student) 
        {
            _studentService.AddStudent(student);
            return Ok("Student added successfully!");
        }

        [HttpGet("getall")]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }
    }
}
