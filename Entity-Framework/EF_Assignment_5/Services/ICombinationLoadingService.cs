using EF_Assignment_5.Models.DTOs;

namespace EF_Assignment_5.Services
{
    public interface ICombinationLoadingService
    {
        List<OrderDTO> GetOrdersWithLazyOrderProducts();
        List<OrderDTO> GetOrdersWithConditionalOrderProducts();
        CustomerDTO? GetCustomerOrdersWithConditionalOrderProducts(int customerId);
    }
}
