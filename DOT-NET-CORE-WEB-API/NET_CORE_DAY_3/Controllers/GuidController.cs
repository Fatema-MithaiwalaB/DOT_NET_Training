using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NET_CORE_DAY_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidController : ControllerBase
    {
        private readonly IGuidServices _guidSingleton;
        private readonly IGuidServices _guidTransient;
        private readonly IGuidServices _guidScoped;

        public GuidController([FromServices] IGuidServices guidsingleton, [FromServices] IGuidServices guidtransient, [FromServices] IGuidServices guidscoped)
        {
            _guidSingleton = guidsingleton;
            _guidTransient = guidtransient;
            _guidScoped = guidscoped;
        }

        [HttpGet("guids")]

        public IActionResult GetGuid() 
        {
            Console.WriteLine(_guidSingleton.getGuid()); 
            Console.WriteLine(_guidTransient.getGuid());
            Console.WriteLine(_guidScoped.getGuid());


            return Ok(new
            {
                SingletonGuid = _guidSingleton.getGuid(),
                TransientGuid = _guidTransient.getGuid(),
                ScopedGuid = _guidScoped.getGuid(),
            });
        }
    }
}
