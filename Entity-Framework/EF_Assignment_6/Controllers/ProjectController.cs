using EF_Assignment_6.Services;
using EF_Assignment_6.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EF_Assignment_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // 🔹 GET: Retrieve all projects
        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await _projectService.GetAllProjects());
        }

        // 🔹 GET: Retrieve a single project by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectById(id);
            if (project == null) return NotFound();
            return Ok(project);
        }
    }
}
