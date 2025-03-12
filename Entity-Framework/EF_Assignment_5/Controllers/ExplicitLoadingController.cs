using EF_Assignment_5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Assignment_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExplicitLoadingController : ControllerBase
    {
        private readonly IExplicitLoadingService _explicitLoadingService;

        public ExplicitLoadingController(IExplicitLoadingService explicitLoadingService)
        {
            _explicitLoadingService = explicitLoadingService;
        }

        [HttpGet("GetCustomersWithOrders/{customerId}")]
        public IActionResult GetCustomerWithOrders(int customerId)
        {
            var customer = _explicitLoadingService.GetCustomerWithOrders(customerId);
            if (customer == null) return NotFound("Customer not found.");
            return Ok(customer);
        }

        [HttpGet("GetOrdersWithoutOrderProducts")]
        public IActionResult GetOrdersWithoutOrderProducts()
        {
            var orders = _explicitLoadingService.GetOrdersWithoutOrderProducts();
            return Ok(orders);
        }

        [HttpGet("GetProductsWithConditionalOrders")]
        public IActionResult GetProductsWithConditionalOrders()
        {
            var products = _explicitLoadingService.GetProductsWithConditionalOrders();
            return Ok(products);
        }

        [HttpGet("GetCustomersWithOrdersAndLoadOrderProducts")]
        public IActionResult GetCustomersWithOrdersAndLoadOrderProducts()
        {
            var customers = _explicitLoadingService.GetCustomersWithOrdersAndLoadOrderProducts();
            return Ok(customers);
        }
    }
}
