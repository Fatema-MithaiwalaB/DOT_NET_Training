using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NET_CORE_DAY_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileReaderController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileReaderController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // Pass filename as a route parameter
        [HttpGet("read/{filename}")]
        public IActionResult ReadFromFile(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return BadRequest(new { Message = "Filename cannot be empty" });
            }

            var content = _fileService.ReadFromFile(filename);

            if (content == null)
            {
                return NotFound(new { Message = $"File '{filename}' not found." });
            }

            return Ok(new { FileName = filename, Content = content });
        }
    }
}
