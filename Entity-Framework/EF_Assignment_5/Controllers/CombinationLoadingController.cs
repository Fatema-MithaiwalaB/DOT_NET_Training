using EF_Assignment_5.Services;
using EF_Assignment_5.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EF_Assignment_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombinationLoadingController : ControllerBase
    {
        private readonly ICombinationLoadingService _combinationLoadingService;

        public CombinationLoadingController(ICombinationLoadingService combinationLoadingService)
        {
            _combinationLoadingService = combinationLoadingService;
        }

        // 1️⃣ Fetch Orders with eager loading, but OrderProducts are lazily loaded only when accessed
        [HttpGet("orders-lazy-order-products")]
        public ActionResult<List<OrderDTO>> GetOrdersWithLazyOrderProducts()
        {
            var orders = _combinationLoadingService.GetOrdersWithLazyOrderProducts();
            return Ok(orders);
        }

        // 2️⃣ Fetch Orders eagerly, but explicitly load OrderProducts where Quantity > 5
        [HttpGet("orders-conditional-order-products")]
        public ActionResult<List<OrderDTO>> GetOrdersWithConditionalOrderProducts()
        {
            var orders = _combinationLoadingService.GetOrdersWithConditionalOrderProducts();
            return Ok(orders);
        }

        // 3️⃣ Retrieve a Customer’s Orders eagerly and explicitly load OrderProducts only if the Customer is marked as “VIP”
        [HttpGet("customer-orders/{customerId}")]
        public ActionResult<CustomerDTO> GetCustomerOrdersWithConditionalOrderProducts(int customerId)
        {
            var customer = _combinationLoadingService.GetCustomerOrdersWithConditionalOrderProducts(customerId);

            if (customer == null)
                return NotFound(new { message = "Customer not found" });

            return Ok(customer);
        }
    }
}
