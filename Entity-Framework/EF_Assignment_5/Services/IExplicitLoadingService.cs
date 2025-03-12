using EF_Assignment_5.Models.DTOs;

namespace EF_Assignment_5.Services
{
    public interface IExplicitLoadingService
    {
        CustomerDTO? GetCustomerWithOrders(int customerId);
        List<OrderDTO> GetOrdersWithoutOrderProducts();
        List<ProductDTO> GetProductsWithConditionalOrders();
        List<CustomerDTO> GetCustomersWithOrdersAndLoadOrderProducts();
    }
}
