using EF_Assignment_5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Assignment_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LazyLoadingController : ControllerBase
    {
        private readonly ILazyLoadingService _lazyLoadingService;

        public LazyLoadingController(ILazyLoadingService lazyLoadingService)
        {
            _lazyLoadingService = lazyLoadingService;
        }

        [HttpGet("GetCustomersWithOrders")]
        public IActionResult GetCustomersWithOrders()
        {
            var customers = _lazyLoadingService.GetCustomersWithOrders();
            return Ok(customers);
        }

        [HttpGet("GetHighValueCustomers")]
        public IActionResult GetHighValueCustomers()
        {
            var customers = _lazyLoadingService.GetHighValueCustomers();
            return Ok(customers);
        }
    }
}
