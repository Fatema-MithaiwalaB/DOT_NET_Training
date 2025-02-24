using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET_CORE_DAY_3.Services;

namespace NET_CORE_DAY_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("save")]

        public IActionResult SaveFile([FromBody] FileRequest request)
        {
            if (string.IsNullOrEmpty(request.FileName) || string.IsNullOrWhiteSpace(request.Content) )
            {
                return BadRequest("Filename & Content cannot be empty");
            }

            _fileService.SaveToFile(request.FileName, request.Content);
            return Ok($"File : {request.FileName} saved successfully");
        }

    }
}

public class FileRequest
{
    public string? FileName { get; set; }
    public string? Content { get; set; }
}
