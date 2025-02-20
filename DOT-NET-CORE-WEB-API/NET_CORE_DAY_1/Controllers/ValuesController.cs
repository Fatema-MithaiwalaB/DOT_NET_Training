using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NET_CORE_DAY_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("save")]
        public bool WriteData([FromBody] object data)
        {
            try
            {
                Console.WriteLine(data.ToString());
                string filePath = "WriteData.txt";
                
                
                    using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                    {
                        streamWriter.WriteLine(data.ToString());
                    }
                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}