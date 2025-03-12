using EF_Assignment_5.Models.DTOs;

namespace EF_Assignment_5.Services
{
    public interface IEagerLoadingService
    {
        List<CustomerDTO> GetCustomersWithOrdersAndOrderProducts();
        List<CustomerDTO> GetRecentCustomersWithOrdersAndOrderProducts();
        List<ProductOrderCountDTO> GetProductsWithOrderCount();
        List<OrderSummaryDTO> GetOrdersPlacedInLastMonth();
    }
}
