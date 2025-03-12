using EF_Assignment_5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Assignment_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EagerLoadingController : ControllerBase
    {
        private readonly IEagerLoadingService _eagerLoadingService;

        public EagerLoadingController(IEagerLoadingService eagerLoadingService)
        {
            _eagerLoadingService = eagerLoadingService;
        }

        [HttpGet("CustomersWithOrdersAndOrderProducts")]
        public IActionResult GetCustomersWithOrdersAndOrderProducts()
        {
            var customers = _eagerLoadingService.GetCustomersWithOrdersAndOrderProducts();
            return Ok(customers);
        }

        [HttpGet("RecentCustomersWithOrdersAndOrderProducts")]
        public IActionResult GetRecentCustomersWithOrdersAndOrderProducts()
        {
            var customers = _eagerLoadingService.GetRecentCustomersWithOrdersAndOrderProducts();
            return Ok(customers);
        }

        [HttpGet("products-with-orders")]
        public IActionResult GetProductsWithOrderCount()
        {
            var result = _eagerLoadingService.GetProductsWithOrderCount();
            return Ok(result);
        }

        [HttpGet("recent-orders")]
        public IActionResult GetOrdersPlacedInLastMonth()
        {
            var result = _eagerLoadingService.GetOrdersPlacedInLastMonth();
            return Ok(result);
        }
    }

}
